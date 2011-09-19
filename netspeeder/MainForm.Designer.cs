namespace netspeeder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.startButton = new System.Windows.Forms.Button();
            this.elipseTimer = new System.Windows.Forms.Timer(this.components);
            this.computerFinder = new System.ComponentModel.BackgroundWorker();
            this.interfaceListBox = new System.Windows.Forms.ComboBox();
            this.netmasklbl = new System.Windows.Forms.Label();
            this.netmaskaddr = new System.Windows.Forms.Label();
            this.bcastlbl = new System.Windows.Forms.Label();
            this.bcastaddr = new System.Windows.Forms.Label();
            this.ipaddrlbl = new System.Windows.Forms.Label();
            this.ipaddr = new System.Windows.Forms.Label();
            this.downloadSpeedlbl = new System.Windows.Forms.Label();
            this.downloadSpeedVlbl = new System.Windows.Forms.Label();
            this.uploadSpeedlbl = new System.Windows.Forms.Label();
            this.uploadSpeedVlbl = new System.Windows.Forms.Label();
            this.testProgressBar = new System.Windows.Forms.ProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.hostlbl = new System.Windows.Forms.Label();
            this.hostnamelbl = new System.Windows.Forms.Label();
            this.manualHostAddbtn = new System.Windows.Forms.Button();
            this.manualHostTextBox = new System.Windows.Forms.TextBox();
            this.hostsGrid = new System.Windows.Forms.DataGridView();
            this.manualAddLookup = new System.ComponentModel.BackgroundWorker();
            this.lookupBar = new System.Windows.Forms.ProgressBar();
            this.shutupbutton = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hostsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 237);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(424, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(160, 17);
            this.statusLabel.Text = "Waiting for user information.";
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(245, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(167, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start test with selection";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // elipseTimer
            // 
            this.elipseTimer.Interval = 500;
            this.elipseTimer.Tick += new System.EventHandler(this.elipseTimer_Tick);
            // 
            // computerFinder
            // 
            this.computerFinder.WorkerSupportsCancellation = true;
            this.computerFinder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.computerFinder_DoWork);
            // 
            // interfaceListBox
            // 
            this.interfaceListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.interfaceListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interfaceListBox.FormattingEnabled = true;
            this.interfaceListBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.interfaceListBox.Location = new System.Drawing.Point(245, 41);
            this.interfaceListBox.Name = "interfaceListBox";
            this.interfaceListBox.Size = new System.Drawing.Size(167, 21);
            this.interfaceListBox.TabIndex = 3;
            this.toolTip.SetToolTip(this.interfaceListBox, "Adapter to search for other computers on");
            this.interfaceListBox.SelectedIndexChanged += new System.EventHandler(this.interfaceListBox_SelectedIndexChanged);
            // 
            // netmasklbl
            // 
            this.netmasklbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.netmasklbl.AutoSize = true;
            this.netmasklbl.Location = new System.Drawing.Point(248, 91);
            this.netmasklbl.Name = "netmasklbl";
            this.netmasklbl.Size = new System.Drawing.Size(52, 13);
            this.netmasklbl.TabIndex = 6;
            this.netmasklbl.Text = "Netmask:";
            this.toolTip.SetToolTip(this.netmasklbl, "Subnet Mask (used to determine if an address is on the same (sub)network)");
            // 
            // netmaskaddr
            // 
            this.netmaskaddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.netmaskaddr.AutoSize = true;
            this.netmaskaddr.Location = new System.Drawing.Point(307, 91);
            this.netmaskaddr.Name = "netmaskaddr";
            this.netmaskaddr.Size = new System.Drawing.Size(53, 13);
            this.netmaskaddr.TabIndex = 7;
            this.netmaskaddr.Text = "Unknown";
            this.toolTip.SetToolTip(this.netmaskaddr, "Subnet Mask (used to determine if an address is on the same (sub)network)");
            // 
            // bcastlbl
            // 
            this.bcastlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcastlbl.AutoSize = true;
            this.bcastlbl.Location = new System.Drawing.Point(242, 104);
            this.bcastlbl.Name = "bcastlbl";
            this.bcastlbl.Size = new System.Drawing.Size(58, 13);
            this.bcastlbl.TabIndex = 8;
            this.bcastlbl.Text = "Broadcast:";
            this.toolTip.SetToolTip(this.bcastlbl, "Broadcast address (address on which all computers on network receive message)");
            // 
            // bcastaddr
            // 
            this.bcastaddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcastaddr.AutoSize = true;
            this.bcastaddr.Location = new System.Drawing.Point(307, 104);
            this.bcastaddr.Name = "bcastaddr";
            this.bcastaddr.Size = new System.Drawing.Size(53, 13);
            this.bcastaddr.TabIndex = 9;
            this.bcastaddr.Text = "Unknown";
            this.toolTip.SetToolTip(this.bcastaddr, "Broadcast address (address on which all computers on network receive message)");
            // 
            // ipaddrlbl
            // 
            this.ipaddrlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ipaddrlbl.AutoSize = true;
            this.ipaddrlbl.Location = new System.Drawing.Point(255, 78);
            this.ipaddrlbl.Name = "ipaddrlbl";
            this.ipaddrlbl.Size = new System.Drawing.Size(45, 13);
            this.ipaddrlbl.TabIndex = 10;
            this.ipaddrlbl.Text = "IP Addr:";
            this.toolTip.SetToolTip(this.ipaddrlbl, "IP Address of this computer");
            // 
            // ipaddr
            // 
            this.ipaddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ipaddr.AutoSize = true;
            this.ipaddr.Location = new System.Drawing.Point(307, 78);
            this.ipaddr.Name = "ipaddr";
            this.ipaddr.Size = new System.Drawing.Size(53, 13);
            this.ipaddr.TabIndex = 11;
            this.ipaddr.Text = "Unknown";
            this.toolTip.SetToolTip(this.ipaddr, "IP Address of this computer");
            // 
            // downloadSpeedlbl
            // 
            this.downloadSpeedlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadSpeedlbl.AutoSize = true;
            this.downloadSpeedlbl.Location = new System.Drawing.Point(242, 117);
            this.downloadSpeedlbl.Name = "downloadSpeedlbl";
            this.downloadSpeedlbl.Size = new System.Drawing.Size(58, 13);
            this.downloadSpeedlbl.TabIndex = 12;
            this.downloadSpeedlbl.Text = "Download:";
            this.toolTip.SetToolTip(this.downloadSpeedlbl, "Download Speed from test computer");
            // 
            // downloadSpeedVlbl
            // 
            this.downloadSpeedVlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadSpeedVlbl.AutoSize = true;
            this.downloadSpeedVlbl.Location = new System.Drawing.Point(307, 117);
            this.downloadSpeedVlbl.Name = "downloadSpeedVlbl";
            this.downloadSpeedVlbl.Size = new System.Drawing.Size(53, 13);
            this.downloadSpeedVlbl.TabIndex = 13;
            this.downloadSpeedVlbl.Text = "Unknown";
            this.toolTip.SetToolTip(this.downloadSpeedVlbl, "Download Speed from test computer");
            // 
            // uploadSpeedlbl
            // 
            this.uploadSpeedlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadSpeedlbl.AutoSize = true;
            this.uploadSpeedlbl.Location = new System.Drawing.Point(256, 130);
            this.uploadSpeedlbl.Name = "uploadSpeedlbl";
            this.uploadSpeedlbl.Size = new System.Drawing.Size(44, 13);
            this.uploadSpeedlbl.TabIndex = 14;
            this.uploadSpeedlbl.Text = "Upload:";
            this.toolTip.SetToolTip(this.uploadSpeedlbl, "Upload speed to test computer");
            // 
            // uploadSpeedVlbl
            // 
            this.uploadSpeedVlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadSpeedVlbl.AutoSize = true;
            this.uploadSpeedVlbl.Location = new System.Drawing.Point(307, 130);
            this.uploadSpeedVlbl.Name = "uploadSpeedVlbl";
            this.uploadSpeedVlbl.Size = new System.Drawing.Size(53, 13);
            this.uploadSpeedVlbl.TabIndex = 15;
            this.uploadSpeedVlbl.Text = "Unknown";
            this.toolTip.SetToolTip(this.uploadSpeedVlbl, "Upload speed to test computer");
            // 
            // testProgressBar
            // 
            this.testProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testProgressBar.Location = new System.Drawing.Point(245, 146);
            this.testProgressBar.Name = "testProgressBar";
            this.testProgressBar.Size = new System.Drawing.Size(167, 21);
            this.testProgressBar.TabIndex = 16;
            this.toolTip.SetToolTip(this.testProgressBar, "Test Progress");
            // 
            // hostlbl
            // 
            this.hostlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hostlbl.AutoSize = true;
            this.hostlbl.Location = new System.Drawing.Point(268, 65);
            this.hostlbl.Name = "hostlbl";
            this.hostlbl.Size = new System.Drawing.Size(32, 13);
            this.hostlbl.TabIndex = 17;
            this.hostlbl.Text = "Host:";
            this.toolTip.SetToolTip(this.hostlbl, "Hostname of this computer");
            // 
            // hostnamelbl
            // 
            this.hostnamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hostnamelbl.AutoSize = true;
            this.hostnamelbl.Location = new System.Drawing.Point(307, 65);
            this.hostnamelbl.Name = "hostnamelbl";
            this.hostnamelbl.Size = new System.Drawing.Size(53, 13);
            this.hostnamelbl.TabIndex = 18;
            this.hostnamelbl.Text = "Unknown";
            this.toolTip.SetToolTip(this.hostnamelbl, "Hostname of this computer");
            // 
            // manualHostAddbtn
            // 
            this.manualHostAddbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.manualHostAddbtn.Location = new System.Drawing.Point(378, 174);
            this.manualHostAddbtn.Name = "manualHostAddbtn";
            this.manualHostAddbtn.Size = new System.Drawing.Size(34, 23);
            this.manualHostAddbtn.TabIndex = 19;
            this.manualHostAddbtn.Text = "Add";
            this.toolTip.SetToolTip(this.manualHostAddbtn, "Manually add host or IP");
            this.manualHostAddbtn.UseVisualStyleBackColor = true;
            this.manualHostAddbtn.Click += new System.EventHandler(this.manualHostAddbtn_Click);
            // 
            // manualHostTextBox
            // 
            this.manualHostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.manualHostTextBox.Location = new System.Drawing.Point(245, 176);
            this.manualHostTextBox.Name = "manualHostTextBox";
            this.manualHostTextBox.Size = new System.Drawing.Size(127, 20);
            this.manualHostTextBox.TabIndex = 20;
            this.toolTip.SetToolTip(this.manualHostTextBox, "Manually add host or IP");
            this.manualHostTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.manualHostTextBox_KeyUp);
            // 
            // hostsGrid
            // 
            this.hostsGrid.AllowUserToAddRows = false;
            this.hostsGrid.AllowUserToDeleteRows = false;
            this.hostsGrid.AllowUserToResizeRows = false;
            this.hostsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hostsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hostsGrid.Location = new System.Drawing.Point(12, 12);
            this.hostsGrid.MultiSelect = false;
            this.hostsGrid.Name = "hostsGrid";
            this.hostsGrid.ReadOnly = true;
            this.hostsGrid.RowHeadersVisible = false;
            this.hostsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hostsGrid.Size = new System.Drawing.Size(227, 222);
            this.hostsGrid.TabIndex = 21;
            this.hostsGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.hostsGrid_RowEnter);
            // 
            // manualAddLookup
            // 
            this.manualAddLookup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.manualAddLookup_DoWork);
            this.manualAddLookup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.manualAddLookup_RunWorkerCompleted);
            // 
            // lookupBar
            // 
            this.lookupBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupBar.Location = new System.Drawing.Point(245, 202);
            this.lookupBar.Name = "lookupBar";
            this.lookupBar.Size = new System.Drawing.Size(167, 10);
            this.lookupBar.TabIndex = 22;
            this.toolTip.SetToolTip(this.lookupBar, "Lookup Progress");
            // 
            // shutupbutton
            // 
            this.shutupbutton.Location = new System.Drawing.Point(24, 56);
            this.shutupbutton.Name = "shutupbutton";
            this.shutupbutton.Size = new System.Drawing.Size(75, 57);
            this.shutupbutton.TabIndex = 23;
            this.shutupbutton.Text = "Make the form shut up when enter is pressed";
            this.shutupbutton.UseVisualStyleBackColor = true;
            this.shutupbutton.Visible = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.shutupbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 259);
            this.Controls.Add(this.lookupBar);
            this.Controls.Add(this.hostsGrid);
            this.Controls.Add(this.manualHostTextBox);
            this.Controls.Add(this.manualHostAddbtn);
            this.Controls.Add(this.hostnamelbl);
            this.Controls.Add(this.hostlbl);
            this.Controls.Add(this.testProgressBar);
            this.Controls.Add(this.uploadSpeedVlbl);
            this.Controls.Add(this.uploadSpeedlbl);
            this.Controls.Add(this.downloadSpeedVlbl);
            this.Controls.Add(this.downloadSpeedlbl);
            this.Controls.Add(this.ipaddr);
            this.Controls.Add(this.ipaddrlbl);
            this.Controls.Add(this.bcastaddr);
            this.Controls.Add(this.bcastlbl);
            this.Controls.Add(this.netmaskaddr);
            this.Controls.Add(this.netmasklbl);
            this.Controls.Add(this.interfaceListBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.shutupbutton);
            this.MinimumSize = new System.Drawing.Size(440, 295);
            this.Name = "MainForm";
            this.Text = "LAN Speed Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hostsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer elipseTimer;
        private System.ComponentModel.BackgroundWorker computerFinder;
        private System.Windows.Forms.ComboBox interfaceListBox;
        private System.Windows.Forms.Label netmasklbl;
        private System.Windows.Forms.Label netmaskaddr;
        private System.Windows.Forms.Label bcastlbl;
        private System.Windows.Forms.Label bcastaddr;
        private System.Windows.Forms.Label ipaddrlbl;
        private System.Windows.Forms.Label ipaddr;
        private System.Windows.Forms.Label downloadSpeedlbl;
        private System.Windows.Forms.Label downloadSpeedVlbl;
        private System.Windows.Forms.Label uploadSpeedlbl;
        private System.Windows.Forms.Label uploadSpeedVlbl;
        private System.Windows.Forms.ProgressBar testProgressBar;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label hostlbl;
        private System.Windows.Forms.Label hostnamelbl;
        private System.Windows.Forms.Button manualHostAddbtn;
        private System.Windows.Forms.TextBox manualHostTextBox;
        private System.Windows.Forms.DataGridView hostsGrid;
        private System.ComponentModel.BackgroundWorker manualAddLookup;
        private System.Windows.Forms.ProgressBar lookupBar;
        private System.Windows.Forms.Button shutupbutton;
    }
}