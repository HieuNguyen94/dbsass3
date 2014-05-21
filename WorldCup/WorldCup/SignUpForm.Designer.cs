namespace WorldCup
{
    partial class SignUpForm
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
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.RePassLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbRePass = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserNameLabel.Location = new System.Drawing.Point(40, 52);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(86, 16);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "User Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PasswordLabel.Location = new System.Drawing.Point(40, 88);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(115, 16);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Enter password";
            // 
            // RePassLabel
            // 
            this.RePassLabel.AutoSize = true;
            this.RePassLabel.BackColor = System.Drawing.Color.Transparent;
            this.RePassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RePassLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RePassLabel.Location = new System.Drawing.Point(40, 121);
            this.RePassLabel.Name = "RePassLabel";
            this.RePassLabel.Size = new System.Drawing.Size(139, 16);
            this.RePassLabel.TabIndex = 2;
            this.RePassLabel.Text = "Re-enter password";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InfoLabel.Location = new System.Drawing.Point(12, 9);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(172, 20);
            this.InfoLabel.TabIndex = 3;
            this.InfoLabel.Text = "Account Infromation";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(194, 49);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(169, 20);
            this.tbName.TabIndex = 4;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(194, 85);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(169, 20);
            this.tbPass.TabIndex = 6;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // tbRePass
            // 
            this.tbRePass.Location = new System.Drawing.Point(194, 118);
            this.tbRePass.Name = "tbRePass";
            this.tbRePass.Size = new System.Drawing.Size(169, 20);
            this.tbRePass.TabIndex = 7;
            this.tbRePass.UseSystemPasswordChar = true;
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDone.Location = new System.Drawing.Point(240, 154);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(97, 32);
            this.btnDone.TabIndex = 8;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WorldCup.Properties.Resources.ca2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(462, 198);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.tbRePass);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.RePassLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SignUpForm";
            this.Text = "SignUpForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label RePassLabel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbRePass;
        private System.Windows.Forms.Button btnDone;
    }
}