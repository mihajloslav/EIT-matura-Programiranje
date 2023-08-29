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

namespace A14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        DataTable dt;
        string query;
        string sql;
        private void Form1_Load(object sender, EventArgs e)
        {
            query = @"Data Source=ACAN95\SQLEXPRESS; Initial Catalog=distribucija_lekova;Integrated Security=True";
            connection = new SqlConnection();
            connection.ConnectionString = query;
            command = new SqlCommand();
            sql = "SELECT l.lekID, l.proizvodjacID, l.naziv_leka, l.nezasticeno_ime, p.naziv " +
                "FROM lek l INNER JOIN proizvodjac p ON l.proizvodjacID = p.proizvodjacID ORDER BY naziv_leka ASC";
            command.Connection = connection;
            command.CommandText = sql;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                connection.Close();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void RefreshDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(query))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM lek", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void brisi_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali lek za brisanje!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Da li ste sigurni da zelite da obrisete odabrani lek?", "Potvrda brisanja.", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (result == DialogResult.No) { return; }
            else
            {
                int lekID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["lekID"].Value);
                using (SqlConnection connection = new SqlConnection(query))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM lek WHERE lekID = @lekID", connection);
                    command.Parameters.AddWithValue("@lekID", lekID);
                    command.ExecuteNonQuery();
                }
                RefreshDataGrid();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string nazivLeka = selectedRow.Cells["naziv_leka"].Value.ToString();
                string nazivProizvodjaca = selectedRow.Cells["naziv"].Value.ToString();
                tbLek.Text = nazivLeka;
                tbProizvodjac.Text = nazivProizvodjaca;
            }
            else
            {
                tbLek.Text = String.Empty;
                tbProizvodjac.Text = String.Empty;
            }
        }

        private void analiza_Click(object sender, EventArgs e)
        {
            Grafikon grafikon = new Grafikon(this);
            grafikon.ShowDialog();
        }
    }
}
