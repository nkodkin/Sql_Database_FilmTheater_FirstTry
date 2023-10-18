namespace Sql_Database_FilmTheater_FirstTry
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Login = new System.Windows.Forms.Button();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.DispLogin = new System.Windows.Forms.TextBox();
            this.DispPassword = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(125, 239);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(143, 47);
            this.Login.TabIndex = 0;
            this.Login.Text = "Авторизация";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.button1_Click);
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(90, 104);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(210, 23);
            this.textLogin.TabIndex = 1;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(90, 162);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(210, 23);
            this.textPassword.TabIndex = 2;
            this.textPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPassword_KeyPress);
            // 
            // DispLogin
            // 
            this.DispLogin.BackColor = System.Drawing.Color.Plum;
            this.DispLogin.Location = new System.Drawing.Point(147, 75);
            this.DispLogin.Name = "DispLogin";
            this.DispLogin.ReadOnly = true;
            this.DispLogin.Size = new System.Drawing.Size(100, 23);
            this.DispLogin.TabIndex = 3;
            this.DispLogin.Text = "Введите логин";
            this.DispLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DispLogin.TextChanged += new System.EventHandler(this.DispLogin_TextChanged);
            // 
            // DispPassword
            // 
            this.DispPassword.BackColor = System.Drawing.Color.Plum;
            this.DispPassword.Location = new System.Drawing.Point(147, 133);
            this.DispPassword.Name = "DispPassword";
            this.DispPassword.ReadOnly = true;
            this.DispPassword.Size = new System.Drawing.Size(100, 23);
            this.DispPassword.TabIndex = 4;
            this.DispPassword.Text = "Введите пароль";
            this.DispPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iconButton1
            // 
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(125, 344);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(143, 23);
            this.iconButton1.TabIndex = 5;
            this.iconButton1.Text = "Регистрация";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 370);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.DispPassword);
            this.Controls.Add(this.DispLogin);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.Login);
            this.Name = "LoginForm";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Login;
        private TextBox textLogin;
        private TextBox textPassword;
        private TextBox DispLogin;
        private TextBox DispPassword;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}