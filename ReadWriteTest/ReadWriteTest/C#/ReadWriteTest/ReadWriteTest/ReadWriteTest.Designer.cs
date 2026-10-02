namespace ReadWriteTest
{
    partial class ReadWriteTest
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CBB_ACCESS_READ = new System.Windows.Forms.ComboBox();
            this.CBB_RWSIZE_READ = new System.Windows.Forms.ComboBox();
            this.TXB_COMMAND_READ = new System.Windows.Forms.TextBox();
            this.BTN_READ = new System.Windows.Forms.Button();
            this.CBB_ACCESS_WRITE = new System.Windows.Forms.ComboBox();
            this.CBB_RWSIZE_WRITE = new System.Windows.Forms.ComboBox();
            this.TXB_COMMAND_WRITE = new System.Windows.Forms.TextBox();
            this.TXB_DATA_WRITE = new System.Windows.Forms.TextBox();
            this.BTN_WRITE = new System.Windows.Forms.Button();
            this.TXB_LOG = new System.Windows.Forms.TextBox();
            this.LBL_COMMAND_READ = new System.Windows.Forms.Label();
            this.LBL_COMMAND_WRITE = new System.Windows.Forms.Label();
            this.LBL_DATA_WRITE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CBB_ACCESS_READ
            // 
            this.CBB_ACCESS_READ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBB_ACCESS_READ.FormattingEnabled = true;
            this.CBB_ACCESS_READ.Items.AddRange(new object[] {
            "IOPORT",
            "MEMORY"});
            this.CBB_ACCESS_READ.Location = new System.Drawing.Point(12, 14);
            this.CBB_ACCESS_READ.Name = "CBB_ACCESS_READ";
            this.CBB_ACCESS_READ.Size = new System.Drawing.Size(121, 21);
            this.CBB_ACCESS_READ.TabIndex = 0;
            // 
            // CBB_RWSIZE_READ
            // 
            this.CBB_RWSIZE_READ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBB_RWSIZE_READ.FormattingEnabled = true;
            this.CBB_RWSIZE_READ.Items.AddRange(new object[] {
            "BYTE",
            "WORD",
            "DWORD"});
            this.CBB_RWSIZE_READ.Location = new System.Drawing.Point(139, 14);
            this.CBB_RWSIZE_READ.Name = "CBB_RWSIZE_READ";
            this.CBB_RWSIZE_READ.Size = new System.Drawing.Size(121, 21);
            this.CBB_RWSIZE_READ.TabIndex = 1;
            // 
            // TXB_COMMAND_READ
            // 
            this.TXB_COMMAND_READ.Location = new System.Drawing.Point(347, 14);
            this.TXB_COMMAND_READ.Name = "TXB_COMMAND_READ";
            this.TXB_COMMAND_READ.Size = new System.Drawing.Size(100, 20);
            this.TXB_COMMAND_READ.TabIndex = 2;
            // 
            // BTN_READ
            // 
            this.BTN_READ.Location = new System.Drawing.Point(453, 12);
            this.BTN_READ.Name = "BTN_READ";
            this.BTN_READ.Size = new System.Drawing.Size(75, 23);
            this.BTN_READ.TabIndex = 3;
            this.BTN_READ.Text = "READ";
            this.BTN_READ.UseVisualStyleBackColor = true;
            this.BTN_READ.Click += new System.EventHandler(this.BTN_READ_Click);
            // 
            // CBB_ACCESS_WRITE
            // 
            this.CBB_ACCESS_WRITE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBB_ACCESS_WRITE.FormattingEnabled = true;
            this.CBB_ACCESS_WRITE.Items.AddRange(new object[] {
            "IOPORT",
            "MEMORY"});
            this.CBB_ACCESS_WRITE.Location = new System.Drawing.Point(12, 43);
            this.CBB_ACCESS_WRITE.Name = "CBB_ACCESS_WRITE";
            this.CBB_ACCESS_WRITE.Size = new System.Drawing.Size(121, 21);
            this.CBB_ACCESS_WRITE.TabIndex = 4;
            // 
            // CBB_RWSIZE_WRITE
            // 
            this.CBB_RWSIZE_WRITE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBB_RWSIZE_WRITE.FormattingEnabled = true;
            this.CBB_RWSIZE_WRITE.Items.AddRange(new object[] {
            "BYTE",
            "WORD",
            "DWORD"});
            this.CBB_RWSIZE_WRITE.Location = new System.Drawing.Point(139, 43);
            this.CBB_RWSIZE_WRITE.Name = "CBB_RWSIZE_WRITE";
            this.CBB_RWSIZE_WRITE.Size = new System.Drawing.Size(121, 21);
            this.CBB_RWSIZE_WRITE.TabIndex = 5;
            // 
            // TXB_COMMAND_WRITE
            // 
            this.TXB_COMMAND_WRITE.Location = new System.Drawing.Point(347, 43);
            this.TXB_COMMAND_WRITE.Name = "TXB_COMMAND_WRITE";
            this.TXB_COMMAND_WRITE.Size = new System.Drawing.Size(100, 20);
            this.TXB_COMMAND_WRITE.TabIndex = 6;
            // 
            // TXB_DATA_WRITE
            // 
            this.TXB_DATA_WRITE.Location = new System.Drawing.Point(507, 43);
            this.TXB_DATA_WRITE.Name = "TXB_DATA_WRITE";
            this.TXB_DATA_WRITE.Size = new System.Drawing.Size(100, 20);
            this.TXB_DATA_WRITE.TabIndex = 7;
            // 
            // BTN_WRITE
            // 
            this.BTN_WRITE.Location = new System.Drawing.Point(613, 41);
            this.BTN_WRITE.Name = "BTN_WRITE";
            this.BTN_WRITE.Size = new System.Drawing.Size(75, 23);
            this.BTN_WRITE.TabIndex = 8;
            this.BTN_WRITE.Text = "WRITE";
            this.BTN_WRITE.UseVisualStyleBackColor = true;
            this.BTN_WRITE.Click += new System.EventHandler(this.BTN_WRITE_Click);
            // 
            // TXB_LOG
            // 
            this.TXB_LOG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXB_LOG.Location = new System.Drawing.Point(12, 70);
            this.TXB_LOG.Multiline = true;
            this.TXB_LOG.Name = "TXB_LOG";
            this.TXB_LOG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TXB_LOG.Size = new System.Drawing.Size(676, 416);
            this.TXB_LOG.TabIndex = 9;
            // 
            // LBL_COMMAND_READ
            // 
            this.LBL_COMMAND_READ.AutoSize = true;
            this.LBL_COMMAND_READ.Location = new System.Drawing.Point(266, 17);
            this.LBL_COMMAND_READ.Name = "LBL_COMMAND_READ";
            this.LBL_COMMAND_READ.Size = new System.Drawing.Size(75, 13);
            this.LBL_COMMAND_READ.TabIndex = 10;
            this.LBL_COMMAND_READ.Text = "COMMAND(h)";
            // 
            // LBL_COMMAND_WRITE
            // 
            this.LBL_COMMAND_WRITE.AutoSize = true;
            this.LBL_COMMAND_WRITE.Location = new System.Drawing.Point(266, 46);
            this.LBL_COMMAND_WRITE.Name = "LBL_COMMAND_WRITE";
            this.LBL_COMMAND_WRITE.Size = new System.Drawing.Size(75, 13);
            this.LBL_COMMAND_WRITE.TabIndex = 10;
            this.LBL_COMMAND_WRITE.Text = "COMMAND(h)";
            // 
            // LBL_DATA_WRITE
            // 
            this.LBL_DATA_WRITE.AutoSize = true;
            this.LBL_DATA_WRITE.Location = new System.Drawing.Point(453, 46);
            this.LBL_DATA_WRITE.Name = "LBL_DATA_WRITE";
            this.LBL_DATA_WRITE.Size = new System.Drawing.Size(48, 13);
            this.LBL_DATA_WRITE.TabIndex = 10;
            this.LBL_DATA_WRITE.Text = "DATA(h)";
            // 
            // ReadWriteTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 498);
            this.Controls.Add(this.LBL_DATA_WRITE);
            this.Controls.Add(this.LBL_COMMAND_WRITE);
            this.Controls.Add(this.LBL_COMMAND_READ);
            this.Controls.Add(this.TXB_LOG);
            this.Controls.Add(this.BTN_WRITE);
            this.Controls.Add(this.TXB_DATA_WRITE);
            this.Controls.Add(this.TXB_COMMAND_WRITE);
            this.Controls.Add(this.CBB_RWSIZE_WRITE);
            this.Controls.Add(this.CBB_ACCESS_WRITE);
            this.Controls.Add(this.BTN_READ);
            this.Controls.Add(this.TXB_COMMAND_READ);
            this.Controls.Add(this.CBB_RWSIZE_READ);
            this.Controls.Add(this.CBB_ACCESS_READ);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReadWriteTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Read Write Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReadWriteTest_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBB_ACCESS_READ;
        private System.Windows.Forms.ComboBox CBB_RWSIZE_READ;
        private System.Windows.Forms.TextBox TXB_COMMAND_READ;
        private System.Windows.Forms.Button BTN_READ;
        private System.Windows.Forms.ComboBox CBB_ACCESS_WRITE;
        private System.Windows.Forms.ComboBox CBB_RWSIZE_WRITE;
        private System.Windows.Forms.TextBox TXB_COMMAND_WRITE;
        private System.Windows.Forms.TextBox TXB_DATA_WRITE;
        private System.Windows.Forms.Button BTN_WRITE;
        private System.Windows.Forms.TextBox TXB_LOG;
        private System.Windows.Forms.Label LBL_COMMAND_READ;
        private System.Windows.Forms.Label LBL_COMMAND_WRITE;
        private System.Windows.Forms.Label LBL_DATA_WRITE;
    }
}

