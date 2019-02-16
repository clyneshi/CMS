namespace CMS
{
    partial class SubmitPaper
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_paperTitle = new System.Windows.Forms.TextBox();
            this.textBox_author = new System.Windows.Forms.TextBox();
            this.comboBox_paperLength = new System.Windows.Forms.ComboBox();
            this.textBox_filePath = new System.Windows.Forms.TextBox();
            this.btn_uploadPaper = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_keyword = new System.Windows.Forms.ListBox();
            this.btn_keyAdd = new System.Windows.Forms.Button();
            this.btn_keyRmv = new System.Windows.Forms.Button();
            this.btn_savePaper = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(178, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(232, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(179, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 41);
            this.label4.TabIndex = 3;
            this.label4.Text = "Length";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(833, 152);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 684);
            this.dataGridView1.TabIndex = 4;
            // 
            // textBox_paperTitle
            // 
            this.textBox_paperTitle.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_paperTitle.Location = new System.Drawing.Point(325, 152);
            this.textBox_paperTitle.Name = "textBox_paperTitle";
            this.textBox_paperTitle.Size = new System.Drawing.Size(426, 50);
            this.textBox_paperTitle.TabIndex = 5;
            // 
            // textBox_author
            // 
            this.textBox_author.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_author.Location = new System.Drawing.Point(325, 219);
            this.textBox_author.Name = "textBox_author";
            this.textBox_author.Size = new System.Drawing.Size(426, 50);
            this.textBox_author.TabIndex = 6;
            // 
            // comboBox_paperLength
            // 
            this.comboBox_paperLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_paperLength.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_paperLength.FormattingEnabled = true;
            this.comboBox_paperLength.Items.AddRange(new object[] {
            "Short",
            "Long"});
            this.comboBox_paperLength.Location = new System.Drawing.Point(325, 288);
            this.comboBox_paperLength.Name = "comboBox_paperLength";
            this.comboBox_paperLength.Size = new System.Drawing.Size(426, 49);
            this.comboBox_paperLength.TabIndex = 7;
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.Enabled = false;
            this.textBox_filePath.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_filePath.Location = new System.Drawing.Point(325, 354);
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.Size = new System.Drawing.Size(252, 50);
            this.textBox_filePath.TabIndex = 8;
            // 
            // btn_uploadPaper
            // 
            this.btn_uploadPaper.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_uploadPaper.Location = new System.Drawing.Point(600, 350);
            this.btn_uploadPaper.Name = "btn_uploadPaper";
            this.btn_uploadPaper.Size = new System.Drawing.Size(151, 55);
            this.btn_uploadPaper.TabIndex = 9;
            this.btn_uploadPaper.Text = "Upload";
            this.btn_uploadPaper.UseVisualStyleBackColor = true;
            this.btn_uploadPaper.Click += new System.EventHandler(this.btn_uploadPaper_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text Files|*.txt|PDF|*.pdf|WORD|*.doc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(129, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 41);
            this.label5.TabIndex = 10;
            this.label5.Text = "Key words";
            // 
            // listBox_keyword
            // 
            this.listBox_keyword.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_keyword.FormattingEnabled = true;
            this.listBox_keyword.ItemHeight = 41;
            this.listBox_keyword.Location = new System.Drawing.Point(334, 427);
            this.listBox_keyword.Name = "listBox_keyword";
            this.listBox_keyword.Size = new System.Drawing.Size(417, 250);
            this.listBox_keyword.TabIndex = 11;
            // 
            // btn_keyAdd
            // 
            this.btn_keyAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_keyAdd.Location = new System.Drawing.Point(172, 707);
            this.btn_keyAdd.Name = "btn_keyAdd";
            this.btn_keyAdd.Size = new System.Drawing.Size(286, 55);
            this.btn_keyAdd.TabIndex = 12;
            this.btn_keyAdd.Text = "add";
            this.btn_keyAdd.UseVisualStyleBackColor = true;
            this.btn_keyAdd.Click += new System.EventHandler(this.btn_keyAdd_Click);
            // 
            // btn_keyRmv
            // 
            this.btn_keyRmv.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_keyRmv.Location = new System.Drawing.Point(465, 707);
            this.btn_keyRmv.Name = "btn_keyRmv";
            this.btn_keyRmv.Size = new System.Drawing.Size(286, 55);
            this.btn_keyRmv.TabIndex = 13;
            this.btn_keyRmv.Text = "remove";
            this.btn_keyRmv.UseVisualStyleBackColor = true;
            this.btn_keyRmv.Click += new System.EventHandler(this.btn_keyRmv_Click);
            // 
            // btn_savePaper
            // 
            this.btn_savePaper.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_savePaper.Location = new System.Drawing.Point(172, 780);
            this.btn_savePaper.Name = "btn_savePaper";
            this.btn_savePaper.Size = new System.Drawing.Size(579, 56);
            this.btn_savePaper.TabIndex = 14;
            this.btn_savePaper.Text = "save";
            this.btn_savePaper.UseVisualStyleBackColor = true;
            this.btn_savePaper.Click += new System.EventHandler(this.btn_savePaper_Click);
            // 
            // SubmitPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1597, 975);
            this.Controls.Add(this.textBox_paperTitle);
            this.Controls.Add(this.btn_savePaper);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_paperLength);
            this.Controls.Add(this.btn_keyRmv);
            this.Controls.Add(this.textBox_filePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_author);
            this.Controls.Add(this.btn_keyAdd);
            this.Controls.Add(this.btn_uploadPaper);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox_keyword);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SubmitPaper";
            this.Text = "Submit";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_paperTitle;
        private System.Windows.Forms.TextBox textBox_author;
        private System.Windows.Forms.ComboBox comboBox_paperLength;
        private System.Windows.Forms.TextBox textBox_filePath;
        private System.Windows.Forms.Button btn_uploadPaper;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox_keyword;
        private System.Windows.Forms.Button btn_keyAdd;
        private System.Windows.Forms.Button btn_keyRmv;
        private System.Windows.Forms.Button btn_savePaper;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}