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
using System.Windows.Forms.DataVisualization.Charting;

namespace _4EIT_A4
{
    public partial class UlovForm : Form
    {
        public UlovForm()
        {
            InitializeComponent();
        }
        string veza = "#";
        private void btizadji_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UlovForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(veza))
            {

                connection.Open();

                string query = "SELECT PecarosID, Ime, Prezime FROM Pecaros";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int pecarosID = reader.GetInt32(0);
                    string ime = reader.GetString(1);
                    string prezime = reader.GetString(2);
                    string pecarosText = $"{pecarosID}-{ime} {prezime}";

                    cbpecaros.Items.Add(pecarosText);
                }
                reader.Close();
                connection.Close();
            }
        }

        private void btprikazi_Click(object sender, EventArgs e)
        {
            string selectedPecaros = cbpecaros.SelectedItem.ToString();
            int pecarosID = int.Parse(selectedPecaros.Split('-')[0]);

            DateTime datumOd = dtpod.Value.Date;
            DateTime datumDo = dtpdo.Value.Date.AddDays(1); 

            string query = @"SELECT V.naziv AS Vrsta, COUNT(*) AS Broj
                FROM ulov U
                INNER JOIN vrsta_ribe V ON U.Vrstaid = V.Vrstaid
                WHERE U.PecarosID = @pecarosID
                AND U.datum >= @datumOd AND U.datum < @datumDo
                GROUP BY V.naziv";

            using (SqlConnection connection = new SqlConnection(veza))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@pecarosID", pecarosID);
                command.Parameters.AddWithValue("@datumOd", datumOd);
                command.Parameters.AddWithValue("@datumDo", datumDo);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvulov.DataSource = dataTable;
                connection.Close();
            }
            chartulov.Series.Clear();

            Series series = new Series("Ulov");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;

            foreach (DataGridViewRow row in dgvulov.Rows)
            {
                string vrsta = row.Cells["Vrsta"].Value.ToString();
                int broj = int.Parse(row.Cells["Broj"].Value.ToString());
                series.Points.AddXY(vrsta, broj);
            }

            chartulov.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            chartulov.Series.Add(series);
            chartulov.Legends[0].Enabled = true;
            chartulov.Legends[0].Docking = Docking.Right;
        }
    }
}
