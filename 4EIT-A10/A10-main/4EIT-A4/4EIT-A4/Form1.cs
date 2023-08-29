using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4EIT_A4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string veza = "#";

        private void Form1_Load(object sender, EventArgs e)
        {
            UcitajPecarose();
            UcitajGradove();
        }
        private void lbpecarosi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbpecarosi.SelectedIndex >= 0)
            {
                string selectedpecaros = lbpecarosi.SelectedItem.ToString();
                string[] pecarosData = selectedpecaros.Split('\t');

                tbsifra.Text = pecarosData[0].TrimEnd();
                tbime.Text = pecarosData[1].TrimEnd();
                tbprezime.Text = pecarosData[2].TrimEnd();
                tbadresa.Text = pecarosData[3].TrimEnd();
                cbgrad.SelectedItem = pecarosData[4].TrimEnd();
                tbtelefon.Text = pecarosData[5].TrimEnd();
            }
        }

        private void UcitajPecarose()
        {
            using (SqlConnection conn = new SqlConnection(veza))
            {
                string query = "SELECT pecarosID, ime, prezime, adresa, g.grad, telefon FROM pecaros p INNER JOIN grad g ON p.gradid = g.gradid";
                SqlCommand command = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                lbpecarosi.Items.Clear();

                while (reader.Read())
                {
                    int sifra = reader.GetInt32(0);
                    string ime = reader.GetString(1);
                    string prezime = reader.GetString(2);
                    string adresa = reader.GetString(3);
                    string grad = reader.GetString(4);
                    string telefon = reader.GetString(5);

                    string listItem = $"{sifra}\t{ime}\t{prezime}\t{adresa}\t{grad}\t{telefon}";
                    lbpecarosi.Items.Add(listItem);
                }

                reader.Close();
            }
        }

        private void UcitajGradove()
        {
            string query = "SELECT Grad from Grad ORDER BY Grad ASC";
            using (SqlConnection conn = new SqlConnection(veza))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string grad = reader.GetString(0).TrimEnd();
                    cbgrad.Items.Add(grad);
                }

                reader.Close();
            }
        }

        private void btizmeni_Click(object sender, EventArgs e)
        {
            if (lbpecarosi.SelectedIndex >= 0)
            {
                string selectedpecaros = lbpecarosi.SelectedItem.ToString();
                string[] pecarosData = selectedpecaros.Split(new string[] { "\t" }, StringSplitOptions.None);

                int pecarosID = int.Parse(pecarosData[0].Trim());
                string ime = tbime.Text.Trim();
                string prezime = tbprezime.Text.Trim();
                string adresa = tbadresa.Text.Trim();
                string gradID = GetSelectedGradID();
                string telefon = tbtelefon.Text.Trim();

                using (SqlConnection connection = new SqlConnection(veza))
                {
                    string query = "UPDATE Pecaros SET ime = @ime, prezime = @prezime, adresa = @adresa, telefon = @telefon, gradID = @gradID WHERE pecarosID = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ime", ime);
                    command.Parameters.AddWithValue("@prezime", prezime);
                    command.Parameters.AddWithValue("@adresa", adresa);
                    command.Parameters.AddWithValue("@telefon", telefon);
                    command.Parameters.AddWithValue("@gradID", gradID);
                    command.Parameters.AddWithValue("@id", pecarosID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lbpecarosi.Items.Clear();
                            UcitajPecarose();
                            MessageBox.Show("Podaci su uspešno ažurirani.", "Ažuriranje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Došlo je do greške prilikom ažuriranja podataka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Došlo je do greške prilikom ažuriranja podataka: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private string GetSelectedGradID()
        {
            string grad = cbgrad.SelectedItem.ToString();
            string gradID = "";

            using (SqlConnection connection = new SqlConnection(veza))
            {
                string query = "SELECT gradID FROM Grad WHERE Grad = @grad";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@grad", grad);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    gradID = result.ToString();
                }
            }

            return gradID;
        }

        private void btizlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string text = @"Aplikacija ""Ribolovačko društvo"" omogućava upravljanje podacima o pecarošima, njihovoj opremi i ulovima riba. Sledeće funkcionalnosti su dostupne:

Prikazivanje podataka o pecarošima:

Na glavnoj formi se nalazi meni koji omogućava navigaciju kroz aplikaciju.
Pored menija se nalazi ListBox kontrola u kojoj se prikazuju podaci o svim pecarošima (šifra, ime, prezime, adresa, grad i telefon).
Na formi su takođe postavljena pojedinačna polja za prikaz izabranog pecaroša.
Inicijalno se pojedinačna polja popunjavaju podacima pecaroša koji ima najmanju vrednost šifre.
Kada korisnik selektuje red u ListBox kontroli, podaci selektovanog pecaroša se prikazuju u pojedinačnim poljima forme.
Vrednosti u pojedinačnim poljima, osim šifre, mogu se menjati.
ComboBox kontrola omogućava izbor grada i sadrži sve dostupne gradove sortirane po abecednom poretku.
Ažuriranje podataka o pecarošu:

Klikom na stavku menija ""Izmeni"" otvara se forma za izmenu podataka o pecarošu.
Sve vrednosti polja o prikazanom pecarošu se upisuju u bazu.
Nakon ažuriranja podataka, prikaz u ListBox kontroli se osvežava.
Poruka o uspešnosti izmene podataka se prikazuje u MessageBox-u.
Analiza ulova riba:

Klikom na stavku menija ""Analiza"" otvara se forma sa grafikonom za prikaz ukupnog broja riba ulovljenih od strane pecaroša u određenom vremenskom intervalu.
Na formi se nalazi ComboBox kontrola za odabir pecaroša.
ComboBox prikazuje šifru, ime i prezime pecaroša sortirane po šifri u rastućem redosledu.
Klikom na dugme ""Prikaži rezultati"" se prikazuju rezultati upita u kontrolama za tabelarni prikaz podataka i crta se grafik.
Dugme ""Izađi"" zatvara otvorenu formu i vraća na početnu formu.
O aplikaciji:

Klikom na stavku menija ""O aplikaciji"" otvara se kratko korisničko uputstvo.
U korisničkom uputstvu se nalaze informacije o funkcionalnostima aplikacije i načinu korišćenja.
---Napravio: Mihajlo Ranđelović IV-1 
---Kontakt: onlymihajlo@gmail.com";

            MessageBox.Show(text, "Korisničko uputstvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btanaliza_Click(object sender, EventArgs e)
        {
            UlovForm ulov = new UlovForm();
            ulov.ShowDialog();
        }
    }
}