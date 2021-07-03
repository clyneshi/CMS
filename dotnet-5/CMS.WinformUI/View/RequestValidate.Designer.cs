namespace CMS
{
    partial class RequestValidate
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
            this.dataGridView_request = new System.Windows.Forms.DataGridView();
            this.btn_approve = new System.Windows.Forms.Button();
            this.btn_decline = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_request)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView_request.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_request.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_request.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_request.MultiSelect = false;
            this.dataGridView_request.Name = "dataGridView1";
            this.dataGridView_request.ReadOnly = true;
            this.dataGridView_request.RowHeadersVisible = false;
            this.dataGridView_request.RowTemplate.Height = 33;
            this.dataGridView_request.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_request.Size = new System.Drawing.Size(1564, 592);
            this.dataGridView_request.TabIndex = 0;
            // 
            // btn_approve
            // 
            this.btn_approve.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_approve.Location = new System.Drawing.Point(466, 666);
            this.btn_approve.Name = "btn_approve";
            this.btn_approve.Size = new System.Drawing.Size(177, 74);
            this.btn_approve.TabIndex = 1;
            this.btn_approve.Text = "Approve";
            this.btn_approve.UseVisualStyleBackColor = true;
            this.btn_approve.Click += new System.EventHandler(this.btn_approve_Click);
            // 
            // btn_decline
            // 
            this.btn_decline.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_decline.Location = new System.Drawing.Point(924, 666);
            this.btn_decline.Name = "btn_decline";
            this.btn_decline.Size = new System.Drawing.Size(177, 74);
            this.btn_decline.TabIndex = 2;
            this.btn_decline.Text = "Decline";
            this.btn_decline.UseVisualStyleBackColor = true;
            this.btn_decline.Click += new System.EventHandler(this.btn_decline_Click);
            // 
            // RequestValidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 930);
            this.Controls.Add(this.btn_decline);
            this.Controls.Add(this.btn_approve);
            this.Controls.Add(this.dataGridView_request);
            this.Name = "RequestValidate";
            this.Text = "RequestValidate";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_request)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_request;
        private System.Windows.Forms.Button btn_approve;
        private System.Windows.Forms.Button btn_decline;
    }
}