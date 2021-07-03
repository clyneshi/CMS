namespace CMS
{
    partial class ConferenceInfo
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
            this.dataGridView_paper = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_conference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paper)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView_conference.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_conference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_conference.Location = new System.Drawing.Point(12, 90);
            this.dataGridView_conference.Name = "dataGridView1";
            this.dataGridView_conference.RowHeadersVisible = false;
            this.dataGridView_conference.RowTemplate.Height = 33;
            this.dataGridView_conference.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_conference.Size = new System.Drawing.Size(585, 294);
            this.dataGridView_conference.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView_paper.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_paper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_paper.Location = new System.Drawing.Point(12, 501);
            this.dataGridView_paper.Name = "dataGridView2";
            this.dataGridView_paper.RowHeadersVisible = false;
            this.dataGridView_paper.RowTemplate.Height = 33;
            this.dataGridView_paper.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_paper.Size = new System.Drawing.Size(1256, 258);
            this.dataGridView_paper.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Conference Members";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Papers";
            // 
            // ConferenceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 860);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_paper);
            this.Controls.Add(this.dataGridView_conference);
            this.Name = "ConferenceInfo";
            this.Text = "ConferenceInfo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_conference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_conference;
        private System.Windows.Forms.DataGridView dataGridView_paper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}