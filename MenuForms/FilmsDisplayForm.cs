using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Sql_Database_FilmTheater_FirstTry.MenuForms
{
    public partial class FilmsDisplayForm : Form
    {
        private int User_id;
        private SqlConnection Theater = null;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\программирование\\всякое\\Sql_Database_FilmTheater_FirstTry\\Sql_Database_FilmTheater_FirstTry\\FilmTheater.mdf;Integrated Security=True";
        private int hall;
        private int screening;
        private int[] reservedseats = new int[50];
        private int i = 0;
        public FilmsDisplayForm(int id)
        {
            User_id = id;
            InitializeComponent();
        }
        private void FilmsDisplayForm_Load(object sender, EventArgs e)
        {
            FilmsCombobox.SelectedIndexChanged -= FilmsCombobox_SelectedIndexChanged;
            Theater = new SqlConnection
                (connectionString);
            Theater.Open();


            SqlDataAdapter filmsAdapter = new SqlDataAdapter("Select * " +
                "FROM Movie WHERE EXISTS(SELECT * FROM screening where Movie.id=screening.movie_id)",
                Theater);

            DataSet Filmset = new DataSet();
            filmsAdapter.Fill(Filmset);
            
            FilmsCombobox.DataSource = Filmset.Tables[0];
            FilmsCombobox.DisplayMember = "title";
            FilmsCombobox.ValueMember = "id";

            FilmsCombobox.SelectedIndexChanged += FilmsCombobox_SelectedIndexChanged;
            //int movie_id = Int32.Parse(FilmsCombobox.SelectedIndex.ToString());

            //CONCAT(screening_start, ' Зал: '+auditorium_id)
            //SqlDataAdapter screeningAdapter = new SqlDataAdapter("Select id, CONCAT(screening_start, ' Зал: '+auditorium_id) " +
            //    $"FROM Screening WHERE Movie_id = CONVERT (INT, '{FilmsCombobox.SelectedIndex.ToString()}')",
            //    Theater);
            //DataSet screeningset = new DataSet();
            //screeningAdapter.Fill(screeningset);



            //ScreeningComboBox.DataSource = screeningset.Tables[0];
            //ScreeningComboBox.DisplayMember = "title";
            //ScreeningComboBox.ValueMember = "id";

        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            
        }

        private void FilmsCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter screeningAdapter = new SqlDataAdapter("Select id, CONCAT(screening_start, N' Зал: ' +Cast(auditorium_id as VARCHAR(2) )) as INFO " +
                "FROM Screening WHERE Movie_id = "+FilmsCombobox.SelectedValue.ToString(),
                Theater);
            SqlCommand command = new SqlCommand("SELECT auditorium_id FROM Screening WHERE Movie_id = " + FilmsCombobox.SelectedValue.ToString(), Theater);
            hall = (Int32)command.ExecuteScalar();    


            DataSet screeningset = new DataSet();
            screeningAdapter.Fill(screeningset);
            ScreeningComboBox.DataSource = screeningset.Tables[0];
            ScreeningComboBox.DisplayMember = "INFO";
            ScreeningComboBox.ValueMember = "id";
        }

        private void ScreeningComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            SqlDataAdapter rowAdapter = new SqlDataAdapter("Select DISTINCT row FROM SEAT WHERE auditorium_id="+ hall,
               Theater);
            SqlCommand command = new SqlCommand("SELECT id FROM Screening WHERE Movie_id = " + FilmsCombobox.SelectedValue.ToString(), Theater); 
            screening = (Int32)command.ExecuteScalar();
            DataSet rowset = new DataSet();
            rowAdapter.Fill(rowset);
            RowComboBox.DataSource = rowset.Tables[0];
            RowComboBox.DisplayMember = "row";
            RowComboBox.ValueMember = "row";
        }

        private void RowComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlDataAdapter seatsAdapter = new SqlDataAdapter("Select id, number FROM SEAT WHERE row=" + RowComboBox.SelectedValue.ToString()+
                " and id not in (SELECT seat_id from reserved_seat WHERE screening_id ="+screening +") and auditorium_id="+ hall,
               Theater);
            DataSet seatsset = new DataSet();
            seatsAdapter.Fill(seatsset);
            SeatComboBox.DataSource = seatsset.Tables[0];
            SeatComboBox.DisplayMember = "number";
            SeatComboBox.ValueMember = "id";
        }

        private void AddSeat_Click(object sender, EventArgs e)
        {
            AddResrvation.Visible = true;

            reservedseats[i] = Int32.Parse(SeatComboBox.SelectedValue.ToString());
            i++;
        }

        private void AddResrvation_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("Insert into Reservation Values(" + screening + ",NULL,"+User_id +")", Theater);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT id from reservation where id=(select max(id) FROM reservation)", Theater);
                int Reservation = (Int32)command.ExecuteScalar();

                for (int j = 0; j < i; j++)
                {
                    command = new SqlCommand($"Insert into reserved_seat Values({reservedseats[j]}, {Reservation}, {screening})", Theater);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Места успешно забронированы");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, попробуйте еще раз");
            }
        }

        private void SeatComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AddSeat.Visible = true;
        }
    }
}