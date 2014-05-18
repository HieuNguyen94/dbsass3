namespace WorldCup
{
    partial class AdminForm
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
            this.lbUsername = new System.Windows.Forms.Label();
            this.tbTaiKhoan = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btWorldCup = new System.Windows.Forms.Button();
            this.btQuanLyDoiBong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(13, 13);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(63, 13);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "lbUsername";
            // 
            // tbTaiKhoan
            // 
            this.tbTaiKhoan.Location = new System.Drawing.Point(12, 39);
            this.tbTaiKhoan.Name = "tbTaiKhoan";
            this.tbTaiKhoan.Size = new System.Drawing.Size(75, 23);
            this.tbTaiKhoan.TabIndex = 1;
            this.tbTaiKhoan.Text = "Tài Khoản";
            this.tbTaiKhoan.UseVisualStyleBackColor = true;
            this.tbTaiKhoan.Click += new System.EventHandler(this.tbTaiKhoan_Click);
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(16, 82);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(559, 373);
            this.dgv.TabIndex = 2;
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            // 
            // btWorldCup
            // 
            this.btWorldCup.Location = new System.Drawing.Point(93, 39);
            this.btWorldCup.Name = "btWorldCup";
            this.btWorldCup.Size = new System.Drawing.Size(75, 23);
            this.btWorldCup.TabIndex = 3;
            this.btWorldCup.Text = "WorldCup";
            this.btWorldCup.UseVisualStyleBackColor = true;
            this.btWorldCup.Click += new System.EventHandler(this.btWorldCup_Click);
            // 
            // btQuanLyDoiBong
            // 
            this.btQuanLyDoiBong.Location = new System.Drawing.Point(174, 39);
            this.btQuanLyDoiBong.Name = "btQuanLyDoiBong";
            this.btQuanLyDoiBong.Size = new System.Drawing.Size(96, 23);
            this.btQuanLyDoiBong.TabIndex = 4;
            this.btQuanLyDoiBong.Text = "Quản lý đội bóng";
            this.btQuanLyDoiBong.UseVisualStyleBackColor = true;
            this.btQuanLyDoiBong.Click += new System.EventHandler(this.btQuanLyDoiBong_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 467);
            this.Controls.Add(this.btQuanLyDoiBong);
            this.Controls.Add(this.btWorldCup);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tbTaiKhoan);
            this.Controls.Add(this.lbUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Button tbTaiKhoan;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btWorldCup;
        private System.Windows.Forms.Button btQuanLyDoiBong;
    }
}