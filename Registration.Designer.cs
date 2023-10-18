namespace Sql_Database_FilmTheater_FirstTry
{
    partial class Registration
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
            this.DispPassword = new System.Windows.Forms.TextBox();
            this.DispLogin = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.Регистрация = new System.Windows.Forms.Button();
            this.BackToLogin = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // DispPassword
            // 
            this.DispPassword.BackColor = System.Drawing.Color.Plum;
            this.DispPassword.Location = new System.Drawing.Point(98, 96);
            this.DispPassword.Name = "DispPassword";
            this.DispPassword.ReadOnly = true;
            this.DispPassword.Size = new System.Drawing.Size(100, 23);
            this.DispPassword.TabIndex = 9;
            this.DispPassword.Text = "Введите пароль";
            this.DispPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DispLogin
            // 
            this.DispLogin.BackColor = System.Drawing.Color.Plum;
            this.DispLogin.Location = new System.Drawing.Point(98, 38);
            this.DispLogin.Name = "DispLogin";
            this.DispLogin.ReadOnly = true;
            this.DispLogin.Size = new System.Drawing.Size(100, 23);
            this.DispLogin.TabIndex = 8;
            this.DispLogin.Text = "Введите логин";
            this.DispLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(41, 125);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(210, 23);
            this.textPassword.TabIndex = 7;
            this.textPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPassword_KeyPress);
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(41, 67);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(210, 23);
            this.textLogin.TabIndex = 6;
            // 
            // Регистрация
            // 
            this.Регистрация.Location = new System.Drawing.Point(76, 202);
            this.Регистрация.Name = "Регистрация";
            this.Регистрация.Size = new System.Drawing.Size(143, 47);
            this.Регистрация.TabIndex = 5;
            this.Регистрация.Text = "Регистрация";
            this.Регистрация.UseVisualStyleBackColor = true;
            this.Регистрация.Click += new System.EventHandler(this.Регистрация_Click);
            // 
            // BackToLogin
            // 
            this.BackToLogin.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.BackToLogin.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackToLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BackToLogin.IconSize = 14;
            this.BackToLogin.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BackToLogin.Location = new System.Drawing.Point(0, 2);
            this.BackToLogin.Name = "BackToLogin";
            this.BackToLogin.Size = new System.Drawing.Size(24, 23);
            this.BackToLogin.TabIndex = 10;
            this.BackToLogin.UseVisualStyleBackColor = true;
            this.BackToLogin.Click += new System.EventHandler(this.BackToLogin_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 287);
            this.Controls.Add(this.BackToLogin);
            this.Controls.Add(this.DispPassword);
            this.Controls.Add(this.DispLogin);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.Регистрация);
            this.Name = "Registration";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox DispPassword;
        private TextBox DispLogin;
        private TextBox textPassword;
        private TextBox textLogin;
        private Button Регистрация;
        private FontAwesome.Sharp.IconButton BackToLogin;
    }
}