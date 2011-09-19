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

namespace netspeeder
{
    public partial class MainForm : Form
    {
        Boolean testing = false;
        Int32 elipseNum = 1;
        List<NetData> lnd = new List<NetData>();
        //Dictionary<String, IPAddress> compsFound = new Dictionary<String, IPAddress>();
        public BindingList<CompFound> lcf = new BindingList<CompFound>();
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
                DataPropertyName = "hostname",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true,
                HeaderText = "Host Name"
            });
            hostsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
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
            if (!computerFinder.CancellationPending)
            {
                foreach (NetData nd in lnd)
                {
                    //computerFinder.ReportProgress(-1, System.Environment.MachineName + "(" + nd.ip.ToString() + ")");
                    System.Threading.Thread.Sleep(100);
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

        private void foundListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            startButton.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            computerFinder.CancelAsync();
        }

        private void interfaceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ipaddr.Text = lnd[interfaceListBox.SelectedIndex].ip.ToString();
            netmaskaddr.Text = lnd[interfaceListBox.SelectedIndex].netmask.ToString();
            bcastaddr.Text = lnd[interfaceListBox.SelectedIndex].broadcast.ToString();
            computerFinder.RunWorkerAsync();
            elipseTimer.Enabled = true;
        }

        private void manualHostAddbtn_Click(object sender, EventArgs e)
        {
            lookupBar.Style = ProgressBarStyle.Marquee;
            manualAddLookup.RunWorkerAsync();
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
                    System.Diagnostics.Debug.WriteLine("IP");
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
                    System.Diagnostics.Debug.WriteLine("Host");
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
    }
}
