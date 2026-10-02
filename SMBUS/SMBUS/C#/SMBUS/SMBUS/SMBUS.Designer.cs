namespace SMBUS
{
    partial class SMBUS
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
            this.LBL_DATA_WRITE = new System.Windows.Forms.Label();
            this.LBL_REGISTER_WRITE = new System.Windows.Forms.Label();
            this.LBL_REGISTER_READ = new System.Windows.Forms.Label();
            this.TXB_LOG = new System.Windows.Forms.TextBox();
            this.BTN_WRITE = new System.Windows.Forms.Button();
            this.TXB_DATA_WRITE = new System.Windows.Forms.TextBox();
            this.TXB_REGISTER_WRITE = new System.Windows.Forms.TextBox();
            this.CBB_RWSIZE_WRITE = new System.Windows.Forms.ComboBox();
            this.BTN_READ = new System.Windows.Forms.Button();
            this.TXB_REGISTER_READ = new System.Windows.Forms.TextBox();
            this.CBB_RWSIZE_READ = new System.Windows.Forms.ComboBox();
            this.LBL_ADDRESS_READ = new System.Windows.Forms.Label();
            this.TXB_ADDRESS_READ = new System.Windows.Forms.TextBox();
            this.LBL_ADDRESS_WRITE = new System.Windows.Forms.Label();
            this.TXB_ADDRESS_WRITE = new System.Windows.Forms.TextBox();
            this.BTN_CheckStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_DATA_WRITE
            // 
            this.LBL_DATA_WRITE.AutoSize = true;
            this.LBL_DATA_WRITE.Location = new System.Drawing.Point(508, 42);
            this.LBL_DATA_WRITE.Name = "LBL_DATA_WRITE";
            this.LBL_DATA_WRITE.Size = new System.Drawing.Size(50, 12);
            this.LBL_DATA_WRITE.TabIndex = 0;
            this.LBL_DATA_WRITE.Text = "DATA(h)";
            // 
            // LBL_REGISTER_WRITE
            // 
            this.LBL_REGISTER_WRITE.AutoSize = true;
            this.LBL_REGISTER_WRITE.Location = new System.Drawing.Point(321, 42);
            this.LBL_REGISTER_WRITE.Name = "LBL_REGISTER_WRITE";
            this.LBL_REGISTER_WRITE.Size = new System.Drawing.Size(74, 12);
            this.LBL_REGISTER_WRITE.TabIndex = 0;
            this.LBL_REGISTER_WRITE.Text = "REGISTER(h)";
            // 
            // LBL_REGISTER_READ
            // 
            this.LBL_REGISTER_READ.AutoSize = true;
            this.LBL_REGISTER_READ.Location = new System.Drawing.Point(321, 15);
            this.LBL_REGISTER_READ.Name = "LBL_REGISTER_READ";
            this.LBL_REGISTER_READ.Size = new System.Drawing.Size(74, 12);
            this.LBL_REGISTER_READ.TabIndex = 0;
            this.LBL_REGISTER_READ.Text = "REGISTER(h)";
            // 
            // TXB_LOG
            // 
            this.TXB_LOG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXB_LOG.Location = new System.Drawing.Point(12, 65);
            this.TXB_LOG.Multiline = true;
            this.TXB_LOG.Name = "TXB_LOG";
            this.TXB_LOG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TXB_LOG.Size = new System.Drawing.Size(731, 384);
            this.TXB_LOG.TabIndex = 10;
            // 
            // BTN_WRITE
            // 
            this.BTN_WRITE.Location = new System.Drawing.Point(668, 38);
            this.BTN_WRITE.Name = "BTN_WRITE";
            this.BTN_WRITE.Size = new System.Drawing.Size(75, 21);
            this.BTN_WRITE.TabIndex = 9;
            this.BTN_WRITE.Text = "WRITE";
            this.BTN_WRITE.UseVisualStyleBackColor = true;
            this.BTN_WRITE.Click += new System.EventHandler(this.BTN_WRITE_Click);
            // 
            // TXB_DATA_WRITE
            // 
            this.TXB_DATA_WRITE.Location = new System.Drawing.Point(562, 40);
            this.TXB_DATA_WRITE.Name = "TXB_DATA_WRITE";
            this.TXB_DATA_WRITE.Size = new System.Drawing.Size(100, 22);
            this.TXB_DATA_WRITE.TabIndex = 8;
            // 
            // TXB_REGISTER_WRITE
            // 
            this.TXB_REGISTER_WRITE.Location = new System.Drawing.Point(402, 40);
            this.TXB_REGISTER_WRITE.Name = "TXB_REGISTER_WRITE";
            this.TXB_REGISTER_WRITE.Size = new System.Drawing.Size(100, 22);
            this.TXB_REGISTER_WRITE.TabIndex = 7;
            // 
            // CBB_RWSIZE_WRITE
            // 
            this.CBB_RWSIZE_WRITE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBB_RWSIZE_WRITE.FormattingEnabled = true;
            this.CBB_RWSIZE_WRITE.Items.AddRange(new object[] {
            "BYTE",
            "WORD",
            "DWORD"});
            this.CBB_RWSIZE_WRITE.Location = new System.Drawing.Point(12, 39);
            this.CBB_RWSIZE_WRITE.Name = "CBB_RWSIZE_WRITE";
            this.CBB_RWSIZE_WRITE.Size = new System.Drawing.Size(121, 20);
            this.CBB_RWSIZE_WRITE.TabIndex = 5;
            // 
            // BTN_READ
            // 
            this.BTN_READ.Location = new System.Drawing.Point(507, 12);
            this.BTN_READ.Name = "BTN_READ";
            this.BTN_READ.Size = new System.Drawing.Size(75, 21);
            this.BTN_READ.TabIndex = 4;
            this.BTN_READ.Text = "READ";
            this.BTN_READ.UseVisualStyleBackColor = true;
            this.BTN_READ.Click += new System.EventHandler(this.BTN_READ_Click);
            // 
            // TXB_REGISTER_READ
            // 
            this.TXB_REGISTER_READ.Location = new System.Drawing.Point(401, 12);
            this.TXB_REGISTER_READ.Name = "TXB_REGISTER_READ";
            this.TXB_REGISTER_READ.Size = new System.Drawing.Size(100, 22);
            this.TXB_REGISTER_READ.TabIndex = 3;
            // 
            // CBB_RWSIZE_READ
            // 
            this.CBB_RWSIZE_READ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBB_RWSIZE_READ.FormattingEnabled = true;
            this.CBB_RWSIZE_READ.Items.AddRange(new object[] {
            "BYTE",
            "WORD",
            "DWORD"});
            this.CBB_RWSIZE_READ.Location = new System.Drawing.Point(12, 12);
            this.CBB_RWSIZE_READ.Name = "CBB_RWSIZE_READ";
            this.CBB_RWSIZE_READ.Size = new System.Drawing.Size(121, 20);
            this.CBB_RWSIZE_READ.TabIndex = 1;
            // 
            // LBL_ADDRESS_READ
            // 
            this.LBL_ADDRESS_READ.AutoSize = true;
            this.LBL_ADDRESS_READ.Location = new System.Drawing.Point(139, 15);
            this.LBL_ADDRESS_READ.Name = "LBL_ADDRESS_READ";
            this.LBL_ADDRESS_READ.Size = new System.Drawing.Size(70, 12);
            this.LBL_ADDRESS_READ.TabIndex = 0;
            this.LBL_ADDRESS_READ.Text = "ADDRESS(h)";
            // 
            // TXB_ADDRESS_READ
            // 
            this.TXB_ADDRESS_READ.Location = new System.Drawing.Point(215, 12);
            this.TXB_ADDRESS_READ.Name = "TXB_ADDRESS_READ";
            this.TXB_ADDRESS_READ.Size = new System.Drawing.Size(100, 22);
            this.TXB_ADDRESS_READ.TabIndex = 2;
            // 
            // LBL_ADDRESS_WRITE
            // 
            this.LBL_ADDRESS_WRITE.AutoSize = true;
            this.LBL_ADDRESS_WRITE.Location = new System.Drawing.Point(139, 42);
            this.LBL_ADDRESS_WRITE.Name = "LBL_ADDRESS_WRITE";
            this.LBL_ADDRESS_WRITE.Size = new System.Drawing.Size(70, 12);
            this.LBL_ADDRESS_WRITE.TabIndex = 0;
            this.LBL_ADDRESS_WRITE.Text = "ADDRESS(h)";
            // 
            // TXB_ADDRESS_WRITE
            // 
            this.TXB_ADDRESS_WRITE.Location = new System.Drawing.Point(215, 40);
            this.TXB_ADDRESS_WRITE.Name = "TXB_ADDRESS_WRITE";
            this.TXB_ADDRESS_WRITE.Size = new System.Drawing.Size(100, 22);
            this.TXB_ADDRESS_WRITE.TabIndex = 6;
            // 
            // BTN_CheckStatus
            // 
            this.BTN_CheckStatus.Location = new System.Drawing.Point(588, 12);
            this.BTN_CheckStatus.Name = "BTN_CheckStatus";
            this.BTN_CheckStatus.Size = new System.Drawing.Size(155, 23);
            this.BTN_CheckStatus.TabIndex = 0;
            this.BTN_CheckStatus.Text = "CHECK STATUS";
            this.BTN_CheckStatus.UseVisualStyleBackColor = true;
            this.BTN_CheckStatus.Click += new System.EventHandler(this.BTN_CheckStatus_Click);
            // 
            // SMBUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 460);
            this.Controls.Add(this.BTN_CheckStatus);
            this.Controls.Add(this.LBL_ADDRESS_WRITE);
            this.Controls.Add(this.TXB_ADDRESS_WRITE);
            this.Controls.Add(this.LBL_ADDRESS_READ);
            this.Controls.Add(this.TXB_ADDRESS_READ);
            this.Controls.Add(this.LBL_DATA_WRITE);
            this.Controls.Add(this.LBL_REGISTER_WRITE);
            this.Controls.Add(this.LBL_REGISTER_READ);
            this.Controls.Add(this.TXB_LOG);
            this.Controls.Add(this.BTN_WRITE);
            this.Controls.Add(this.TXB_DATA_WRITE);
            this.Controls.Add(this.TXB_REGISTER_WRITE);
            this.Controls.Add(this.CBB_RWSIZE_WRITE);
            this.Controls.Add(this.BTN_READ);
            this.Controls.Add(this.TXB_REGISTER_READ);
            this.Controls.Add(this.CBB_RWSIZE_READ);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SMBUS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBUS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SMBUS_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_DATA_WRITE;
        private System.Windows.Forms.Label LBL_REGISTER_WRITE;
        private System.Windows.Forms.Label LBL_REGISTER_READ;
        private System.Windows.Forms.TextBox TXB_LOG;
        private System.Windows.Forms.Button BTN_WRITE;
        private System.Windows.Forms.TextBox TXB_DATA_WRITE;
        private System.Windows.Forms.TextBox TXB_REGISTER_WRITE;
        private System.Windows.Forms.ComboBox CBB_RWSIZE_WRITE;
        private System.Windows.Forms.Button BTN_READ;
        private System.Windows.Forms.TextBox TXB_REGISTER_READ;
        private System.Windows.Forms.ComboBox CBB_RWSIZE_READ;
        private System.Windows.Forms.Label LBL_ADDRESS_READ;
        private System.Windows.Forms.TextBox TXB_ADDRESS_READ;
        private System.Windows.Forms.Label LBL_ADDRESS_WRITE;
        private System.Windows.Forms.TextBox TXB_ADDRESS_WRITE;
        private System.Windows.Forms.Button BTN_CheckStatus;
    }
}

