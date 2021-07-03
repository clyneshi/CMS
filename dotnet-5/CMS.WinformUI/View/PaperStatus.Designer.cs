namespace CMS
{
    partial class PaperStatus
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
            this.dataGridView_paper = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_feedback = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paper)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView_paper.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_paper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_paper.Location = new System.Drawing.Point(12, 63);
            this.dataGridView_paper.MultiSelect = false;
            this.dataGridView_paper.Name = "dataGridView1";
            this.dataGridView_paper.ReadOnly = true;
            this.dataGridView_paper.RowHeadersVisible = false;
            this.dataGridView_paper.RowTemplate.Height = 33;
            this.dataGridView_paper.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_paper.Size = new System.Drawing.Size(1308, 368);
            this.dataGridView_paper.TabIndex = 0;
            this.dataGridView_paper.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_paper_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paper";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "Feedback";
            // 
            // richTextBox_fb
            // 
            this.richTextBox_feedback.Location = new System.Drawing.Point(12, 518);
            this.richTextBox_feedback.Name = "richTextBox_fb";
            this.richTextBox_feedback.Size = new System.Drawing.Size(1308, 340);
            this.richTextBox_feedback.TabIndex = 3;
            this.richTextBox_feedback.Text = "";
            // 
            // PaperStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 934);
            this.Controls.Add(this.richTextBox_feedback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_paper);
            this.Name = "PaperStatus";
            this.Text = "PaperStatus";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_paper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_feedback;
    }
}