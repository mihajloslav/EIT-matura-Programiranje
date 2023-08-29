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
using System.Windows.Forms.DataVisualization.Charting;

namespace A14
{
    public partial class Grafikon : Form
    {
        Form1 form;
        string constring = @"Data Source=ACAN95\SQLEXPRESS; Initial Catalog=distribucija_lekova;Integrated Security=True";
        public Grafikon(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void Grafikon_Load(object sender, EventArgs e)
        {
            PopuniListView();
        }

        private void PopuniListView()
        {
            using (SqlConnection connection = new SqlConnection(constring))
            {
                string upit = "SELECT naziv FROM proizvodjac";
                SqlCommand command = new SqlCommand(upit, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nazivProizvodjaca = reader.GetString(0);

                    // Ovde možete dodati kod za prikazivanje naziva proizvođača, na primer dodati u CheckedListBox
                    checkedListBox1.Items.Add(nazivProizvodjaca);
                }

                // Obavezno zatvorite SqlDataReader objekat nakon završetka obrade podataka
                reader.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* private void button1_Click(object sender, EventArgs e)
         {


             // ...

             // Definisanje metode za izvršavanje SQL upita
             int IzvrsiSQLUpit(string query)
             {
                 int rezultat = 0;

                 using (SqlConnection connection = new SqlConnection(constring))
                 {
                     connection.Open();

                     using (SqlCommand command = new SqlCommand(query, connection))
                     {
                         // Izvršavanje upita i dobijanje skalarnog rezultata (u ovom slučaju broj lekova)
                         rezultat = (int)command.ExecuteScalar();
                     }
                 }

                 return rezultat;
             }

             Dictionary<string, int> podaci = new Dictionary<string, int>();

             // Iteriranje kroz sve stavke u CheckedListBox-u
             foreach (var item in checkedListBox1.CheckedItems)
             {
                 // Preuzimanje naziva proizvođača
                 string nazivProizvodjaca = item.ToString();

                 // Izvršavanje SQL upita da se dobije broj lekova za odabrani proizvođač
                 string query = $"SELECT COUNT(*) FROM Lek WHERE ProizvodjacID IN (SELECT ProizvodjacID FROM Proizvodjac WHERE Naziv = '{nazivProizvodjaca}')";

                 // Izvršavanje upita i dobijanje rezultata
                 int brojLekova = IzvrsiSQLUpit(query);

                 // Dodavanje podataka u rečnik
                 podaci.Add(nazivProizvodjaca, brojLekova);
             }

             // Kreiranje Chart kontrole

             // Podešavanje tipa dijagrama
             chart1.ChartAreas.Clear();
             chart1.Series.Clear();
             chart1.Legends.Clear();
             chart1.ChartAreas.Add("ChartArea1");
             chart1.Series.Add("Series1");
             chart1.Series["Series1"].ChartType = SeriesChartType.Pie;

             // Dodavanje podataka u Chart kontrolu
             foreach (var item in checkedListBox1.CheckedItems)
             {
                 string nazivProizvodjaca = item.ToString();

                 // Izvršavanje upita za dobijanje broja lekova za svakog proizvođača
                 string upitBrojLekova = "SELECT COUNT(*) FROM Lek WHERE ProizvodjacID = (SELECT ProizvodjacID FROM Proizvodjac WHERE Naziv = @NazivProizvodjaca)";
                 using (SqlConnection connection = new SqlConnection(constring))
                 {
                     SqlCommand command = new SqlCommand(upitBrojLekova, connection);
                     command.Parameters.AddWithValue("@NazivProizvodjaca", nazivProizvodjaca);
                     connection.Open();
                     int brojLekova = (int)command.ExecuteScalar();

                     // Dodavanje podataka u Chart kontrolu
                     chart1.Series["Series1"].Points.AddXY(nazivProizvodjaca, brojLekova);
                 }
             }

             // Prikazivanje legende
             chart1.Legends.Add("Legend1");

             // Dodavanje Chart kontrole na formu ili drugi kontejner
             this.Controls.Add(chart1);


         }
        */


        private void button1_Click(object sender, EventArgs e)
        {
         

            // Definisanje metode za izvršavanje SQL upita
            int IzvrsiSQLUpit(string query)
            {
                int rezultat = 0;

                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Izvršavanje upita i dobijanje skalarnog rezultata (u ovom slučaju broj lekova)
                        rezultat = (int)command.ExecuteScalar();
                    }
                }

                return rezultat;
            }

            Dictionary<string, int> podaci = new Dictionary<string, int>();

            // Iteriranje kroz sve stavke u CheckedListBox-u
            foreach (var item in checkedListBox1.CheckedItems)
            {
                // Preuzimanje naziva proizvođača
                string nazivProizvodjaca = item.ToString();

                // Izvršavanje SQL upita da se dobije broj lekova za odabrani proizvođač
                string query = $"SELECT COUNT(*) FROM Lek WHERE ProizvodjacID IN (SELECT ProizvodjacID FROM Proizvodjac WHERE Naziv = '{nazivProizvodjaca}')";

                // Izvršavanje upita i dobijanje rezultata
                int brojLekova = IzvrsiSQLUpit(query);

                // Dodavanje podataka u rečnik
                podaci.Add(nazivProizvodjaca, brojLekova);
            }

            // Kreiranje Chart kontrole
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.ChartAreas.Add("ChartArea1");
            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;

            // Dodavanje podataka u Chart kontrolu
            // Dodavanje podataka u Chart kontrolu
            foreach (var item in checkedListBox1.CheckedItems)
            {
                string nazivProizvodjaca = item.ToString();

                if (podaci.ContainsKey(nazivProizvodjaca))
                {
                    int brojLekova = podaci[nazivProizvodjaca];

                    // Dodavanje podataka u Chart kontrolu
                    chart1.Series["Series1"].Points.AddXY(brojLekova.ToString(), brojLekova);
                    chart1.Series["Series1"].Points.Last().LegendText = $"{nazivProizvodjaca}: {brojLekova}";
                }
            }


            // Prikazivanje legende
            chart1.Legends.Add("Legend1");

            // Dodavanje Chart kontrole na formu ili drugi kontejner
            this.Controls.Add(chart1);

        }

    }
}
