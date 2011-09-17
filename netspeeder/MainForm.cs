using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace netspeeder
{
    public partial class MainForm : Form
    {
        Boolean testing = false;
        Int32 elipseNum = 1;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            foundListBox.Items.Clear();
            computerFinder.RunWorkerAsync();
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
            while (true)
            {
                computerFinder.ReportProgress(-1, "ComputerName (127.0.0.1)");
                System.Threading.Thread.Sleep(400);
            }
        }

        private void computerFinder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            foundListBox.Items.Add(e.UserState);
        }

    }
}
