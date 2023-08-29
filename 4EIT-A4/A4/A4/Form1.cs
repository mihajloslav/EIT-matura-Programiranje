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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace A4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection=new SqlConnection("Data Source=DESKTOP-U7PQ6SQ\\SQLEXPRESS;Initial Catalog=seoski_turizam;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();

        private void NapuniCB()
        {
            try
            {
                connection.Open();

                string query = "SELECT grad FROM grad";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Text = reader.GetString(0);
                    string grad = reader["grad"].ToString();
                    comboBox1.Items.Add(grad);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom učitavanja gradova: " + ex.Message);
            }
            finally
            {
               
                    connection.Close();
            }
        }
        private void NapuniLV()
        {
            try
            {
                connection.Open();

                string query = "SELECT s.seloid,s.naziv,g.grad FROM selo s JOIN grad g ON s.gradid=g.gradid ";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                listView1.Items.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("seloid", 120);
                listView1.Columns.Add("naziv", 120);
                listView1.Columns.Add("grad", 120);

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(row["seloid"].ToString());
                    item.SubItems.Add(row["naziv"].ToString());
                    item.SubItems.Add(row["grad"].ToString());


                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom učitavanja članova biblioteke: " + ex.Message);
            }
            finally
            {
                
                    connection.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NapuniLV();
            NapuniCB();  
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sifraSela = textBox1.Text;

            try
            {
                connection.Open();

                string query = "SELECT s.naziv, g.grad FROM selo s JOIN grad g ON s.gradid = g.gradid WHERE s.seloid = @sifraSela";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sifraSela", sifraSela);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    textBox2.Text = reader["naziv"].ToString();
                    comboBox1.SelectedItem = reader["grad"].ToString();
                }
                else
                {
                    MessageBox.Show("Ne postoji selo sa unesenom šifrom.");
                    textBox2.Text = string.Empty;
                    comboBox1.SelectedItem = null;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom dohvaćanja podataka: " + ex.Message);
            }
            finally
            {
              
                    connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sifraSela = textBox1.Text;
            string nazivSela = textBox2.Text;
            string grad = comboBox1.SelectedItem?.ToString();

            try
            {
                connection.Open();

                string updateQuery = "UPDATE selo SET naziv = @naziv, gradid = (SELECT gradid FROM grad WHERE grad = @grad) WHERE seloid = @sifraSela";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@naziv", nazivSela);
                updateCommand.Parameters.AddWithValue("@grad", grad);
                updateCommand.Parameters.AddWithValue("@sifraSela", sifraSela);
                updateCommand.ExecuteNonQuery();

                MessageBox.Show("Podaci su uspješno ažurirani.");
        
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text == sifraSela)
                    {
                        item.SubItems[1].Text = nazivSela;
                        item.SubItems[2].Text = grad;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom ažuriranja podataka: " + ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show(); 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
