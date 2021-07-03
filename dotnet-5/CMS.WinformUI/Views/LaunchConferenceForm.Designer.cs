namespace CMS
{
    partial class LaunchConferenceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.dateTimePicker_begin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_deadline = new System.Windows.Forms.DateTimePicker();
            this.btn_submit = new System.Windows.Forms.Button();
            this.listBox_selectedTopic = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_addTopic = new System.Windows.Forms.Button();
            this.btn_removeTopic = new System.Windows.Forms.Button();
            this.dataGridView_topic = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_topic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ttitle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "Begin Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 41);
            this.label4.TabIndex = 3;
            this.label4.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 41);
            this.label5.TabIndex = 4;
            this.label5.Text = "Paper Deadline";
            // 
            // textBox_title
            // 
            this.textBox_title.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_title.Location = new System.Drawing.Point(339, 53);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(603, 50);
            this.textBox_title.TabIndex = 5;
            // 
            // textBox_loc
            // 
            this.textBox_location.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_location.Location = new System.Drawing.Point(339, 126);
            this.textBox_location.Name = "textBox_loc";
            this.textBox_location.Size = new System.Drawing.Size(603, 50);
            this.textBox_location.TabIndex = 6;
            // 
            // dateTimePicker_bdate
            // 
            this.dateTimePicker_begin.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_begin.Location = new System.Drawing.Point(339, 213);
            this.dateTimePicker_begin.Name = "dateTimePicker_bdate";
            this.dateTimePicker_begin.Size = new System.Drawing.Size(603, 50);
            this.dateTimePicker_begin.TabIndex = 7;
            // 
            // dateTimePicker_edate
            // 
            this.dateTimePicker_end.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_end.Location = new System.Drawing.Point(339, 293);
            this.dateTimePicker_end.Name = "dateTimePicker_edate";
            this.dateTimePicker_end.Size = new System.Drawing.Size(603, 50);
            this.dateTimePicker_end.TabIndex = 8;
            // 
            // dateTimePicker_pdeadline
            // 
            this.dateTimePicker_deadline.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_deadline.Location = new System.Drawing.Point(339, 373);
            this.dateTimePicker_deadline.Name = "dateTimePicker_pdeadline";
            this.dateTimePicker_deadline.Size = new System.Drawing.Size(603, 50);
            this.dateTimePicker_deadline.TabIndex = 9;
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(339, 808);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(603, 82);
            this.btn_submit.TabIndex = 10;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // listBox1
            // 
            this.listBox_selectedTopic.FormattingEnabled = true;
            this.listBox_selectedTopic.ItemHeight = 25;
            this.listBox_selectedTopic.Location = new System.Drawing.Point(339, 463);
            this.listBox_selectedTopic.Name = "listBox1";
            this.listBox_selectedTopic.Size = new System.Drawing.Size(407, 304);
            this.listBox_selectedTopic.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 41);
            this.label6.TabIndex = 13;
            this.label6.Text = "Topic";
            // 
            // btn_add
            // 
            this.btn_addTopic.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addTopic.Location = new System.Drawing.Point(785, 521);
            this.btn_addTopic.Name = "btn_add";
            this.btn_addTopic.Size = new System.Drawing.Size(157, 62);
            this.btn_addTopic.TabIndex = 14;
            this.btn_addTopic.Text = "Add";
            this.btn_addTopic.UseVisualStyleBackColor = true;
            this.btn_addTopic.Click += new System.EventHandler(this.btn_addTopic_Click);
            // 
            // btn_remove
            // 
            this.btn_removeTopic.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeTopic.Location = new System.Drawing.Point(785, 636);
            this.btn_removeTopic.Name = "btn_remove";
            this.btn_removeTopic.Size = new System.Drawing.Size(157, 62);
            this.btn_removeTopic.TabIndex = 15;
            this.btn_removeTopic.Text = "Remove";
            this.btn_removeTopic.UseVisualStyleBackColor = true;
            this.btn_removeTopic.Click += new System.EventHandler(this.btn_removeTopic_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView_topic.AllowUserToAddRows = false;
            this.dataGridView_topic.AllowUserToDeleteRows = false;
            this.dataGridView_topic.AllowUserToOrderColumns = true;
            this.dataGridView_topic.AllowUserToResizeRows = false;
            this.dataGridView_topic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_topic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_topic.Location = new System.Drawing.Point(975, 53);
            this.dataGridView_topic.MultiSelect = false;
            this.dataGridView_topic.Name = "dataGridView1";
            this.dataGridView_topic.ReadOnly = true;
            this.dataGridView_topic.RowHeadersVisible = false;
            this.dataGridView_topic.RowTemplate.Height = 33;
            this.dataGridView_topic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_topic.Size = new System.Drawing.Size(542, 837);
            this.dataGridView_topic.TabIndex = 16;
            // 
            // LaunchConference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 930);
            this.Controls.Add(this.dataGridView_topic);
            this.Controls.Add(this.btn_removeTopic);
            this.Controls.Add(this.btn_addTopic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox_selectedTopic);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.dateTimePicker_deadline);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_begin);
            this.Controls.Add(this.textBox_location);
            this.Controls.Add(this.textBox_title);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LaunchConference";
            this.Text = "LaunchConference";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_topic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.TextBox textBox_location;
        private System.Windows.Forms.DateTimePicker dateTimePicker_begin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DateTimePicker dateTimePicker_deadline;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.ListBox listBox_selectedTopic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_addTopic;
        private System.Windows.Forms.Button btn_removeTopic;
        private System.Windows.Forms.DataGridView dataGridView_topic;
    }
}