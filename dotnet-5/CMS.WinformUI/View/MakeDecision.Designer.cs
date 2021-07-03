namespace CMS
{
    partial class MakeDecision
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
            this.dataGridView_conference = new System.Windows.Forms.DataGridView();
            this.rtextbox_feedback = new System.Windows.Forms.RichTextBox();
            this.dataGridView_paper = new System.Windows.Forms.DataGridView();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.dataGridView_reviewer = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_conference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paper)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reviewer)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView_conference.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_conference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_conference.Location = new System.Drawing.Point(12, 59);
            this.dataGridView_conference.MultiSelect = false;
            this.dataGridView_conference.Name = "dataGridView1";
            this.dataGridView_conference.ReadOnly = true;
            this.dataGridView_conference.RowHeadersVisible = false;
            this.dataGridView_conference.RowTemplate.Height = 33;
            this.dataGridView_conference.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_conference.Size = new System.Drawing.Size(963, 460);
            this.dataGridView_conference.TabIndex = 0;
            this.dataGridView_conference.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_conference_CellClick);
            // 
            // rtextbox_feedback
            // 
            this.rtextbox_feedback.Location = new System.Drawing.Point(12, 576);
            this.rtextbox_feedback.Name = "rtextbox_feedback";
            this.rtextbox_feedback.Size = new System.Drawing.Size(963, 306);
            this.rtextbox_feedback.TabIndex = 1;
            this.rtextbox_feedback.Text = "";
            // 
            // dataGridView2
            // 
            this.dataGridView_paper.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_paper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_paper.Location = new System.Drawing.Point(1034, 59);
            this.dataGridView_paper.MultiSelect = false;
            this.dataGridView_paper.Name = "dataGridView2";
            this.dataGridView_paper.ReadOnly = true;
            this.dataGridView_paper.RowHeadersVisible = false;
            this.dataGridView_paper.RowTemplate.Height = 33;
            this.dataGridView_paper.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_paper.Size = new System.Drawing.Size(760, 460);
            this.dataGridView_paper.TabIndex = 2;
            this.dataGridView_paper.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_paper_CellClick);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(51, 63);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 29);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Accept";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(196, 63);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(115, 29);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Decline";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(12, 905);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 133);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 1062);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(174, 64);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView_reviewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_reviewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reviewer.Location = new System.Drawing.Point(1034, 576);
            this.dataGridView_reviewer.MultiSelect = false;
            this.dataGridView_reviewer.Name = "dataGridView3";
            this.dataGridView_reviewer.ReadOnly = true;
            this.dataGridView_reviewer.RowHeadersVisible = false;
            this.dataGridView_reviewer.RowTemplate.Height = 33;
            this.dataGridView_reviewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_reviewer.Size = new System.Drawing.Size(760, 306);
            this.dataGridView_reviewer.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 41);
            this.label1.TabIndex = 8;
            this.label1.Text = "Conference";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1039, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 41);
            this.label2.TabIndex = 9;
            this.label2.Text = "Papers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 41);
            this.label3.TabIndex = 10;
            this.label3.Text = "Feedback";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1039, 532);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 41);
            this.label4.TabIndex = 11;
            this.label4.Text = "Reviews";
            // 
            // MakeDicision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1860, 1168);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_reviewer);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_paper);
            this.Controls.Add(this.rtextbox_feedback);
            this.Controls.Add(this.dataGridView_conference);
            this.Name = "MakeDicision";
            this.Text = "Feedback";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_conference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paper)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reviewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_conference;
        private System.Windows.Forms.RichTextBox rtextbox_feedback;
        private System.Windows.Forms.DataGridView dataGridView_paper;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dataGridView_reviewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}