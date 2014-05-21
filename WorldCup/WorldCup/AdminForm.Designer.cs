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
            this.TableImage = new System.Windows.Forms.ImageList(this.components);
            this.ButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btWorldCup = new System.Windows.Forms.Button();
            this.btQuanLyDoiBong = new System.Windows.Forms.Button();
            this.btCommit = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btLogout = new System.Windows.Forms.Button();
            this.btTranDau = new System.Windows.Forms.Button();
            this.tbThongTin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.BackColor = System.Drawing.Color.Transparent;
            this.lbUsername.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.White;
            this.lbUsername.Location = new System.Drawing.Point(681, 26);
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
            this.btTaiKhoan.Location = new System.Drawing.Point(12, 82);
            this.btTaiKhoan.Name = "btTaiKhoan";
            this.btTaiKhoan.Size = new System.Drawing.Size(151, 33);
            this.btTaiKhoan.TabIndex = 1;
            this.btTaiKhoan.UseVisualStyleBackColor = false;
            this.btTaiKhoan.Click += new System.EventHandler(this.tbTaiKhoan_Click);
            this.btTaiKhoan.MouseLeave += new System.EventHandler(this.tbTaiKhoan_MouseLeave);
            this.btTaiKhoan.MouseHover += new System.EventHandler(this.tbTaiKhoan_MouseHover);
            // 
            // TableImage
            // 
            this.TableImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TableImage.ImageStream")));
            this.TableImage.TransparentColor = System.Drawing.Color.Transparent;
            this.TableImage.Images.SetKeyName(0, "QuanLy.png");
            this.TableImage.Images.SetKeyName(1, "QuanLyHover.png");
            this.TableImage.Images.SetKeyName(2, "TaiKhoan.png");
            this.TableImage.Images.SetKeyName(3, "TaiKhoanHover.png");
            this.TableImage.Images.SetKeyName(4, "TranDau.png");
            this.TableImage.Images.SetKeyName(5, "TranDauHover.png");
            this.TableImage.Images.SetKeyName(6, "WorldCup.png");
            this.TableImage.Images.SetKeyName(7, "WorldCupHover.png");
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
            this.dgv.Location = new System.Drawing.Point(16, 121);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(599, 318);
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
            this.btWorldCup.Location = new System.Drawing.Point(314, 82);
            this.btWorldCup.Name = "btWorldCup";
            this.btWorldCup.Size = new System.Drawing.Size(151, 33);
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
            this.btQuanLyDoiBong.Location = new System.Drawing.Point(163, 82);
            this.btQuanLyDoiBong.Name = "btQuanLyDoiBong";
            this.btQuanLyDoiBong.Size = new System.Drawing.Size(151, 33);
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
            this.btCommit.Location = new System.Drawing.Point(625, 237);
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
            this.btRefresh.Location = new System.Drawing.Point(625, 177);
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
            this.btLogout.Location = new System.Drawing.Point(625, 115);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(162, 41);
            this.btLogout.TabIndex = 7;
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            this.btLogout.MouseLeave += new System.EventHandler(this.btLogout_MouseLeave);
            this.btLogout.MouseHover += new System.EventHandler(this.btLogout_MouseHover);
            // 
            // btTranDau
            // 
            this.btTranDau.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btTranDau.FlatAppearance.BorderSize = 0;
            this.btTranDau.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btTranDau.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btTranDau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTranDau.ImageKey = "TranDau.png";
            this.btTranDau.ImageList = this.TableImage;
            this.btTranDau.Location = new System.Drawing.Point(465, 82);
            this.btTranDau.Name = "btTranDau";
            this.btTranDau.Size = new System.Drawing.Size(151, 33);
            this.btTranDau.TabIndex = 9;
            this.btTranDau.UseVisualStyleBackColor = true;
            this.btTranDau.Click += new System.EventHandler(this.btTranDau_Click);
            this.btTranDau.MouseLeave += new System.EventHandler(this.btTranDau_MouseLeave);
            this.btTranDau.MouseHover += new System.EventHandler(this.btTranDau_MouseHover);
            // 
            // tbThongTin
            // 
            this.tbThongTin.BackColor = System.Drawing.SystemColors.Info;
            this.tbThongTin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbThongTin.Cursor = System.Windows.Forms.Cursors.No;
            this.tbThongTin.Enabled = false;
            this.tbThongTin.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbThongTin.Location = new System.Drawing.Point(76, 457);
            this.tbThongTin.Multiline = true;
            this.tbThongTin.Name = "tbThongTin";
            this.tbThongTin.ReadOnly = true;
            this.tbThongTin.Size = new System.Drawing.Size(536, 51);
            this.tbThongTin.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(797, 529);
            this.Controls.Add(this.tbThongTin);
            this.Controls.Add(this.btTranDau);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Button btTranDau;
        private System.Windows.Forms.TextBox tbThongTin;
        private System.Windows.Forms.ImageList ButtonImage;
        private System.Windows.Forms.ImageList TableImage;
    }
}