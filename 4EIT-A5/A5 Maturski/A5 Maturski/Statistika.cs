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
using System.Windows.Forms.DataVisualization;

namespace A5_Maturski
{
    public partial class Statistika : Form
    {
        public Statistika()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand comm;
        DataTable dt;
        SqlDataAdapter adapter;
        string veza;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string upit = "SELECT naziv_aktivnosti as Naziv, count(DeteID) as 'BrojDece' FROM registar_aktivnosti " +
            "INNER JOIN aktivnosti ON registar_aktivnosti.aktivnostID=aktivnosti.aktivnostiID group by naziv_aktivnosti";
            veza = @"Data Source=DOWHYGA\SQLEXPRESS;Initial Catalog=produzeni_boravak;Integrated Security=True";
            conn = new SqlConnection(veza);
            comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = upit;

            try
            {

                conn.Open();
                dt = new DataTable();
                adapter = new SqlDataAdapter(upit, conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                chart1.DataSource = dt;
                conn.Close();
                chart1.Series.Clear();
                chart1.Series.Add("Izvestaj");
                chart1.Series["Izvestaj"].XValueMember = "Naziv";
                chart1.Series["Izvestaj"].YValueMembers = "BrojDece";
                chart1.DataBind();
                chart1.Titles.Add("Izvestaj");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
  
        }
    }
}
