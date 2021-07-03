namespace CMS
{
    partial class AssignPaperForm
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
            this.btn_addReviewer = new System.Windows.Forms.Button();
            this.dataGridView_paper = new System.Windows.Forms.DataGridView();
            this.dataGridView_reviewer = new System.Windows.Forms.DataGridView();
            this.dataGridView_reviewerExpertise = new System.Windows.Forms.DataGridView();
            this.dataGridView_assignedReviewer = new System.Windows.Forms.DataGridView();
            this.listBox_reviewer = new System.Windows.Forms.ListBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_rmvReviewer = new System.Windows.Forms.Button();
            this.btn_changeRviewer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_conference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reviewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reviewerExpertise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_assignedReviewer)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView_conference.AllowUserToAddRows = false;
            this.dataGridView_conference.AllowUserToDeleteRows = false;
            this.dataGridView_conference.AllowUserToResizeRows = false;
            this.dataGridView_conference.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_conference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_conference.Location = new System.Drawing.Point(14, 70);
            this.dataGridView_conference.MultiSelect = false;
            this.dataGridView_conference.Name = "dataGridView1";
            this.dataGridView_conference.ReadOnly = true;
            this.dataGridView_conference.RowHeadersVisible = false;
            this.dataGridView_conference.RowTemplate.Height = 33;
            this.dataGridView_conference.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_conference.Size = new System.Drawing.Size(1668, 269);
            this.dataGridView_conference.TabIndex = 0;
            this.dataGridView_conference.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_conference_CellClick);
            // 
            // btn_addReviewer
            // 
            this.btn_addReviewer.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addReviewer.Location = new System.Drawing.Point(1459, 805);
            this.btn_addReviewer.Name = "btn_addReviewer";
            this.btn_addReviewer.Size = new System.Drawing.Size(232, 84);
            this.btn_addReviewer.TabIndex = 1;
            this.btn_addReviewer.Text = "Assign";
            this.btn_addReviewer.UseVisualStyleBackColor = true;
            this.btn_addReviewer.Click += new System.EventHandler(this.btn_addReviewer_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView_paper.AllowUserToAddRows = false;
            this.dataGridView_paper.AllowUserToDeleteRows = false;
            this.dataGridView_paper.AllowUserToResizeRows = false;
            this.dataGridView_paper.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_paper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_paper.Location = new System.Drawing.Point(20, 417);
            this.dataGridView_paper.MultiSelect = false;
            this.dataGridView_paper.Name = "dataGridView2";
            this.dataGridView_paper.ReadOnly = true;
            this.dataGridView_paper.RowHeadersVisible = false;
            this.dataGridView_paper.RowTemplate.Height = 33;
            this.dataGridView_paper.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_paper.Size = new System.Drawing.Size(951, 309);
            this.dataGridView_paper.TabIndex = 2;
            this.dataGridView_paper.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_paper_CellClick);
            // 
            // dataGridView3
            // 
            this.dataGridView_reviewer.AllowUserToAddRows = false;
            this.dataGridView_reviewer.AllowUserToDeleteRows = false;
            this.dataGridView_reviewer.AllowUserToResizeRows = false;
            this.dataGridView_reviewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_reviewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reviewer.EnableHeadersVisualStyles = false;
            this.dataGridView_reviewer.Location = new System.Drawing.Point(20, 805);
            this.dataGridView_reviewer.MultiSelect = false;
            this.dataGridView_reviewer.Name = "dataGridView3";
            this.dataGridView_reviewer.ReadOnly = true;
            this.dataGridView_reviewer.RowHeadersVisible = false;
            this.dataGridView_reviewer.RowTemplate.Height = 33;
            this.dataGridView_reviewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_reviewer.Size = new System.Drawing.Size(372, 332);
            this.dataGridView_reviewer.TabIndex = 3;
            this.dataGridView_reviewer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_reviewer_CellClick);
            // 
            // dataGridView4
            // 
            this.dataGridView_reviewerExpertise.AllowUserToAddRows = false;
            this.dataGridView_reviewerExpertise.AllowUserToDeleteRows = false;
            this.dataGridView_reviewerExpertise.AllowUserToResizeRows = false;
            this.dataGridView_reviewerExpertise.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_reviewerExpertise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reviewerExpertise.Location = new System.Drawing.Point(398, 805);
            this.dataGridView_reviewerExpertise.MultiSelect = false;
            this.dataGridView_reviewerExpertise.Name = "dataGridView4";
            this.dataGridView_reviewerExpertise.ReadOnly = true;
            this.dataGridView_reviewerExpertise.RowHeadersVisible = false;
            this.dataGridView_reviewerExpertise.RowTemplate.Height = 33;
            this.dataGridView_reviewerExpertise.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_reviewerExpertise.Size = new System.Drawing.Size(573, 332);
            this.dataGridView_reviewerExpertise.TabIndex = 4;
            // 
            // dataGridView5
            // 
            this.dataGridView_assignedReviewer.AllowUserToAddRows = false;
            this.dataGridView_assignedReviewer.AllowUserToDeleteRows = false;
            this.dataGridView_assignedReviewer.AllowUserToResizeRows = false;
            this.dataGridView_assignedReviewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_assignedReviewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_assignedReviewer.Location = new System.Drawing.Point(1004, 417);
            this.dataGridView_assignedReviewer.MultiSelect = false;
            this.dataGridView_assignedReviewer.Name = "dataGridView5";
            this.dataGridView_assignedReviewer.ReadOnly = true;
            this.dataGridView_assignedReviewer.RowHeadersVisible = false;
            this.dataGridView_assignedReviewer.RowTemplate.Height = 33;
            this.dataGridView_assignedReviewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_assignedReviewer.Size = new System.Drawing.Size(390, 309);
            this.dataGridView_assignedReviewer.TabIndex = 5;
            // 
            // listBox_reviewer
            // 
            this.listBox_reviewer.FormattingEnabled = true;
            this.listBox_reviewer.ItemHeight = 25;
            this.listBox_reviewer.Location = new System.Drawing.Point(1004, 805);
            this.listBox_reviewer.Name = "listBox_reviewer";
            this.listBox_reviewer.Size = new System.Drawing.Size(390, 329);
            this.listBox_reviewer.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(1459, 1050);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(232, 84);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_rmvReviewer
            // 
            this.btn_rmvReviewer.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rmvReviewer.Location = new System.Drawing.Point(1459, 915);
            this.btn_rmvReviewer.Name = "btn_rmvReviewer";
            this.btn_rmvReviewer.Size = new System.Drawing.Size(232, 84);
            this.btn_rmvReviewer.TabIndex = 9;
            this.btn_rmvReviewer.Text = "remove";
            this.btn_rmvReviewer.UseVisualStyleBackColor = true;
            this.btn_rmvReviewer.Click += new System.EventHandler(this.btn_rmvReviewer_Click);
            // 
            // btn_changeRviewer
            // 
            this.btn_changeRviewer.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_changeRviewer.Location = new System.Drawing.Point(1451, 391);
            this.btn_changeRviewer.Name = "btn_changeRviewer";
            this.btn_changeRviewer.Size = new System.Drawing.Size(232, 84);
            this.btn_changeRviewer.TabIndex = 10;
            this.btn_changeRviewer.Text = "Change";
            this.btn_changeRviewer.UseVisualStyleBackColor = true;
            this.btn_changeRviewer.Click += new System.EventHandler(this.btn_changeRviewer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 41);
            this.label1.TabIndex = 11;
            this.label1.Text = "Conference";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 41);
            this.label2.TabIndex = 12;
            this.label2.Text = "Papers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(995, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 41);
            this.label3.TabIndex = 13;
            this.label3.Text = "Assigned Reviewers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 761);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 41);
            this.label4.TabIndex = 14;
            this.label4.Text = "Reviewers";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(391, 761);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 41);
            this.label5.TabIndex = 15;
            this.label5.Text = "Reviewer Expertise";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(997, 761);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 41);
            this.label6.TabIndex = 16;
            this.label6.Text = "Assigned List";
            // 
            // AssignPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1845, 1230);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_changeRviewer);
            this.Controls.Add(this.btn_rmvReviewer);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.listBox_reviewer);
            this.Controls.Add(this.dataGridView_assignedReviewer);
            this.Controls.Add(this.dataGridView_reviewerExpertise);
            this.Controls.Add(this.dataGridView_reviewer);
            this.Controls.Add(this.dataGridView_paper);
            this.Controls.Add(this.btn_addReviewer);
            this.Controls.Add(this.dataGridView_conference);
            this.Name = "AssignPaper";
            this.Text = "ReviewPaper";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_conference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reviewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reviewerExpertise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_assignedReviewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_conference;
        private System.Windows.Forms.Button btn_addReviewer;
        private System.Windows.Forms.DataGridView dataGridView_paper;
        private System.Windows.Forms.DataGridView dataGridView_reviewer;
        private System.Windows.Forms.DataGridView dataGridView_reviewerExpertise;
        private System.Windows.Forms.DataGridView dataGridView_assignedReviewer;
        private System.Windows.Forms.ListBox listBox_reviewer;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_rmvReviewer;
        private System.Windows.Forms.Button btn_changeRviewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}