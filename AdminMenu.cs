using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using System.Globalization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Sql_Database_FilmTheater_FirstTry
{
    public partial class AdminMenu : Form
    {
        private SqlConnection Theater = null;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\программирование\\всякое\\Sql_Database_FilmTheater_FirstTry\\Sql_Database_FilmTheater_FirstTry\\FilmTheater.mdf;Integrated Security=True";
        
        public AdminMenu()
        {
            InitializeComponent();
            
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            passwordText.PasswordChar = '*';

            Theater = new SqlConnection
                (connectionString);
            Theater.Open();
            //if (Theater.State == ConnectionState.Open) { MessageBox.Show("Успешно"); }
            //else { MessageBox.Show("Не успешно"); }
            
            
            SqlDataAdapter filmsAdapter = new SqlDataAdapter("Select Movie.id, title AS Название, duration_min AS Продолжительность, " +
                "CONCAT (firstname, ' '+lastname) as Режиссер FROM Movie Left JOIN Director ON director.id=director_id ",
                Theater);

            DataSet Filmset = new DataSet();

            filmsAdapter.Fill(Filmset);

            FilmGridView.DataSource = Filmset.Tables[0];

            FilmGridView.Columns[0].Visible = false;


            DataGridViewColumn column = FilmGridView.Columns[1];
            column.Width = 240;

            column = FilmGridView.Columns[2];
            column.Width = 240;

            column = FilmGridView.Columns[3];
            column.Width = 240;

            SqlDataAdapter screeningAdapter = new SqlDataAdapter("Select id, auditorium_id as Зал, screening_start as Начало, " +
               "(Select title FROM Movie where Movie.id=Movie_id) as Фильм FROM Screening",
               Theater);

            DataSet ScreenSet = new DataSet();
            screeningAdapter.Fill(ScreenSet);
            ScreeningGridView.DataSource = ScreenSet.Tables[0];

            ScreeningGridView.Columns[0].Visible=false;

            column = ScreeningGridView.Columns[1];
            column.Width = 240;

            column = ScreeningGridView.Columns[2];
            column.Width = 240;

            column = ScreeningGridView.Columns[3];
            column.Width = 240;


            //dateStartScreening.CustomFormat = "yyyy-MM-dd";
            //dateStartScreening.Format = DateTimePickerFormat.Custom;
            

            ChooseFilmGridView.DataSource = Filmset.Tables[0];

            ChooseFilmGridView.Columns[0].Visible = false;
            ChooseFilmGridView.Columns[2].Visible = false;

            column = ChooseFilmGridView.Columns[1];
            column.Width = 120;


            column = ChooseFilmGridView.Columns[3];
            column.Width = 120;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (FilmGridView.DataSource as DataTable).DefaultView.RowFilter = $"Название LIKE '%{SearchFilm.Text}%'";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void AddFilm_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Director where firstname = @FirstName and " +
                    "lastname = @LastName", Theater);
                command.Parameters.AddWithValue("FirstName", DirectorName.Text);
                command.Parameters.AddWithValue("LastName", DirectorLastName.Text);
                command.Parameters.AddWithValue("FilmName", FilmName.Text);
                command.Parameters.AddWithValue("FilmLength", FilmLength.Text);
                SqlDataReader DirectorCheck = command.ExecuteReader();

                if (DirectorCheck.HasRows)
                {
                    DirectorCheck.Close();
                    DirectorCheck.Dispose();
                    
                    command = new SqlCommand("INSERT INTO MOVIE VALUES(@FilmName," +
                        "(SELECT id FROM Director WHERE  firstname = @FirstName and lastname = @LastName)," +
                        "@FilmLength)", Theater);
                    command.Parameters.AddWithValue("FirstName", DirectorName.Text);
                    command.Parameters.AddWithValue("LastName", DirectorLastName.Text);
                    command.Parameters.AddWithValue("FilmName", FilmName.Text);
                    command.Parameters.AddWithValue("FilmLength", FilmLength.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Фильм успешно добавлен");

                }
                else
                {
                    DirectorCheck.Close();
                    DirectorCheck.Dispose();
                    command = new SqlCommand($"INSERT INTO DIRECTOR VALUES(@FirstName, @LastName)", Theater);
                    command.Parameters.AddWithValue("FirstName", DirectorName.Text);
                    command.Parameters.AddWithValue("LastName", DirectorLastName.Text);
                    command.ExecuteNonQuery();
                    
                    command = new SqlCommand("INSERT INTO MOVIE VALUES(@FirstName," +
                        "(SELECT id FROM Director WHERE  firstname = @FirstName and lastname = @LastName)," +
                        "@FilmLength)", Theater);
                    command.Parameters.AddWithValue("FirstName", DirectorName.Text);
                    command.Parameters.AddWithValue("LastName", DirectorLastName.Text);
                    command.Parameters.AddWithValue("FilmName", FilmName.Text);
                    command.Parameters.AddWithValue("FilmLength", FilmLength.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Фильм успешно добавлен");
                }
            }
            catch { MessageBox.Show("Вы ввели неверные данные. Попробуйте еще раз"); }
        }

        private void buttonViewFilms_Click(object sender, EventArgs e)
        {
            SqlDataAdapter filmsAdapter = new SqlDataAdapter("Select Movie.id, title AS Название, duration_min AS Продолжительность, " +
                "CONCAT (firstname, ' '+lastname) as Режиссер FROM Movie Left JOIN Director ON director.id=director_id",
                Theater);

            DataSet Filmset = new DataSet();
            filmsAdapter.Fill(Filmset);
            FilmGridView.DataSource = Filmset.Tables[0];
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataRow row = (FilmGridView.SelectedRows[0].DataBoundItem as DataRowView).Row;
                SqlCommand command = new SqlCommand("DELETE FROM Movie where id = " + row["id"], Theater);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Выберите строку, которую хотите удалить");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
              
        }

        private void ScreeningGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddScreenings_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Screening values(@movie_id, @auditorium, @date)", Theater);
                DataRow row = (ChooseFilmGridView.SelectedRows[0].DataBoundItem as DataRowView).Row;

                command.Parameters.AddWithValue("@movie_id", row["id"]);
                command.Parameters.AddWithValue("@auditorium", audTextbox.Text);
                string str = dateStartScreening.Value.ToString("yyyy-MM-dd") + ' ' + ScreeningTimeStartTextBox.Text;
                command.Parameters.AddWithValue("@date", str);
                command.ExecuteNonQuery();
                MessageBox.Show("Сеанс успешно добавлен");
            }
            catch
            {
                MessageBox.Show("Неверные данные");
            }


}

        private void DeleteScreening_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = (ScreeningGridView.SelectedRows[0].DataBoundItem as DataRowView).Row;
                SqlCommand command = new SqlCommand("DELETE FROM Screening where id = " + row["id"], Theater);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Выберите строку, которую хотите удалить");
            }
        }

        private void UpdateScreening_Click(object sender, EventArgs e)
        {
            SqlDataAdapter screeningAdapter = new SqlDataAdapter("Select id, auditorium_id as Зал, screening_start as Начало, " +
              "(Select title FROM Movie where Movie.id=Movie_id) as Фильм, Movie_id as idФильма FROM Screening",
              Theater);

            DataSet ScreenSet = new DataSet();
            screeningAdapter.Fill(ScreenSet);
            ScreeningGridView.DataSource = ScreenSet.Tables[0];
        }

        private void findScreningwithAFilm_TextChanged(object sender, EventArgs e)
        {
            (ScreeningGridView.DataSource as DataTable).DefaultView.RowFilter = $"Фильм LIKE '%{findScreningwithAFilm.Text}%'";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string str = dateTimePicker1.Value.ToString();
            DateTime date = DateTime.Parse(str);

            
            string dtFilter = string.Format(
                "[Начало] >= '{0} 12:00:00 AM' AND [Начало] <= '{0} 11:59:59 PM'", date.ToString("dd/MM/yyyy"));

            (ScreeningGridView.DataSource as DataTable).DefaultView.RowFilter = dtFilter;
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            try
            {
                string? password = passwordText.Text;

                if (password.Length > 5 && password.Any(x => char.IsUpper(x)) && password.Any(x => char.IsLower(x)) && password.Any(x => char.IsDigit(x)))
                {
                byte[] salt = Encoding.ASCII.GetBytes(password); 

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
                
                    SqlCommand command = new SqlCommand("Insert into Users values (@login, @password, 'Admin', NULL)", Theater);
                    command.Parameters.AddWithValue("login", loginText.Text);
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
            
        }

        private void passwordText_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && !char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
            
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void FilmidTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FindAndChooseFilm_TextChanged(object sender, EventArgs e)
        {
            (ChooseFilmGridView.DataSource as DataTable).DefaultView.RowFilter = $"Название LIKE '%{FindAndChooseFilm.Text}%'";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
