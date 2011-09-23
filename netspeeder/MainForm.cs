using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace netspeeder
{
    public partial class MainForm : Form
    {
        Boolean testing = false;
        Int32 elipseNum = 1;
        List<NetData> lnd = new List<NetData>();
        //Dictionary<String, IPAddress> compsFound = new Dictionary<String, IPAddress>();
        public BindingList<CompFound> lcf = new BindingList<CompFound>();
        Boolean searchRan = false;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon_32;
            hostsGrid.Rows.Clear();
            interfaceListBox.Items.Clear();
            hostsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "hname",
                DataPropertyName = "hostname",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true,
                HeaderText = "Host Name"
            });
            hostsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ipaddr",
                DataPropertyName = "ip",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true,
                HeaderText = "IP Address"
            });
            hostsGrid.DataSource = lcf;
            //computerFinder.RunWorkerAsync();
            hostnamelbl.Text = Environment.MachineName;
            List<NetworkInterface> lni = new List<NetworkInterface>();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    lni.Add(ni);
                }
            }
            foreach (NetworkInterface ni in lni)
            {
                Int32 i = 0;
                for (; i < ni.GetIPProperties().UnicastAddresses.Count; i++)
                {
                    if (ni.GetIPProperties().UnicastAddresses[i].Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        lnd.Add(new NetData()
                        {
                            netiface = ni,
                            ip = ni.GetIPProperties().UnicastAddresses[i].Address,
                            netmask = ni.GetIPProperties().UnicastAddresses[i].IPv4Mask,
                            broadcast = GetBroadcastAddress(
                                ni.GetIPProperties().UnicastAddresses[i].Address, 
                                ni.GetIPProperties().UnicastAddresses[i].IPv4Mask)
                        });
                    }
                }
            }
            foreach (NetData nd in lnd)
            {
                interfaceListBox.Items.Add(nd.netiface.Description);
            }
            speedTestRequestListener.RunWorkerAsync();
            //MessageBox.Show(interfaceListBox.SelectedValue as String);
        }

        private void elipseTimer_Tick(object sender, EventArgs e)
        {
            if (!testing)
            {
                statusLabel.Text = "Searching for computers";
                statusLabel.Text += new String('.', elipseNum);
                elipseNum++;
                if (elipseNum > 3)
                {
                    elipseNum = 0;
                }
            }
        }

        private void computerFinder_DoWork(object sender, DoWorkEventArgs e)
        {
            searchRan = true;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            NetData given = e.Argument as NetData;
            IPEndPoint ipep = new IPEndPoint(given.broadcast, 7829);
            Byte[] data = Encoding.UTF8.GetBytes("LST:" + Environment.MachineName + "," + given.ip.ToString() + "\n");
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            while (!computerFinder.CancellationPending)
            {
                sock.SendTo(data, ipep);
                System.Threading.Thread.Sleep(500);
            }
            computerFinderListener.CancelAsync();
            sock.Close();
        }
        private void computerFinderListener_DoWork(object sender, DoWorkEventArgs e)
        {
            Socket sockl = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipepl = new IPEndPoint(IPAddress.Any, 7829);
            sockl.Bind(ipepl);
            EndPoint ep = ipepl as EndPoint;
            Byte[] recv = new Byte[1024];
            sockl.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
            while (!computerFinderListener.CancellationPending)
            {
                try
                {
                    recv = new Byte[1024];
                    sockl.ReceiveFrom(recv, ref ep);
                    String[] recvl = Encoding.UTF8.GetString(recv).Substring(4).TrimEnd('\0').Split(',');
                    computerFinderListener.ReportProgress(-1, new CompFound()
                    {
                        hostname = recvl[0],
                        ip = recvl[1]
                    });
                }
                catch (Exception)
                {
                    //do nothing, timeout is only thing that can throw an exception anyway
                }
            }
            sockl.Close();
        }
        private void computerFinderListener_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CompFound c = e.UserState as CompFound;
            if (c.hostname != Environment.MachineName)
            {
                Boolean exists = false;
                //bindinglists are funny with foreach... (as in they don't work)
                for (Int32 i = 0; i < lcf.Count; i++)
                {
                    if (lcf[i].hostname == c.hostname)
                    {
                        exists = true;
                    }
                }
                if (exists == false)
                {
                    lcf.Add(c);
                }
            }
        }
        public static IPAddress GetBroadcastAddress(IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            testProgressBar.Style = ProgressBarStyle.Marquee;
            computerFinder.CancelAsync();
            IPAddress ip = IPAddress.Parse((hostsGrid.SelectedRows[0].Cells["ipaddr"].Value as String).TrimEnd('\n'));
            if (!speedTestRequester.IsBusy)
            {
                speedTestRequester.RunWorkerAsync(ip);
                Debug.WriteLine("Requester started");
                startButton.Enabled = false;
                searchButton.Enabled = false;
            }
        }

        private void interfaceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = true;
            searchButton.PerformClick();
        }

        private void manualHostAddbtn_Click(object sender, EventArgs e)
        {
            if (manualHostTextBox.Text != String.Empty)
            {
                lookupBar.Style = ProgressBarStyle.Marquee;
                manualAddLookup.RunWorkerAsync();
            }
        }

        private void manualAddLookup_DoWork(object sender, DoWorkEventArgs e)
        {
            List<CompFound> lcfl = new List<CompFound>();
            try
            {
                try
                {
                    IPAddress parsed = IPAddress.Parse(manualHostTextBox.Text);
                    IPHostEntry ihe = Dns.GetHostEntry(parsed);
                    //compsFound.Add(ihe.HostName, parsed);
                    lcfl.Add(new CompFound()
                    {
                        hostname = ihe.HostName,
                        ip = parsed.ToString()
                    });
                    Debug.WriteLine("IP");
                }
                catch (Exception ex)
                {
                    IPAddress[] ip = Dns.GetHostAddresses(manualHostTextBox.Text);
                    //Int32 i2 = 0;
                    foreach (IPAddress i in ip)
                    {
                        if (i.AddressFamily == AddressFamily.InterNetwork)
                        {
                            //compsFound.Add(manualHostTextBox.Text + "(" + i2+ ")" , i);
                            lcfl.Add(new CompFound()
                            {
                                hostname = manualHostTextBox.Text,
                                ip = i.ToString()
                            });
                        }
                        //i2++;
                    }
                    Debug.WriteLine("Host");
                }
                e.Result = lcfl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error with host or IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void manualAddLookup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lookupBar.Style = ProgressBarStyle.Blocks;
            if (e.Result is List<CompFound>)
            {
                foreach(CompFound cf in e.Result as List<CompFound>)
                {
                    lcf.Add(cf);
                }
            }
        }

        private void hostsGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            startButton.Enabled = true;
        }

        private void manualHostTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                manualHostAddbtn.PerformClick();
            }
        }

        private void computerFinder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            elipseTimer.Enabled = false;
            statusLabel.Text = "Done searching.";
            searchButton.Text = "Start search";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!computerFinder.IsBusy)
            {
                ipaddr.Text = lnd[interfaceListBox.SelectedIndex].ip.ToString();
                netmaskaddr.Text = lnd[interfaceListBox.SelectedIndex].netmask.ToString();
                bcastaddr.Text = lnd[interfaceListBox.SelectedIndex].broadcast.ToString();
                computerFinder.RunWorkerAsync(lnd[interfaceListBox.SelectedIndex]);
                computerFinderListener.RunWorkerAsync();
                elipseTimer.Enabled = true;
                searchButton.Text = "Stop search";
            }
            else
            {
                computerFinder.CancelAsync();
                searchTimer.Enabled = true;
                searchButton.Enabled = false;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            hostsGrid.Rows.Clear();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchButton.Enabled = true;
            searchTimer.Enabled = false;
        }

        private void speedTestRequester_DoWork(object sender, DoWorkEventArgs e)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress ip = e.Argument as IPAddress;
            IPEndPoint ipep = new IPEndPoint(ip, 7830);
            EndPoint ep = ipep;
            Byte[] buf;
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
            Int32 counter = 0;
            while (!speedTestRequester.CancellationPending)
            {
                try
                {
                    sock.SendTo(Encoding.UTF8.GetBytes("?" + Environment.MachineName), ipep);
                    buf = new Byte[1024];
                    sock.ReceiveFrom(buf, ref ep);
                    if (buf[0] == 0x31)
                    {
                        //MessageBox.Show("Speedtest request accepted");
                        e.Result = 0;
                        break;
                    }
                }
                catch (Exception)
                {
                    //do nothing
                }
                if (counter++ > 15)
                {
                    e.Result = 1;
                    break;
                }
            }
            sock.Close();

        }

        private void speedTestRequestListener_DoWork(object sender, DoWorkEventArgs e)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7830);
            EndPoint ep = ipep;
            sock.Bind(ipep as EndPoint);
            Byte[] buf;
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
            e.Result = 1;
            while (!speedTestRequestListener.CancellationPending)
            {   
                try
                {
                    buf = new Byte[50];
                    sock.ReceiveFrom(buf, ref ep);
                    Debug.WriteLine(BitConverter.ToString(buf));
                    if (buf[0] == 0x3F)
                    {
                        sock.SendTo(new Byte[] { 0x31 }, ep);
                        //MessageBox.Show("Speedtest Request from: " + Encoding.UTF8.GetString(buf).Substring(1).TrimEnd('\0'));
                        e.Result = 0;
                        break;
                    }
                }
                catch (Exception)
                {
                    //do nothing
                }
            }
            sock.Close();
        }
        private void speedTestRequester_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            testProgressBar.Style = ProgressBarStyle.Blocks;
            if ((int)e.Result == 1)
            {
                MessageBox.Show("Unable to connect to remote host\nIs the host busy or offline?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                speedTestClient.RunWorkerAsync();
                Debug.WriteLine("Speed test client started");
            }
            Debug.WriteLine("Requester stopped");
            startButton.Enabled = true;
            if (searchRan)
            {
                searchButton.Enabled = true;
            }
        }
        private void speedTestRequestListener_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                speedTestServer.RunWorkerAsync();
                Debug.WriteLine("Speed test server started");
            }
        }
        private void speedTestServer_DoWork(object sender, DoWorkEventArgs e)
        {
            //blah, I'll just use udp as I don't want to do anymore crazy workarounds
            //for backgroundworker to get a tcp accept to stop like I can with udp

            //Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7830);
            //sock.Bind(ipep);
            //sock.Listen(10);
            //Socket client;
            //IPEndPoint cipep;
            //while (!speedTestServer.CancellationPending)
            //{
            //    try
            //    {
            //        client = sock.Accept();
            //        cipep = client.RemoteEndPoint as IPEndPoint;
            //        Debug.WriteLine("Connected to " + cipep.ToString());
            //        while (!speedTestServer.CancellationPending)
            //        {
            //            Byte[] cdata = new Byte[50];

            //        }
            //    }
            //    catch(Exception)
            //    {
            //        //do nothing
            //    }
            //}


        }

        private void speedTestClient_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
