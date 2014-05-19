namespace WorldCup
{
    partial class ClientForm
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
            this.gbThongTinTranDau = new System.Windows.Forms.GroupBox();
            this.lbTiSoLuanLuu = new System.Windows.Forms.Label();
            this.lbTiSoHiepPhu = new System.Windows.Forms.Label();
            this.lbTiSoHiepChinh = new System.Windows.Forms.Label();
            this.lbDoiTuyen2 = new System.Windows.Forms.Label();
            this.lbDoiTuyen1 = new System.Windows.Forms.Label();
            this.lbSanVanDong = new System.Windows.Forms.Label();
            this.gbThongTinTranDau.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(12, 9);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(63, 13);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "lbUsername";
            // 
            // gbThongTinTranDau
            // 
            this.gbThongTinTranDau.Controls.Add(this.lbSanVanDong);
            this.gbThongTinTranDau.Controls.Add(this.lbTiSoLuanLuu);
            this.gbThongTinTranDau.Controls.Add(this.lbTiSoHiepPhu);
            this.gbThongTinTranDau.Controls.Add(this.lbTiSoHiepChinh);
            this.gbThongTinTranDau.Controls.Add(this.lbDoiTuyen2);
            this.gbThongTinTranDau.Controls.Add(this.lbDoiTuyen1);
            this.gbThongTinTranDau.Location = new System.Drawing.Point(15, 53);
            this.gbThongTinTranDau.Name = "gbThongTinTranDau";
            this.gbThongTinTranDau.Size = new System.Drawing.Size(183, 181);
            this.gbThongTinTranDau.TabIndex = 2;
            this.gbThongTinTranDau.TabStop = false;
            this.gbThongTinTranDau.Text = "Thông tin trận đấu";
            // 
            // lbTiSoLuanLuu
            // 
            this.lbTiSoLuanLuu.AutoSize = true;
            this.lbTiSoLuanLuu.Location = new System.Drawing.Point(7, 126);
            this.lbTiSoLuanLuu.Name = "lbTiSoLuanLuu";
            this.lbTiSoLuanLuu.Size = new System.Drawing.Size(70, 13);
            this.lbTiSoLuanLuu.TabIndex = 4;
            this.lbTiSoLuanLuu.Text = "Tỉ số luân lưu";
            // 
            // lbTiSoHiepPhu
            // 
            this.lbTiSoHiepPhu.AutoSize = true;
            this.lbTiSoHiepPhu.Location = new System.Drawing.Point(7, 100);
            this.lbTiSoHiepPhu.Name = "lbTiSoHiepPhu";
            this.lbTiSoHiepPhu.Size = new System.Drawing.Size(74, 13);
            this.lbTiSoHiepPhu.TabIndex = 3;
            this.lbTiSoHiepPhu.Text = "Tỉ số hiệp phụ";
            // 
            // lbTiSoHiepChinh
            // 
            this.lbTiSoHiepChinh.AutoSize = true;
            this.lbTiSoHiepChinh.Location = new System.Drawing.Point(7, 71);
            this.lbTiSoHiepChinh.Name = "lbTiSoHiepChinh";
            this.lbTiSoHiepChinh.Size = new System.Drawing.Size(84, 13);
            this.lbTiSoHiepChinh.TabIndex = 2;
            this.lbTiSoHiepChinh.Text = "Tỉ số hiệp chính";
            // 
            // lbDoiTuyen2
            // 
            this.lbDoiTuyen2.AutoSize = true;
            this.lbDoiTuyen2.Location = new System.Drawing.Point(86, 33);
            this.lbDoiTuyen2.Name = "lbDoiTuyen2";
            this.lbDoiTuyen2.Size = new System.Drawing.Size(65, 13);
            this.lbDoiTuyen2.TabIndex = 1;
            this.lbDoiTuyen2.Text = "Đội Tuyển 2";
            // 
            // lbDoiTuyen1
            // 
            this.lbDoiTuyen1.AutoSize = true;
            this.lbDoiTuyen1.Location = new System.Drawing.Point(7, 33);
            this.lbDoiTuyen1.Name = "lbDoiTuyen1";
            this.lbDoiTuyen1.Size = new System.Drawing.Size(65, 13);
            this.lbDoiTuyen1.TabIndex = 0;
            this.lbDoiTuyen1.Text = "Đội Tuyển 1";
            // 
            // lbSanVanDong
            // 
            this.lbSanVanDong.AutoSize = true;
            this.lbSanVanDong.Location = new System.Drawing.Point(11, 153);
            this.lbSanVanDong.Name = "lbSanVanDong";
            this.lbSanVanDong.Size = new System.Drawing.Size(77, 13);
            this.lbSanVanDong.TabIndex = 5;
            this.lbSanVanDong.Text = "Sân Vận Động";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 353);
            this.Controls.Add(this.gbThongTinTranDau);
            this.Controls.Add(this.lbUsername);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.gbThongTinTranDau.ResumeLayout(false);
            this.gbThongTinTranDau.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.GroupBox gbThongTinTranDau;
        private System.Windows.Forms.Label lbTiSoLuanLuu;
        private System.Windows.Forms.Label lbTiSoHiepPhu;
        private System.Windows.Forms.Label lbTiSoHiepChinh;
        private System.Windows.Forms.Label lbDoiTuyen2;
        private System.Windows.Forms.Label lbDoiTuyen1;
        private System.Windows.Forms.Label lbSanVanDong;
    }
}