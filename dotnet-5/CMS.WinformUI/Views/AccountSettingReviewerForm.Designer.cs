namespace CMS
{
    partial class AccountSettingReviewerForm
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
            this.textBox_newPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.comboBox_conf = new System.Windows.Forms.ComboBox();
            this.comboBox_role = new System.Windows.Forms.ComboBox();
            this.textBox_contact = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_oldPassword = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_selectedKeywords = new System.Windows.Forms.ListBox();
            this.dataGridView_keyword = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_addKeyword = new System.Windows.Forms.Button();
            this.btn_removeKeyword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_keyword)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_nPass
            // 
            this.textBox_newPassword.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_newPassword.Location = new System.Drawing.Point(314, 182);
            this.textBox_newPassword.Name = "textBox_nPass";
            this.textBox_newPassword.Size = new System.Drawing.Size(332, 50);
            this.textBox_newPassword.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(63, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 41);
            this.label7.TabIndex = 44;
            this.label7.Text = "New Password";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(375, 863);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(271, 72);
            this.btn_cancel.TabIndex = 43;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(67, 863);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(288, 72);
            this.btn_save.TabIndex = 42;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // comboBox_conf
            // 
            this.comboBox_conf.Enabled = false;
            this.comboBox_conf.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_conf.FormattingEnabled = true;
            this.comboBox_conf.Location = new System.Drawing.Point(314, 437);
            this.comboBox_conf.Name = "comboBox_conf";
            this.comboBox_conf.Size = new System.Drawing.Size(332, 49);
            this.comboBox_conf.TabIndex = 41;
            // 
            // comboBox_role
            // 
            this.comboBox_role.Enabled = false;
            this.comboBox_role.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_role.FormattingEnabled = true;
            this.comboBox_role.Location = new System.Drawing.Point(314, 374);
            this.comboBox_role.Name = "comboBox_role";
            this.comboBox_role.Size = new System.Drawing.Size(332, 49);
            this.comboBox_role.TabIndex = 40;
            // 
            // textBox_cont
            // 
            this.textBox_contact.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_contact.Location = new System.Drawing.Point(314, 310);
            this.textBox_contact.Name = "textBox_cont";
            this.textBox_contact.Size = new System.Drawing.Size(332, 50);
            this.textBox_contact.TabIndex = 39;
            // 
            // textBox_email
            // 
            this.textBox_email.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_email.Location = new System.Drawing.Point(314, 246);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(332, 50);
            this.textBox_email.TabIndex = 38;
            // 
            // textBox_oPass
            // 
            this.textBox_oldPassword.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_oldPassword.Location = new System.Drawing.Point(314, 118);
            this.textBox_oldPassword.Name = "textBox_oPass";
            this.textBox_oldPassword.Size = new System.Drawing.Size(332, 50);
            this.textBox_oldPassword.TabIndex = 37;
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(314, 54);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(332, 50);
            this.textBox_name.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(63, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 41);
            this.label6.TabIndex = 35;
            this.label6.Text = "Conference";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 41);
            this.label5.TabIndex = 34;
            this.label5.Text = "Role";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 41);
            this.label4.TabIndex = 33;
            this.label4.Text = "Contact";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 41);
            this.label3.TabIndex = 32;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 41);
            this.label2.TabIndex = 31;
            this.label2.Text = "Old Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 41);
            this.label1.TabIndex = 30;
            this.label1.Text = "User Name";
            // 
            // listBox1
            // 
            this.listBox_selectedKeywords.FormattingEnabled = true;
            this.listBox_selectedKeywords.ItemHeight = 25;
            this.listBox_selectedKeywords.Location = new System.Drawing.Point(314, 512);
            this.listBox_selectedKeywords.Name = "listBox1";
            this.listBox_selectedKeywords.Size = new System.Drawing.Size(332, 254);
            this.listBox_selectedKeywords.TabIndex = 46;
            // 
            // dataGridView1
            // 
            this.dataGridView_keyword.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_keyword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_keyword.Location = new System.Drawing.Point(692, 57);
            this.dataGridView_keyword.MultiSelect = false;
            this.dataGridView_keyword.Name = "dataGridView1";
            this.dataGridView_keyword.ReadOnly = true;
            this.dataGridView_keyword.RowHeadersVisible = false;
            this.dataGridView_keyword.RowHeadersWidth = 82;
            this.dataGridView_keyword.RowTemplate.Height = 33;
            this.dataGridView_keyword.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_keyword.Size = new System.Drawing.Size(429, 878);
            this.dataGridView_keyword.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(63, 512);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 41);
            this.label8.TabIndex = 48;
            this.label8.Text = "Keyword";
            // 
            // btn_add
            // 
            this.btn_addKeyword.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addKeyword.Location = new System.Drawing.Point(314, 772);
            this.btn_addKeyword.Name = "btn_add";
            this.btn_addKeyword.Size = new System.Drawing.Size(167, 72);
            this.btn_addKeyword.TabIndex = 49;
            this.btn_addKeyword.Text = "Add";
            this.btn_addKeyword.UseVisualStyleBackColor = true;
            this.btn_addKeyword.Click += new System.EventHandler(this.btn_addKeyword_Click);
            // 
            // btn_remove
            // 
            this.btn_removeKeyword.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeKeyword.Location = new System.Drawing.Point(487, 772);
            this.btn_removeKeyword.Name = "btn_remove";
            this.btn_removeKeyword.Size = new System.Drawing.Size(159, 72);
            this.btn_removeKeyword.TabIndex = 50;
            this.btn_removeKeyword.Text = "Remove";
            this.btn_removeKeyword.UseVisualStyleBackColor = true;
            this.btn_removeKeyword.Click += new System.EventHandler(this.btn_removeKeyword_Click);
            // 
            // AccountSetting_R
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 977);
            this.Controls.Add(this.btn_removeKeyword);
            this.Controls.Add(this.btn_addKeyword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView_keyword);
            this.Controls.Add(this.listBox_selectedKeywords);
            this.Controls.Add(this.textBox_newPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.comboBox_conf);
            this.Controls.Add(this.comboBox_role);
            this.Controls.Add(this.textBox_contact);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_oldPassword);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AccountSetting_R";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountSetting_R";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_keyword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_newPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox comboBox_conf;
        private System.Windows.Forms.ComboBox comboBox_role;
        private System.Windows.Forms.TextBox textBox_contact;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_oldPassword;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_selectedKeywords;
        private System.Windows.Forms.DataGridView dataGridView_keyword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_addKeyword;
        private System.Windows.Forms.Button btn_removeKeyword;
    }
}