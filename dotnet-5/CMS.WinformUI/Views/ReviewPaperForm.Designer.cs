namespace CMS
{
    partial class ReviewPaperForm
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
            this.dataGridView_paperReview = new System.Windows.Forms.DataGridView();
            this.btn_rate = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paperReview)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView_paperReview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_paperReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_paperReview.Location = new System.Drawing.Point(3, 12);
            this.dataGridView_paperReview.MultiSelect = false;
            this.dataGridView_paperReview.Name = "dataGridView1";
            this.dataGridView_paperReview.ReadOnly = true;
            this.dataGridView_paperReview.RowHeadersVisible = false;
            this.dataGridView_paperReview.RowTemplate.Height = 33;
            this.dataGridView_paperReview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_paperReview.Size = new System.Drawing.Size(1040, 493);
            this.dataGridView_paperReview.TabIndex = 0;
            // 
            // button1
            // 
            this.btn_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rate.Location = new System.Drawing.Point(299, 552);
            this.btn_rate.Name = "button1";
            this.btn_rate.Size = new System.Drawing.Size(224, 65);
            this.btn_rate.TabIndex = 1;
            this.btn_rate.Text = "Rate";
            this.btn_rate.UseVisualStyleBackColor = true;
            this.btn_rate.Click += new System.EventHandler(this.btn_rate_Click);
            // 
            // button2
            // 
            this.btn_download.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_download.Location = new System.Drawing.Point(3, 550);
            this.btn_download.Name = "button2";
            this.btn_download.Size = new System.Drawing.Size(242, 65);
            this.btn_download.TabIndex = 2;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // ReviewPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 804);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_rate);
            this.Controls.Add(this.dataGridView_paperReview);
            this.Name = "ReviewPaper";
            this.Text = "ReviewPaper";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paperReview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_paperReview;
        private System.Windows.Forms.Button btn_rate;
        private System.Windows.Forms.Button btn_download;
    }
}