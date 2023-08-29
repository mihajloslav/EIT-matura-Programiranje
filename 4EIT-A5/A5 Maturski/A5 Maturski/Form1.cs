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

namespace A5_Maturski
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        DataTable dt;
        string veza;
        private void Form1_Load(object sender, EventArgs e)
        {
            NapuniCB();
            veza = @"Data Source=DOWHYGA\SQLEXPRESS;Initial Catalog=produzeni_boravak;Integrated Security=True";
            conn = new SqlConnection(veza);
            comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT * FROM Aktivnosti";

            listView1.GridLines = true;
            listView1.Scrollable = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;

            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                conn.Close();
                NapuniLV(dt, listView1);
                listView1.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        private void NapuniCB ()
        {
            string dan;
            List<string> list = new List<string>();
            list.Add(dan="ponedeljak");
            list.Add(dan = "utorak");
            list.Add(dan = "sreda");
            list.Add(dan = "cetvrtak");
            list.Add(dan = "petak");
            list.Add(dan = "subota");
            list.Add(dan = "nedelja");
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = dan;
        }
        private void NapuniLV(DataTable dt, ListView lv)
        {
            listView1.Items.Clear();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ColumnHeader col = new ColumnHeader();
                col.Text = dt.Columns[i].Caption;
                listView1.Columns.Add(col);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem red = new ListViewItem(dt.Rows[i][0].ToString(), i);
                for (int j = 1; j < dt.Columns.Count; j++)
                    red.SubItems.Add(dt.Rows[i][j].ToString());
                listView1.Items.Add(red);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                txtSifra.Text = selectedItem.SubItems[0].Text;
                txtNaziv.Text = selectedItem.SubItems[1].Text;
                comboBox1.SelectedText = selectedItem.SubItems[2].Text;
                txtPocetak.Text = selectedItem.SubItems[3].Text;
                txtZavrsetak.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSifra.Text != "" || txtNaziv.Text != "" || txtPocetak.Text != "" || txtZavrsetak.Text != "")
            {
                string naziv = txtNaziv.Text;
                string dan = comboBox1.SelectedItem.ToString() ;
                string pocetak = txtPocetak.Text;
                string kraj = txtZavrsetak.Text;
                string upit = "INSERT INTO Aktivnosti " +
                    "VALUES(@naziv,@dan,@pocetak,@kraj)";

                using (SqlConnection connection = new SqlConnection(veza))
                {
                    using (SqlCommand command = new SqlCommand(upit, connection))
                    {
                        command.Parameters.AddWithValue("naziv", naziv);
                        command.Parameters.AddWithValue("dan", dan);
                        command.Parameters.AddWithValue("pocetak", pocetak);
                        command.Parameters.AddWithValue("kraj", kraj);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
            }
            else
                MessageBox.Show("Neispravno uneti podaci!!!", "Greska", MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Statistika f2 = new Statistika();
            f2.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
