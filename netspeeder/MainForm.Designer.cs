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
            this.foundListBox = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.elipseTimer = new System.Windows.Forms.Timer(this.components);
            this.computerFinder = new System.ComponentModel.BackgroundWorker();
            this.interfaceListBox = new System.Windows.Forms.ComboBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 237);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(404, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(160, 17);
            this.statusLabel.Text = "Waiting for user information.";
            // 
            // foundListBox
            // 
            this.foundListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.foundListBox.FormattingEnabled = true;
            this.foundListBox.HorizontalScrollbar = true;
            this.foundListBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.foundListBox.Location = new System.Drawing.Point(12, 12);
            this.foundListBox.Name = "foundListBox";
            this.foundListBox.ScrollAlwaysVisible = true;
            this.foundListBox.Size = new System.Drawing.Size(207, 212);
            this.foundListBox.TabIndex = 1;
            this.foundListBox.SelectedIndexChanged += new System.EventHandler(this.foundListBox_SelectedIndexChanged);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(225, 12);
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
            this.computerFinder.WorkerReportsProgress = true;
            this.computerFinder.WorkerSupportsCancellation = true;
            this.computerFinder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.computerFinder_DoWork);
            this.computerFinder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.computerFinder_ProgressChanged);
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
            this.interfaceListBox.Location = new System.Drawing.Point(225, 41);
            this.interfaceListBox.Name = "interfaceListBox";
            this.interfaceListBox.Size = new System.Drawing.Size(167, 21);
            this.interfaceListBox.TabIndex = 3;
            this.interfaceListBox.SelectedIndexChanged += new System.EventHandler(this.interfaceListBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 259);
            this.Controls.Add(this.interfaceListBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.foundListBox);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(420, 295);
            this.Name = "MainForm";
            this.Text = "LAN Speed Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ListBox foundListBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer elipseTimer;
        private System.ComponentModel.BackgroundWorker computerFinder;
        private System.Windows.Forms.ComboBox interfaceListBox;
    }
}