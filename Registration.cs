using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql_Database_FilmTheater_FirstTry
{

    public partial class Registration : Form
    {
        private SqlConnection Theater = null;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\программирование\\всякое\\Sql_Database_FilmTheater_FirstTry\\Sql_Database_FilmTheater_FirstTry\\FilmTheater.mdf;Integrated Security=True";
        public Registration()
        {
            InitializeComponent();

        }

        private void Registration_Load(object sender, EventArgs e)
        {
           
            textPassword.PasswordChar = '*';
        }

        private void Регистрация_Click(object sender, EventArgs e)
        {
            Theater = new SqlConnection
                (connectionString);
            Theater.Open();

            try
            {
                string? password = textPassword.Text;

                if (password.Length > 5 && password.Any(x => char.IsUpper(x)) && password.Any(x => char.IsLower(x)) && password.Any(x => char.IsDigit(x)))
                {
                    byte[] salt = Encoding.ASCII.GetBytes(password);

                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: password!,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8));

                    SqlCommand command = new SqlCommand("Insert into Users values (@login, @password, 'Customer', NULL)", Theater);
                    command.Parameters.AddWithValue("login", textLogin.Text);
                    command.Parameters.AddWithValue("password", hashed);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пользователь успешно добавлен");
                }
                else { MessageBox.Show("Пароль должен состоять как минимум из 6 символов, содержать заглавные и строчные буквы, цифры"); }
            }
            catch
            {
                MessageBox.Show("Такой пользователь уже существует");
            }
            Theater.Close();
        }

        private void BackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && !char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
