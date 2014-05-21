namespace WorldCup
{
    partial class ReporterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporterForm));
            this.dataView = new System.Windows.Forms.DataGridView();
            this.TableList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ViewBtn = new System.Windows.Forms.PictureBox();
            this.CommitBtn = new System.Windows.Forms.PictureBox();
            this.RefreshBtn = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommitBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(12, 90);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(554, 380);
            this.dataView.TabIndex = 2;
            // 
            // TableList
            // 
            this.TableList.FormattingEnabled = true;
            this.TableList.Items.AddRange(new object[] {
            "TRẬN ĐẤU",
            "PHẠT THẺ",
            "BÀN THẮNG",
            "CHỌN CẦU THỦ XUẤT SẮC",
            "THAY NGƯỜI",
            "LUÂN LƯU",
            "ĐEO BĂNG ĐỘI TRƯỞNG",
            "ĐỘI HÌNH XUẤT PHÁT",
            "BÌNH LUẬN"});
            this.TableList.Location = new System.Drawing.Point(392, 39);
            this.TableList.Name = "TableList";
            this.TableList.Size = new System.Drawing.Size(174, 21);
            this.TableList.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(298, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Chọn bảng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(63, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 78);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // ViewBtn
            // 
            this.ViewBtn.BackColor = System.Drawing.Color.Transparent;
            this.ViewBtn.BackgroundImage = global::WorldCup.Properties.Resources.GoBtn;
            this.ViewBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ViewBtn.Location = new System.Drawing.Point(579, 39);
            this.ViewBtn.Name = "ViewBtn";
            this.ViewBtn.Size = new System.Drawing.Size(74, 70);
            this.ViewBtn.TabIndex = 13;
            this.ViewBtn.TabStop = false;
            this.ViewBtn.Click += new System.EventHandler(this.ViewBtn_Click);
            // 
            // CommitBtn
            // 
            this.CommitBtn.BackColor = System.Drawing.Color.Transparent;
            this.CommitBtn.BackgroundImage = global::WorldCup.Properties.Resources.CheckBtn;
            this.CommitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CommitBtn.Location = new System.Drawing.Point(579, 116);
            this.CommitBtn.Name = "CommitBtn";
            this.CommitBtn.Size = new System.Drawing.Size(74, 70);
            this.CommitBtn.TabIndex = 14;
            this.CommitBtn.TabStop = false;
            this.CommitBtn.Click += new System.EventHandler(this.CommitBtn_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.BackColor = System.Drawing.Color.Transparent;
            this.RefreshBtn.BackgroundImage = global::WorldCup.Properties.Resources.refreshBtn;
            this.RefreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshBtn.Location = new System.Drawing.Point(579, 192);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(74, 70);
            this.RefreshBtn.TabIndex = 15;
            this.RefreshBtn.TabStop = false;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(94, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Xin chào";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.DisabledLinkColor = System.Drawing.SystemColors.Highlight;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkLabel1.Location = new System.Drawing.Point(97, 57);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 18);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Log out";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ReporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(669, 500);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.CommitBtn);
            this.Controls.Add(this.ViewBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TableList);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReporterForm";
            this.Text = "Reporter";
            this.Load += new System.EventHandler(this.ReporterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommitBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.ComboBox TableList;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ViewBtn;
        private System.Windows.Forms.PictureBox CommitBtn;
        private System.Windows.Forms.PictureBox RefreshBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;

    }
}