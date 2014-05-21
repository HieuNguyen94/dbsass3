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
            this.TableList = new System.Windows.Forms.ComboBox();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSignOut = new System.Windows.Forms.PictureBox();
            this.TableLabels = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.btnCommit = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSignOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCommit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TableList
            // 
            this.TableList.BackColor = System.Drawing.Color.MediumAquamarine;
            this.TableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableList.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableList.ForeColor = System.Drawing.Color.White;
            this.TableList.FormattingEnabled = true;
            this.TableList.Items.AddRange(new object[] {
            "TRAN DAU",
            "PHAT THE",
            "BAN THANG",
            "CHON CAU THU XUAT SAC",
            "THAY NGUOI",
            "LUAN LUU",
            "DEO BANG DOI TRUONG",
            "DOI HINH XUAT PHAT",
            "BINH LUAN"});
            this.TableList.Location = new System.Drawing.Point(2, 256);
            this.TableList.Name = "TableList";
            this.TableList.Size = new System.Drawing.Size(164, 30);
            this.TableList.TabIndex = 5;
            this.TableList.SelectedIndexChanged += new System.EventHandler(this.TableList_SelectedIndexChanged);
            this.TableList.MouseEnter += new System.EventHandler(this.TableList_MouseEnter);
            this.TableList.MouseLeave += new System.EventHandler(this.TableList_MouseLeave);
            // 
            // dataView
            // 
            this.dataView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(172, 90);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(523, 344);
            this.dataView.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WorldCup.Properties.Resources.banner;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 83);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnSignOut.BackgroundImage = global::WorldCup.Properties.Resources.signoutBtn;
            this.btnSignOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSignOut.Location = new System.Drawing.Point(2, 294);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(164, 53);
            this.btnSignOut.TabIndex = 22;
            this.btnSignOut.TabStop = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            this.btnSignOut.MouseEnter += new System.EventHandler(this.btnSignOut_MouseEnter);
            this.btnSignOut.MouseLeave += new System.EventHandler(this.btnSignOut_MouseLeave);
            // 
            // TableLabels
            // 
            this.TableLabels.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TableLabels.BackgroundImage = global::WorldCup.Properties.Resources.table;
            this.TableLabels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TableLabels.Location = new System.Drawing.Point(2, 204);
            this.TableLabels.Name = "TableLabels";
            this.TableLabels.Size = new System.Drawing.Size(164, 53);
            this.TableLabels.TabIndex = 21;
            this.TableLabels.TabStop = false;
            this.TableLabels.MouseEnter += new System.EventHandler(this.TableList_MouseEnter);
            this.TableLabels.MouseLeave += new System.EventHandler(this.TableList_MouseLeave);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnRefresh.BackgroundImage = global::WorldCup.Properties.Resources.refreshBtn;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(2, 147);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(164, 53);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseEnter += new System.EventHandler(this.btnRefresh_MouseEnter);
            this.btnRefresh.MouseLeave += new System.EventHandler(this.btnRefresh_MouseLeave);
            // 
            // btnCommit
            // 
            this.btnCommit.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnCommit.BackgroundImage = global::WorldCup.Properties.Resources.commitBtn_jpg;
            this.btnCommit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCommit.Location = new System.Drawing.Point(2, 90);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(164, 53);
            this.btnCommit.TabIndex = 19;
            this.btnCommit.TabStop = false;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            this.btnCommit.MouseEnter += new System.EventHandler(this.btnCommit_MouseEnter);
            this.btnCommit.MouseLeave += new System.EventHandler(this.btnCommit_MouseLeave);
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
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::WorldCup.Properties.Resources._23154;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(7, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 71);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkOrange;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(80, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 27);
            this.label1.TabIndex = 25;
            this.label1.Text = "Welcome";
            // 
            // ReporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(702, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.TableLabels);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TableList);
            this.Controls.Add(this.dataView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReporterForm";
            this.Text = "ReporterForm";
            this.Load += new System.EventHandler(this.ReporterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSignOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCommit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TableList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.PictureBox btnCommit;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.PictureBox TableLabels;
        private System.Windows.Forms.PictureBox btnSignOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;

    }
}