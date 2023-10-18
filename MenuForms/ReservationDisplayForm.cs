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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sql_Database_FilmTheater_FirstTry.MenuForms
{
    public partial class ReservationDisplayForm : Form
    {
        private int user_id;
        private SqlConnection Theater = null;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\программирование\\всякое\\Sql_Database_FilmTheater_FirstTry\\Sql_Database_FilmTheater_FirstTry\\FilmTheater.mdf;Integrated Security=True";

        public ReservationDisplayForm(int id)
        {
            user_id = id;
            InitializeComponent();

        }

        private void ReservationDisplayForm_Load(object sender, EventArgs e)
        {
            Theater = new SqlConnection
                (connectionString);
            Theater.Open();
            SqlDataAdapter reservationsAdapter = new SqlDataAdapter("Select id, (Select CONCAT(screening_start, N' Зал: ' +Cast(auditorium_id as VARCHAR(2) )) FROM screening " +
                "WHERE screening.id=screening_id), (SELECT Count(seat_id) FROM reserved_seat WHERE reservation_id=reservation.id) AS Количество_билетов " +
                " FROM Reservation Where customer_id=@userid",
               Theater);
            reservationsAdapter.SelectCommand.Parameters.AddWithValue("@userid", user_id);
            DataSet Reservationset = new DataSet();

            reservationsAdapter.Fill(Reservationset);

            ReservationDataGrid.DataSource = Reservationset.Tables[0];

            DataGridViewColumn column = ReservationDataGrid.Columns[1];
            column.Width = 240;

            column = ReservationDataGrid.Columns[2];
            column.Width = 140;

            ReservationDataGrid.Columns[0].Visible=false;
        }

        private void ReservationDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            
            if (ReservationDataGrid.SelectedRows.Count == 1)
            {
                textBox1.Visible = true;
                Theater = new SqlConnection
                (connectionString);
                Theater.Open();
                SqlDataAdapter seatsAdapter = new SqlDataAdapter("SELECT(SELECT row FROM seat where seat_id=seat.id) AS Ряд," +
                    " (SELECT number FROM seat where seat_id=seat.id) AS Номер FROM reserved_seat where reservation_id=@res_id",
                   Theater);
                DataRow row = (ReservationDataGrid.SelectedRows[0].DataBoundItem as DataRowView).Row;
                
                seatsAdapter.SelectCommand.Parameters.AddWithValue("@res_id", row["id"]);
                DataSet Seatsset = new DataSet();

                seatsAdapter.Fill(Seatsset);

                SeatsDataGrid.DataSource = Seatsset.Tables[0];

                DataGridViewColumn column = SeatsDataGrid.Columns[0];
                column.Width = 40;

                column = SeatsDataGrid.Columns[1];
                column.Width = 80;
            }
        }
    }
}
