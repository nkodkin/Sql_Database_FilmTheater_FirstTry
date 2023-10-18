using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace Sql_Database_FilmTheater_FirstTry
{
    public partial class LoginForm : Form
    {
        private SqlConnection Theater = null;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\программирование\\всякое\\Sql_Database_FilmTheater_FirstTry\\Sql_Database_FilmTheater_FirstTry\\FilmTheater.mdf;Integrated Security=True";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textPassword.PasswordChar = '*';
            //if (Theater.State == ConnectionState.Open) { MessageBox.Show("Успешно"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Theater = new SqlConnection
                (connectionString);
            Theater.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM Users where username = @Login", Theater);
            command.Parameters.AddWithValue("Login", textLogin.Text);
            SqlDataReader userinfo = command.ExecuteReader();
            if (userinfo.HasRows)
            {
                userinfo.Read();
                string? password = textPassword.Text;
                byte[] salt = Encoding.ASCII.GetBytes(password);

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                if (userinfo.GetString(2) ==hashed &&  userinfo.GetString(3)=="Admin")
                {
                    AdminMenu newForm = new AdminMenu();
                    newForm.FormClosing += delegate { this.Close(); };
                    newForm.Show();
                    this.Hide();
                }
                else if (userinfo.GetString(2) == hashed && userinfo.GetString(3) == "Customer")
                {
                    FormMainMenu newForm = new FormMainMenu(userinfo.GetInt32(0));
                    newForm.FormClosing += delegate { this.Close(); };
                    newForm.Show();
                    this.Hide();
                }
                else { MessageBox.Show("Неверный пароль, попробуйте еще раз"); }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
            Theater.Close();
            
        }

        private void DispLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Registration newForm = new Registration();
            newForm.FormClosing += delegate { this.Show(); };
            newForm.Show();
            this.Hide();
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