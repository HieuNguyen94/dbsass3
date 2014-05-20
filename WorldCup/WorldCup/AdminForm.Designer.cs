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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.lbUsername = new System.Windows.Forms.Label();
            this.btTaiKhoan = new System.Windows.Forms.Button();
            this.ButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btWorldCup = new System.Windows.Forms.Button();
            this.btQuanLyDoiBong = new System.Windows.Forms.Button();
            this.btCommit = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btLogout = new System.Windows.Forms.Button();
            this.btBinhLuan = new System.Windows.Forms.Button();
            this.btTranDau = new System.Windows.Forms.Button();
            this.tbThongTin = new System.Windows.Forms.TextBox();
            this.TableImage = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.BackColor = System.Drawing.Color.Transparent;
            this.lbUsername.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.White;
            this.lbUsername.Location = new System.Drawing.Point(670, 21);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(46, 19);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "Hiếu";
            // 
            // btTaiKhoan
            // 
            this.btTaiKhoan.BackColor = System.Drawing.Color.White;
            this.btTaiKhoan.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btTaiKhoan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btTaiKhoan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTaiKhoan.ImageKey = "TaiKhoan.png";
            this.btTaiKhoan.ImageList = this.TableImage;
            this.btTaiKhoan.Location = new System.Drawing.Point(44, 66);
            this.btTaiKhoan.Name = "btTaiKhoan";
            this.btTaiKhoan.Size = new System.Drawing.Size(134, 36);
            this.btTaiKhoan.TabIndex = 1;
            this.btTaiKhoan.UseVisualStyleBackColor = false;
            this.btTaiKhoan.Click += new System.EventHandler(this.tbTaiKhoan_Click);
            this.btTaiKhoan.MouseLeave += new System.EventHandler(this.tbTaiKhoan_MouseLeave);
            this.btTaiKhoan.MouseHover += new System.EventHandler(this.tbTaiKhoan_MouseHover);
            // 
            // ButtonImage
            // 
            this.ButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImage.ImageStream")));
            this.ButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.ButtonImage.Images.SetKeyName(0, "CommitButton.png");
            this.ButtonImage.Images.SetKeyName(1, "RefreshButton.png");
            this.ButtonImage.Images.SetKeyName(2, "RefreshButtonHover.png");
            this.ButtonImage.Images.SetKeyName(3, "SignoutButton.png");
            this.ButtonImage.Images.SetKeyName(4, "CommitButtonHover.png");
            this.ButtonImage.Images.SetKeyName(5, "SignoutButtonHover.png");
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(14, 104);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(590, 279);
            this.dgv.TabIndex = 2;
            this.dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_CellBeginEdit);
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_UserAddedRow);
            this.dgv.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_UserDeletedRow);
            // 
            // btWorldCup
            // 
            this.btWorldCup.BackColor = System.Drawing.Color.White;
            this.btWorldCup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btWorldCup.FlatAppearance.BorderSize = 0;
            this.btWorldCup.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btWorldCup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btWorldCup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btWorldCup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btWorldCup.ImageKey = "WorldCup.png";
            this.btWorldCup.ImageList = this.TableImage;
            this.btWorldCup.Location = new System.Drawing.Point(178, 66);
            this.btWorldCup.Name = "btWorldCup";
            this.btWorldCup.Size = new System.Drawing.Size(134, 36);
            this.btWorldCup.TabIndex = 3;
            this.btWorldCup.UseVisualStyleBackColor = false;
            this.btWorldCup.Click += new System.EventHandler(this.btWorldCup_Click);
            this.btWorldCup.MouseLeave += new System.EventHandler(this.btWorldCup_MouseLeave);
            this.btWorldCup.MouseHover += new System.EventHandler(this.btWorldCup_MouseHover);
            // 
            // btQuanLyDoiBong
            // 
            this.btQuanLyDoiBong.BackColor = System.Drawing.Color.White;
            this.btQuanLyDoiBong.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btQuanLyDoiBong.FlatAppearance.BorderSize = 0;
            this.btQuanLyDoiBong.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btQuanLyDoiBong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btQuanLyDoiBong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btQuanLyDoiBong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuanLyDoiBong.ImageKey = "QuanLy.png";
            this.btQuanLyDoiBong.ImageList = this.TableImage;
            this.btQuanLyDoiBong.Location = new System.Drawing.Point(312, 66);
            this.btQuanLyDoiBong.Name = "btQuanLyDoiBong";
            this.btQuanLyDoiBong.Size = new System.Drawing.Size(134, 36);
            this.btQuanLyDoiBong.TabIndex = 4;
            this.btQuanLyDoiBong.UseVisualStyleBackColor = false;
            this.btQuanLyDoiBong.Click += new System.EventHandler(this.btQuanLyDoiBong_Click);
            this.btQuanLyDoiBong.MouseLeave += new System.EventHandler(this.btQuanLyDoiBong_MouseLeave);
            this.btQuanLyDoiBong.MouseHover += new System.EventHandler(this.btQuanLyDoiBong_MouseHover);
            // 
            // btCommit
            // 
            this.btCommit.BackColor = System.Drawing.Color.White;
            this.btCommit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCommit.FlatAppearance.BorderSize = 0;
            this.btCommit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCommit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCommit.ImageKey = "CommitButton.png";
            this.btCommit.ImageList = this.ButtonImage;
            this.btCommit.Location = new System.Drawing.Point(614, 234);
            this.btCommit.Margin = new System.Windows.Forms.Padding(0);
            this.btCommit.Name = "btCommit";
            this.btCommit.Size = new System.Drawing.Size(162, 41);
            this.btCommit.TabIndex = 5;
            this.btCommit.UseVisualStyleBackColor = false;
            this.btCommit.Click += new System.EventHandler(this.btUpdate_Click);
            this.btCommit.MouseLeave += new System.EventHandler(this.btCommit_MouseLeave);
            this.btCommit.MouseHover += new System.EventHandler(this.btCommit_MouseHover);
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.White;
            this.btRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btRefresh.FlatAppearance.BorderSize = 0;
            this.btRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRefresh.ImageKey = "RefreshButton.png";
            this.btRefresh.ImageList = this.ButtonImage;
            this.btRefresh.Location = new System.Drawing.Point(614, 167);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(162, 41);
            this.btRefresh.TabIndex = 6;
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            this.btRefresh.MouseLeave += new System.EventHandler(this.btRefresh_MouseLeave);
            this.btRefresh.MouseHover += new System.EventHandler(this.btRefresh_MouseHover);
            // 
            // btLogout
            // 
            this.btLogout.BackColor = System.Drawing.Color.White;
            this.btLogout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btLogout.FlatAppearance.BorderSize = 0;
            this.btLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogout.ImageKey = "SignoutButton.png";
            this.btLogout.ImageList = this.ButtonImage;
            this.btLogout.Location = new System.Drawing.Point(614, 100);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(162, 41);
            this.btLogout.TabIndex = 7;
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            this.btLogout.MouseLeave += new System.EventHandler(this.btLogout_MouseLeave);
            this.btLogout.MouseHover += new System.EventHandler(this.btLogout_MouseHover);
            // 
            // btBinhLuan
            // 
            this.btBinhLuan.BackColor = System.Drawing.Color.White;
            this.btBinhLuan.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBinhLuan.FlatAppearance.BorderSize = 0;
            this.btBinhLuan.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btBinhLuan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBinhLuan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBinhLuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBinhLuan.ImageKey = "BinhLuan.png";
            this.btBinhLuan.ImageList = this.TableImage;
            this.btBinhLuan.Location = new System.Drawing.Point(446, 66);
            this.btBinhLuan.Name = "btBinhLuan";
            this.btBinhLuan.Size = new System.Drawing.Size(134, 36);
            this.btBinhLuan.TabIndex = 8;
            this.btBinhLuan.UseVisualStyleBackColor = false;
            this.btBinhLuan.Click += new System.EventHandler(this.btBinhLuan_Click);
            this.btBinhLuan.MouseLeave += new System.EventHandler(this.btBinhLuan_MouseLeave);
            this.btBinhLuan.MouseHover += new System.EventHandler(this.btBinhLuan_MouseHover);
            // 
            // btTranDau
            // 
            this.btTranDau.Location = new System.Drawing.Point(452, 10);
            this.btTranDau.Name = "btTranDau";
            this.btTranDau.Size = new System.Drawing.Size(96, 23);
            this.btTranDau.TabIndex = 9;
            this.btTranDau.Text = "Trận Đấu";
            this.btTranDau.UseVisualStyleBackColor = true;
            this.btTranDau.Click += new System.EventHandler(this.btTranDau_Click);
            // 
            // tbThongTin
            // 
            this.tbThongTin.BackColor = System.Drawing.SystemColors.Info;
            this.tbThongTin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbThongTin.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbThongTin.Location = new System.Drawing.Point(72, 395);
            this.tbThongTin.Multiline = true;
            this.tbThongTin.Name = "tbThongTin";
            this.tbThongTin.ReadOnly = true;
            this.tbThongTin.Size = new System.Drawing.Size(533, 48);
            this.tbThongTin.TabIndex = 0;
            // 
            // TableImage
            // 
            this.TableImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TableImage.ImageStream")));
            this.TableImage.TransparentColor = System.Drawing.Color.Transparent;
            this.TableImage.Images.SetKeyName(0, "BinhLuan.png");
            this.TableImage.Images.SetKeyName(1, "BinhLuanHover.png");
            this.TableImage.Images.SetKeyName(2, "QuanLy.png");
            this.TableImage.Images.SetKeyName(3, "QuanLyHover.png");
            this.TableImage.Images.SetKeyName(4, "TaiKhoan.png");
            this.TableImage.Images.SetKeyName(5, "TaiKhoanHover.png");
            this.TableImage.Images.SetKeyName(6, "WorldCup.png");
            this.TableImage.Images.SetKeyName(7, "WorldCupHover.png");
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tbThongTin);
            this.Controls.Add(this.btTranDau);
            this.Controls.Add(this.btBinhLuan);
            this.Controls.Add(this.btLogout);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btCommit);
            this.Controls.Add(this.btQuanLyDoiBong);
            this.Controls.Add(this.btWorldCup);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btTaiKhoan);
            this.Controls.Add(this.lbUsername);
            this.DoubleBuffered = true;
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
        private System.Windows.Forms.Button btTaiKhoan;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btWorldCup;
        private System.Windows.Forms.Button btQuanLyDoiBong;
        private System.Windows.Forms.Button btCommit;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.Button btBinhLuan;
        private System.Windows.Forms.Button btTranDau;
        private System.Windows.Forms.TextBox tbThongTin;
        private System.Windows.Forms.ImageList ButtonImage;
        private System.Windows.Forms.ImageList TableImage;
    }
}