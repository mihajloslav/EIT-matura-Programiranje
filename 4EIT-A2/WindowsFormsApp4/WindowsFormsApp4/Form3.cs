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
namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        Autor glavna;
        public Form3(Autor autor)
        {
            InitializeComponent();
            glavna = autor;
            PodaciComboBox();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            


        }



        public void PodaciComboBox()
        {
            //glavna je glavna forma, moguce je pisati i lokalne prom na formi
            glavna.conn.Open();
            glavna.komanda.CommandText="SELECT Ime, Prezime FROM Autor";
            glavna.komanda.Connection = glavna.conn;
            glavna.dr = glavna.komanda.ExecuteReader();
            while (glavna.dr.Read())
            {
                string ime = glavna.dr["Ime"].ToString();
                string prezime = glavna.dr["Prezime"].ToString();

                string punoIme = ime + " " + prezime;
                comboBox1.Items.Add(punoIme);
            }

            glavna.dr.Close();
            glavna.conn.Close();
        }
        int odabraniAutor = 1;
      
        private void button_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Series series = new Series("Broj iznajmljivanja");
            series.ChartType = SeriesChartType.Line;
            foreach (ListViewItem item in listView1.Items)
            {
                string godina = item.SubItems[0].Text;
                int brojIznajmljivanja = int.Parse(item.SubItems[1].Text);

                series.Points.AddXY(godina, brojIznajmljivanja);
            }
            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Godina";
            chart1.ChartAreas[0].AxisY.Title = "Broj iznajmljivanja";


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            odabraniAutor = comboBox1.SelectedIndex;
            odabraniAutor++;




            listView1.Clear();
            glavna.conn.Open();
            glavna.komanda.CommandText = "SELECT YEAR(nc.DatumUzimanja) AS Godina, COUNT(*) AS BrojIznajmljivanja FROM " +
                "NaCitanju nc INNER JOIN Knjiga k ON nc.KnjigaID = k.KnjigaID INNER JOIN Napisali n ON k.KnjigaID = n.KnjigaID " +
                "INNER JOIN Autor a ON n.AutorID = a.AutorID WHERE a.AutorID = " + (odabraniAutor) +
                " AND nc.DatumUzimanja >= DATEADD(YEAR, -" +
                numericUpDown1.Value +
                ", GETDATE()) " +
                "GROUP BY YEAR(nc.DatumUzimanja) ORDER BY YEAR(nc.DatumUzimanja)";
            // glavna.komanda.Parameters.AddWithValue("@AutorID", 2);
            //glavna.komanda.Parameters.AddWithValue("@BrojGodina", numericUpDown1.Value.ToString());
            glavna.komanda.Connection = glavna.conn;
            // glavna.dr = glavna.komanda.ExecuteReader();

            SqlDataAdapter adapter = new SqlDataAdapter(glavna.komanda);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Prikazivanje rezultata u ListView
            listView1.View = View.Details;
            listView1.Columns.Add("Godina");
            listView1.Columns.Add("Broj iznajmljivanja");

            foreach (DataRow row in table.Rows)
            {
                ListViewItem item = new ListViewItem(row["Godina"].ToString());
                item.SubItems.Add(row["BrojIznajmljivanja"].ToString());
                listView1.Items.Add(item);
            }

            glavna.dr.Close();
            glavna.conn.Close();
        }

    }
}
