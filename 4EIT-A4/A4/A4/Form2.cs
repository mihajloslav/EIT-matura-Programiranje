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

namespace A4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=DESKTOP-U7PQ6SQ\\SQLEXPRESS;Initial Catalog=seoski_turizam;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {

            int minBrojRezervacija = (int)numericUpDown1.Value;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "select k.ime+k.prezime as Ime, r.rbr as Broj from klijent k INNER JOIN rezervacija r ON k.klijentid=r.klijentid where aktivanklijent='DA' AND r.rbr > @minBrojRezervacija";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@minBrojRezervacija", minBrojRezervacija);

                    SqlDataReader reader = command.ExecuteReader();

                    listView1.Items.Clear();
                    listView1.View = View.Details;

                    listView1.Columns.Add("Ime", 120);
                    listView1.Columns.Add("Broj", 120);

                    while (reader.Read())
                    {
                        string ime = reader.GetString(0);
                        int brojRezervacija = reader.GetInt32(1);

                        ListViewItem item = new ListViewItem(ime);
                        item.SubItems.Add(brojRezervacija.ToString());

                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška prilikom prikazivanja podataka: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
