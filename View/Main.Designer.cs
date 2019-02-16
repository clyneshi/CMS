namespace CMS
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.strip_confMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_conf_confInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_userMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_user_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_user_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_systemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_system_help = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_system_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_confMenu,
            this.strip_userMenu,
            this.strip_systemMenu,
            this.testToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip.Size = new System.Drawing.Size(2085, 62);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // strip_confMenu
            // 
            this.strip_confMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_conf_confInfo});
            this.strip_confMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.strip_confMenu.Name = "strip_confMenu";
            this.strip_confMenu.Size = new System.Drawing.Size(220, 54);
            this.strip_confMenu.Text = "&Conference";
            // 
            // strip_conf_confInfo
            // 
            this.strip_conf_confInfo.Name = "strip_conf_confInfo";
            this.strip_conf_confInfo.Size = new System.Drawing.Size(518, 54);
            this.strip_conf_confInfo.Text = "Conference Information";
            this.strip_conf_confInfo.Click += new System.EventHandler(this.strip_conf_confInfo_Click);
            // 
            // strip_userMenu
            // 
            this.strip_userMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_user_settings,
            this.strip_user_logout});
            this.strip_userMenu.Name = "strip_userMenu";
            this.strip_userMenu.Size = new System.Drawing.Size(107, 54);
            this.strip_userMenu.Text = "User";
            // 
            // strip_user_settings
            // 
            this.strip_user_settings.Name = "strip_user_settings";
            this.strip_user_settings.Size = new System.Drawing.Size(389, 54);
            this.strip_user_settings.Text = "Acount Settings";
            this.strip_user_settings.Click += new System.EventHandler(this.strip_user_settings_Click);
            // 
            // strip_user_logout
            // 
            this.strip_user_logout.Name = "strip_user_logout";
            this.strip_user_logout.Size = new System.Drawing.Size(389, 54);
            this.strip_user_logout.Text = "Log out";
            this.strip_user_logout.Click += new System.EventHandler(this.strip_user_logout_Click);
            // 
            // strip_systemMenu
            // 
            this.strip_systemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_system_help,
            this.aboutToolStripMenuItem,
            this.strip_system_exit});
            this.strip_systemMenu.Name = "strip_systemMenu";
            this.strip_systemMenu.Size = new System.Drawing.Size(151, 54);
            this.strip_systemMenu.Text = "System";
            // 
            // strip_system_help
            // 
            this.strip_system_help.Name = "strip_system_help";
            this.strip_system_help.Size = new System.Drawing.Size(324, 54);
            this.strip_system_help.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(324, 54);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // strip_system_exit
            // 
            this.strip_system_exit.Name = "strip_system_exit";
            this.strip_system_exit.Size = new System.Drawing.Size(324, 54);
            this.strip_system_exit.Text = "Exit";
            this.strip_system_exit.Click += new System.EventHandler(this.strip_system_exit_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(95, 54);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.txt_status});
            this.statusStrip.Location = new System.Drawing.Point(0, 1326);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(2085, 37);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(119, 32);
            this.toolStripStatusLabel.Text = "Welcome,";
            // 
            // txt_status
            // 
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(238, 32);
            this.txt_status.Text = "toolStripStatusLabel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2085, 1264);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(2085, 1363);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDIParent1";
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem strip_confMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripStatusLabel txt_status;
        private System.Windows.Forms.ToolStripMenuItem strip_userMenu;
        private System.Windows.Forms.ToolStripMenuItem strip_user_settings;
        private System.Windows.Forms.ToolStripMenuItem strip_user_logout;
        private System.Windows.Forms.ToolStripMenuItem strip_systemMenu;
        private System.Windows.Forms.ToolStripMenuItem strip_system_help;
        private System.Windows.Forms.ToolStripMenuItem strip_system_exit;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strip_conf_confInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}



