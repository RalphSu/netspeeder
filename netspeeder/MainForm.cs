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
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            foundListBox.Items.Clear();
            interfaceListBox.Items.Clear();
            //computerFinder.RunWorkerAsync();
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
                            netmask = ni.GetIPProperties().UnicastAddresses[i].IPv4Mask
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
                    IPAddress f = GetBroadcastAddress(nd.ip, nd.netmask);
                    computerFinder.ReportProgress(-1, System.Environment.MachineName + "(" + nd.ip.ToString() + ")");
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        private void computerFinder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            foundListBox.Items.Add(e.UserState);
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
            //MessageBox.Show(lnd[interfaceListBox.SelectedIndex].netmask.ToString());
            computerFinder.RunWorkerAsync();
            elipseTimer.Enabled = true;
        }
    }
}
