using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    { 
        public string veza = @"Data Source=ACAN95\SQLEXPRESS;Initial Catalog=seoski_turizam; Integrated Security=True";
        public SqlConnection conn;
        public SqlCommand komanda;
        public SqlDataReader dr;
        public DataTable tabela1;
        string upit;

        public Form1()
        {
            InitializeComponent();
            test();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }





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
                upit = "SELECT S.SeloID, S.Naziv, G.Grad FROM Selo S INNER JOIN Grad G ON S.GradID = G.GradID";
                Napuni(NapuniDataTable(dr, komanda, upit), listView1);
                listView1.Show();
                conn.Close();
                comboBox1.Sorted = true;
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
            comboBox1.Items.Clear();
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
                    if (j == 2)
                    {
                       
                        if (!comboBox1.Items.Contains(newItem))
                        {
                            comboBox1.Items.Add(newItem);
                        }
                    }

                }
                lv.Items.Add(red);
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
                    comboBox1.SelectedIndex = comboBox1.FindStringExact(lvc.SubItems[2].Text);
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* string grad = comboBox1.SelectedItem.ToString();
            ListViewItem trazeniItem = null;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[2].Text == grad) // Proverite da li tekst odgovara kriterijumu
                {
                    trazeniItem = item;
                    break; // Prekinite petlju ako je pronađen odgovarajući red
                }
            }
            trazeniItem.Selected = true;
            textBox1.Text=  trazeniItem.SubItems[0].Text;
            textBox1.Text = trazeniItem.SubItems[1].Text;*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool IsDigitsOnly(string str)
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                        return false;
                }

                return true;
            }
            bool postoji = false;
            if (textBox1.Text != "") {
                if (IsDigitsOnly(textBox1.Text))
                {
                    ListViewItem trazeniItem = null;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text == textBox1.Text) // Proverite da li tekst odgovara kriterijumu
                        {
                            trazeniItem = item;
                            postoji = true;
                            break; // Prekinite petlju ako je pronađen odgovarajući red
                        }
                        
                    }
                    if (postoji)
                    {
                        textBox2.Text = trazeniItem.SubItems[1].Text;
                        comboBox1.SelectedIndex = comboBox1.FindString(trazeniItem.SubItems[2].Text);

                    }
                    else
                    { textBox2.Text = string.Empty;
                        comboBox1.Text = string.Empty;
                    }

                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string upit2;
            string logMessage = string.Empty;
            if (textBox1.Text != string.Empty)
            {
                try
                {
                    conn.Open();
                    komanda.Connection = conn;
                    upit2 = $"UPDATE Selo SET Naziv = '{UkloniPraznineSaKraja(textBox2.Text)}'," +
                            $" GradID = (SELECT GradID FROM Grad WHERE Grad = '{UkloniPraznineSaKraja(comboBox1.Text)}') " +
                            $"WHERE SeloID = {UkloniPraznineSaKraja(textBox1.Text)}";
                    komanda.CommandText = upit2;
                    int affectedRows = komanda.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Promena je uspešno izvršena.");
                    }
                    else
                    {
                        MessageBox.Show("Promena nije izvršena.");
                        logMessage = $"Datum pokušaja izmene: {DateTime.Now}, Razlog neuspešnosti: Nema ažuriranih redova.";
                        File.AppendAllText("error.txt", logMessage + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške prilikom izmene.");
                    logMessage = $"Datum pokušaja izmene: {DateTime.Now}, Razlog neuspešnosti: {ex.Message}";
                    File.AppendAllText("error.txt", logMessage + Environment.NewLine);
                }
                finally
                {
                    conn.Close();
                }

                test();
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
    }
