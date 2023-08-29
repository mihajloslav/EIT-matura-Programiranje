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

namespace WindowsFormsApp4
{
    public partial class Autor : Form
    {
        public int a = 2;
        public string veza = @"Data Source=ACAN95\SQLEXPRESS; Initial Catalog=BibliotekaA2;Integrated Security=True";
        public SqlConnection conn;
        public SqlCommand komanda;
        public SqlDataReader dr;
        public DataTable tabela1;
        string upit;
        public DataTable NapuniDataTable(SqlDataReader dr, SqlCommand komanda, string upitt)
        {
            DataTable TabelaReturn;
            TabelaReturn = new DataTable();
            try
            {
                conn.Open();
                komanda.CommandText = upitt;
                dr = komanda.ExecuteReader();
                TabelaReturn.Load(dr);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "greska 2");

            }
            finally
            {

            }
            conn.Close();

            return TabelaReturn;
        }

        public Autor()
        {
            InitializeComponent();
            try
            {
                conn = new SqlConnection(veza);
                komanda = new SqlCommand();
                komanda.Connection = conn;
                listView1.GridLines = true;
                listView1.Scrollable = true;
                listView1.FullRowSelect = true;
                listView1.View = View.Details;
                upit = "select * from autor";
                Napuni(NapuniDataTable(dr, komanda, upit), listView1);
                listView1.Show();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("GRESKA!");
            }
            finally
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvc = listView1.SelectedItems[0];
                if (lvc != null)
                {
                    textBox1.Text = lvc.SubItems[0].Text;
                    textBox2.Text = lvc.SubItems[1].Text;
                    textBox3.Text = lvc.SubItems[2].Text;
                    textBox4.Text = lvc.SubItems[3].Text;
                }
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form formica = new Form2();
            formica.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form formica3 = new Form3(this);
            formica3.ShowDialog();
        }

        private void Autor_Load(object sender, EventArgs e)
        {

        }


        public void Napuni(DataTable dt, ListView lv)
        {
            lv.Items.Clear();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ColumnHeader col = new ColumnHeader();
                col.Text = dt.Columns[i].ColumnName;
                lv.Columns.Add(col);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem red = new ListViewItem(dt.Rows[i][0].ToString(), i);
                for (int j = 1; j < dt.Columns.Count; j++)
                    red.SubItems.Add(dt.Rows[i][j].ToString());
                lv.Items.Add(red);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                int autorID = int.Parse(selectedRow.SubItems[0].Text);
                conn.Open();
                string upit = "DELETE FROM Autor WHERE AutorID = @AutorID";
                using (SqlCommand komanda = new SqlCommand(upit, conn))
                {
                    komanda.Parameters.AddWithValue("@AutorID", autorID);
                    komanda.ExecuteNonQuery();
                }
                conn.Close();
            }
            upit = "SELECT * FROM Autor";
            DataTable tabela = NapuniDataTable(dr, komanda, upit);
            Napuni(tabela, listView1);
        
        }
    }
}
