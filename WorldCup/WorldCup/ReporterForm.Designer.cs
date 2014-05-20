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
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.TableList = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(15, 83);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(577, 405);
            this.dataView.TabIndex = 2;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(349, 25);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 39);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(465, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 39);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
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
            this.btnView.Location = new System.Drawing.Point(208, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 39);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "Xem";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // ReporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 500);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.TableList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dataView);
            this.Name = "ReporterForm";
            this.Text = "ReporterForm";
            this.Load += new System.EventHandler(this.ReporterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox TableList;
        private System.Windows.Forms.Button btnView;
    }
}