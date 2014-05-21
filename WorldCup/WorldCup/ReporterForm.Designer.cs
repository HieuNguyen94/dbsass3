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
            this.dataView = new System.Windows.Forms.DataGridView();
            this.TableList = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(15, 70);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(722, 418);
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
            this.TableList.Location = new System.Drawing.Point(15, 43);
            this.TableList.Name = "TableList";
            this.TableList.Size = new System.Drawing.Size(174, 21);
            this.TableList.TabIndex = 5;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(208, 35);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "Xem";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(289, 35);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(370, 35);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 29);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btLogout
            // 
            this.btLogout.Location = new System.Drawing.Point(662, 12);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(75, 23);
            this.btLogout.TabIndex = 32;
            this.btLogout.Text = "Log out";
            this.btLogout.UseVisualStyleBackColor = true;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // ReporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::WorldCup.Properties.Resources._2014_brazil_logo_for_world_cup_1920x1080;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(749, 500);
            this.Controls.Add(this.btLogout);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.TableList);
            this.Controls.Add(this.dataView);
            this.Name = "ReporterForm";
            this.Text = "ReporterForm";
            this.Load += new System.EventHandler(this.ReporterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.ComboBox TableList;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btLogout;
    }
}