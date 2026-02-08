namespace AUTHORIZATION
{
    partial class MailRuTF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailRuTF));
            this.label1 = new System.Windows.Forms.Label();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SaveAccount = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WrongCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите код двухфакторной аутентификации:";
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.BackColor = System.Drawing.Color.White;
            this.CodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeTextBox.Location = new System.Drawing.Point(12, 59);
            this.CodeTextBox.MaxLength = 6;
            this.CodeTextBox.Multiline = true;
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(123, 22);
            this.CodeTextBox.TabIndex = 1;
            this.CodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeTextBox_KeyDown);
            // 
            // LoginButton
            // 
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Location = new System.Drawing.Point(141, 59);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(123, 22);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "ВХОД";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SaveAccount
            // 
            this.SaveAccount.AutoSize = true;
            this.SaveAccount.Checked = true;
            this.SaveAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SaveAccount.Location = new System.Drawing.Point(78, 87);
            this.SaveAccount.Name = "SaveAccount";
            this.SaveAccount.Size = new System.Drawing.Size(129, 17);
            this.SaveAccount.TabIndex = 3;
            this.SaveAccount.Text = "Запомнить аккаунт";
            this.SaveAccount.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(97, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 64);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.BackColor = System.Drawing.Color.White;
            this.CaptchaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CaptchaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptchaTextBox.Location = new System.Drawing.Point(6, 35);
            this.CaptchaTextBox.MaxLength = 6;
            this.CaptchaTextBox.Multiline = true;
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(86, 21);
            this.CaptchaTextBox.TabIndex = 1;
            this.CaptchaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CaptchaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeTextBox_KeyDown);
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(12, 12);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.ReadOnly = true;
            this.textBox_login.Size = new System.Drawing.Size(252, 22);
            this.textBox_login.TabIndex = 6;
            this.textBox_login.Text = ". . .";
            this.textBox_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CaptchaTextBox);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 81);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод капчи";
            // 
            // WrongCode
            // 
            this.WrongCode.AutoSize = true;
            this.WrongCode.ForeColor = System.Drawing.Color.Red;
            this.WrongCode.Location = new System.Drawing.Point(9, 107);
            this.WrongCode.Margin = new System.Windows.Forms.Padding(0);
            this.WrongCode.Name = "WrongCode";
            this.WrongCode.Size = new System.Drawing.Size(157, 13);
            this.WrongCode.TabIndex = 8;
            this.WrongCode.Text = "Неверный код авторизации";
            this.WrongCode.Visible = false;
            // 
            // MailRuTF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(276, 125);
            this.Controls.Add(this.WrongCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.SaveAccount);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.CodeTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailRuTF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Двухфакторная аутентификация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.CheckBox SaveAccount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox CaptchaTextBox;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label WrongCode;
    }
}