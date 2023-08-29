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

namespace WindowsFormsApp5
{
    public partial class Form3 : Form
    {

        public string veza = @"Data Source=ACAN95\SQLEXPRESS;Initial Catalog=seoski_turizam; Integrated Security=True";
        public SqlConnection conn;
        public SqlCommand komanda;
        public SqlDataReader dr;
        public DataTable tabela1;
        string upit;



        void test()
        {
            try
            {
                listView1.Clear();
                conn = new SqlConnection(veza);
                komanda = new SqlCommand();
                komanda.Connection = conn;
                listView1.GridLines = true;
                listView1.Scrollable = true;
                listView1.FullRowSelect = true;
                listView1.View = View.Details;
                upit = $"SELECT K.Ime, K.Prezime " +
                    "FROM Klijent K JOIN( SELECT KlijentID, COUNT(KucicaID) AS BrojKupljenihAranzmana " +
                    "FROM Rezervacija GROUP BY KlijentID " +
                    $"HAVING COUNT(KucicaID) > {numericUpDown1.Value} ) R ON K.KlijentID = R.KlijentID";
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
                {
                    string newItem = UkloniPraznineSaKraja(dt.Rows[i][j].ToString());
                    red.SubItems.Add(newItem);
                  
                }
                lv.Items.Add(red);
            }
        }


        public string UkloniPraznineSaKraja(string tekst)
        {
            if (string.IsNullOrEmpty(tekst))
            {
                return tekst;
            }

            int duzina = tekst.Length;
            int indeks = duzina - 1;

            while (indeks >= 0 && char.IsWhiteSpace(tekst[indeks]))
            {
                indeks--;
            }

            return tekst.Substring(0, indeks + 1);
        }


        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test();
        }
    }
}
