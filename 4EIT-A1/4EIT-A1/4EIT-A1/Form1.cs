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
using System.Diagnostics;
using System.IO;
namespace _4EIT_A1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand komanda;
        SqlDataReader dr;
        DataTable dt,combo,dtgrid;
        int odg, dog;
        string veza;

        protected override bool 
            ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtcid_Validated(object sender, EventArgs e)
        {
            string trazi;
            int brc = int.Parse(txtcid.Text);
            komanda = new SqlCommand();
            trazi = "SELECT * FROM CITALAC " +
                    " WHERE CitalacID = " + brc.ToString();
            komanda.Connection = conn;
            komanda.CommandText = trazi;
            DataTable rezultat = new DataTable();
            try
            {
                conn.Open();
                dr = komanda.ExecuteReader();
                button1.Enabled = false;
                 if(dr.HasRows) 
                { 
                rezultat.Load(dr);    
                txtjmbg.Text = rezultat.Rows[0]["MaticniBr"].ToString();
                txtime.Text = rezultat.Rows[0]["ime"].ToString();
                txtprez.Text = rezultat.Rows[0]["Prezime"].ToString();
                txtadr.Text = rezultat.Rows[0]["Adresa"].ToString();
                }
                else
                {
                    MessageBox.Show("Citalac ne postoji !!!");
                    txtcid.Text = "";
                    txtjmbg.Text = "";
                    txtime.Text = "";
                    txtprez.Text = "";
                    txtadr.Text = "";
                }
            }
            catch(Exception gr)
            {
                MessageBox.Show(gr.ToString());

            }
            finally
            { conn.Close(); }

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
           
           
            string sql;
            if (e.TabPage == tabPage1)
            {
                komanda = new SqlCommand();
                sql = " Select * from CITALAC";
                komanda.Connection = conn;
                komanda.CommandText = sql;

                lvcitaoci.GridLines = true;
                lvcitaoci.Scrollable = true;
                lvcitaoci.FullRowSelect = true;
                lvcitaoci.View = View.Details;
                try
                {
                    conn.Open();
                    dr = komanda.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    conn.Close();
                    NapuniLV(dt, lvcitaoci);
                    lvcitaoci.Show();


                }
                catch(Exception greska)
                { MessageBox.Show(greska.ToString()); }
                finally
                { conn.Close(); }
            }
            else if(e.TabPage == tabPage2)
            {
                
                komanda = new SqlCommand();
                string stavka = "SELECT CitalacID , Ime , Prezime FROM Citalac";
                komanda.Connection = conn;
                komanda.CommandText = stavka;
                combo = new DataTable();
               // cbcitalac.Items.Clear();
                try
                {
                    conn.Open();
                    dr = komanda.ExecuteReader();
                    combo = new DataTable();
                    combo.Load(dr);
                    
                    for(int i=0;i<combo.Rows.Count;i++)
                    {
                        cbcitalac.Items.Add(combo.Rows[i][0].ToString().PadLeft(4) +
                       "-"+combo.Rows[i][1].ToString().PadLeft(10) + 
                       combo.Rows[i][2]).ToString().PadLeft(15);
                    }
                    
                   // cbcitalac.DataSource = combo;
                    cbcitalac.ValueMember = combo.Columns[0].ToString();
                    cbcitalac.SelectedValue = 4;
                   // cbcitalac.DisplayMember = combo.Columns[1].ToString().Trim() + combo.Columns[0].ToString().Trim(); ;
                }
                catch(Exception gr)
                {
                    MessageBox.Show(gr.Message);
                }
                finally { conn.Close(); }
            }
            else
            {
               
              // Process.Start("http://www.google.com");
               Process.Start( "D:/uputstvo.pdf");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            veza = @"Data Source=FSERVER\SQLEXPRESS;Initial Catalog=Biblioteka1;Integrated Security=True";

            conn = new SqlConnection();
            conn.ConnectionString = veza;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            /*
            string dodaj = "INSERT INTO CITALAC(MaticniBR,Ime,Prezime,Adresa) "+
                     " VALUES('"+ txtjmbg.Text + "','" +
                       txtime.Text + "','" + txtprez.Text + "','" + 
                       txtadr.Text  +"')";
            */
            string dodaj = "INSERT INTO CITALAC(MaticniBR,Ime,Prezime,Adresa) " +
                    " VALUES(@jmbg,@ime,@prez,@adr)";
            komanda = new SqlCommand();

            komanda.Parameters.Clear();
            komanda.Parameters.AddWithValue("@jmbg", txtjmbg.Text);
            komanda.Parameters.AddWithValue("@ime", txtime.Text);
            komanda.Parameters.AddWithValue("@prez", txtprez.Text);
            komanda.Parameters.AddWithValue("@adr", txtadr.Text);

            komanda.Connection = conn;
            komanda.CommandText = dodaj;
            try
            {
                conn.Open();
                int n = komanda.ExecuteNonQuery();
                conn.Close();
                if (n == 1)
                {
                    komanda = new SqlCommand();
                    komanda.Connection = conn;
                    komanda.CommandText = "SELECT * FROM CITALAC";
                    conn.Open();
                    dr = komanda.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    conn.Close();
                    NapuniLV(dt, lvcitaoci);
                    lvcitaoci.Show();
                    MessageBox.Show("Uspesan upis");
                    string path ="log_"+DateTime.Now.Month.ToString()+
                                        DateTime.Now.Day.ToString()+
                                        DateTime.Now.Year.ToString()+".txt";
                    File.AppendAllText(path, txtjmbg.Text + Environment.NewLine);

                    txtjmbg.Text = txtime.Text = txtprez.Text = txtadr.Text = "";
                    button1.Enabled = false;
                   
                    
                }
                else
                    MessageBox.Show("GRESKA-Dodavanje novog Citaoca nije uspelo !!!");
            }
            catch (Exception gr)
            {
                MessageBox.Show(gr.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void NapuniLV(DataTable dt,ListView lv)
        {
            lv.Items.Clear();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ColumnHeader col = new ColumnHeader();
                col.Text = dt.Columns[i].Caption;
                lv.Columns.Add(col);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem red = new ListViewItem(
                    dt.Rows[i][0].ToString(), i);
                for (int j = 1; j < dt.Columns.Count; j++)
                    red.SubItems.Add(dt.Rows[i][j].ToString());
                lv.Items.Add(red);
            }
        }

        private void lvcitaoci_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem lvc;
            if (lvcitaoci.SelectedItems.Count > 0)
            {
                lvc = lvcitaoci.SelectedItems[0];             
                    txtcid.Text = lvc.SubItems[0].Text;
                    txtjmbg.Text = lvc.SubItems[1].Text;
                    txtime.Text = lvc.SubItems[2].Text;
                    txtprez.Text = lvc.SubItems[3].Text;
                    txtadr.Text = lvc.SubItems[4].Text;                
            }
        }

       

        private void txtime_Validated(object sender, EventArgs e)
        {
            if (txtjmbg.Text != "" && txtime.Text != "" && txtprez.Text != "")
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbcitalac_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = cbcitalac.SelectedIndex;
            odg = Convert.ToInt32(numericUpDown1.Value);
            dog = Convert.ToInt32(numericUpDown2.Value);
            int citID = Convert.ToInt32(combo.Rows[n]["CitalacID"].ToString());
            string citaoci = "Select N.CitalacID , Prezime ,Ime, " +
          " YEAR(N.DatumUzimanja) As Godina," +
          " COUNT(KNJIGAID) as Uzeo ," +
          " (SELECT COUNT(KNJIGAID) FROM NACITANJU S " +
          " WHERE DATUMVRACANJA IS NULL GROUP BY S.CitalacID,YEAR(S.DatumUzimanja) " +
          " HAVING S.CitalacID = N.CitalacID AND YEAR(S.DatumUzimanja) = YEAR(N.DatumUzimanja)) As ZADRZAO " +
          " FROM NaCitanju N INNER JOIN CITALAC C " +
          " ON N.CitalacID = C.CitalacID " +
          " WHERE YEAR(N.DatumUzimanja) >= " + odg.ToString() +
          " AND YEAR(N.DatumUzimanja) <= " + dog.ToString() +
          " AND N.CitalacID = "+citID.ToString() +
          " GROUP BY N.CitalacID, Ime ,Prezime,YEAR(N.DatumUzimanja)  ";

            komanda = new SqlCommand();
            komanda.Connection = conn;
            komanda.CommandText = citaoci;
            dtgrid = new DataTable();

            try
            {
                conn.Open();
                dr = komanda.ExecuteReader();
                dtgrid = new DataTable();
                dtgrid.Load(dr);
                conn.Close();
                dgcitaoci.DataSource = null;
                dgcitaoci.Rows.Clear();
                dgcitaoci.DataSource = dtgrid;

                chartbox1.DataSource = dtgrid;
                chartbox1.Series.Clear();
                for(int i =4;i<6;i++)
                {
                    Series serija = new Series();
                    foreach (DataRow drv in dtgrid.Rows)
                        serija.Points.AddXY(drv["Godina"], drv[i]);
                    serija.Name = dtgrid.Columns[i].ColumnName;
                    chartbox1.Series.Add(serija);

                }
                

            }
            catch(Exception gr)
            {
                MessageBox.Show(gr.Message);
            }
            finally { conn.Close(); }


         

        }
    }
}
