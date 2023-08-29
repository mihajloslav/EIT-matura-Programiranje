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

namespace EIT_A6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string connectionString = "Data Source=DESKTOP-HM15PG6;Initial Catalog=Polovni_Automobili;Integrated Security=True";

        private void Form1_Load(object sender, EventArgs e)
        {
            UcitajListuModela();
            lbuputstvo.Text = "Na prvom tabu, možete pretraživati modele automobila unosom šifre u odgovarajuće polje i klikom na dugme sa ikonom lupe. \n" +
                " Ako se model pronađe, prikazaće se informacije o njemu. Možete izmeniti proizvođača ili naziv modela klikom na dugme Izmeni.\n" +
                " Klikom na dugme Izađi možete zatvoriti aplikaciju. ";
            lbuputstvo2.Text = "Na drugom tabu, pomoću numericke kontrole možete postaviti opseg godišta i uneti kilometražu.\n" +
                " Klikom na dugme Prikazi prikazuju se automobili koji odgovaraju unetim kriterijumima u tabelarnom obliku.\n" +
                " Takođe, prikazuju se podaci o broju automobila po modelu u grafikonu.";
            lbuputstvo3.Text = "Na trećem tabu možete pronaći kratko korisničko uputstvo i dokumentaciju o aplikaciji.";
        }

        private void UcitajListuModela()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ModelID, Naziv FROM Model";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int modelId = (int)reader["ModelID"];
                    string naziv = (string)reader["Naziv"];

                    listBox1.Items.Add(new ModelItem(modelId, naziv));
                }

                reader.Close();
            }
        }

        private void btntrazi_Click(object sender, EventArgs e)
        {
            int selectedModelId = int.Parse(txtsifra.Text);

            ModelItem selectedModel = listBox1.Items
                .OfType<ModelItem>()
                .FirstOrDefault(item => item.ModelId == selectedModelId);

            if (selectedModel != null)
            {
                listBox1.SelectedItem = selectedModel;
                PrikaziModel(selectedModel);
            }
            else
            {
                ObrisiModel();
                MessageBox.Show("Greska, takav model ne postoji.");
            }
        }

      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ModelItem selectedModel)
            {
                PrikaziModel(selectedModel);
            }
        }

        private void PrikaziModel(ModelItem model)
        {
            txtproizvodjac.Text = ImeProizvodjaca(model.ModelId);
            txtnaziv.Text = model.Naziv;
        }

        private void ObrisiModel()
        {
            txtproizvodjac.Text = string.Empty;
            txtnaziv.Text = string.Empty;
        }

        private void btnizmeni_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ModelItem selectedModel)
            {
                string proizvodjac = txtproizvodjac.Text;
                string nazivmodela = txtnaziv.Text;

                if (!string.IsNullOrEmpty(proizvodjac) && !string.IsNullOrEmpty(nazivmodela))
                {
                    if (UpdateModel(selectedModel.ModelId, proizvodjac, nazivmodela))
                    {
                        listBox1.Items.Remove(selectedModel);
                        selectedModel.Naziv = nazivmodela;
                        listBox1.Items.Add(selectedModel);
                        listBox1.SelectedItem = selectedModel;
                        MessageBox.Show("Model uspesno update-ovan");
                    }
                    else
                    {
                        MessageBox.Show("Greska, pokusajte ponovo.");
                    }
                }
                else
                {
                    MessageBox.Show("Ime proizvodjaca i modela mora biti uneto.");
                }
            }
        }

        private bool UpdateModel(int modelId, string proizvodjac, string modelName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string komanda = "UPDATE Model SET Naziv = @Naziv WHERE ModelID = @ModelID";
                SqlCommand cmd = new SqlCommand(komanda, connection);
                cmd.Parameters.AddWithValue("@ModelID", modelId);
                cmd.Parameters.AddWithValue("@Naziv", modelName);

                connection.Open();
                int dodajred = cmd.ExecuteNonQuery();

                return dodajred > 0;
            }
        }

        private string ImeProizvodjaca(int modelId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string komanda = "SELECT P.Naziv FROM Proizvodjac P INNER JOIN Model M ON P.ProizvodjacID = M.ProizvodjacID WHERE M.ModelID = @ModelID";
                SqlCommand cmd = new SqlCommand(komanda, connection);
                cmd.Parameters.AddWithValue("@ModelID", modelId);

                connection.Open();
                string ime = (string)cmd.ExecuteScalar();

                return ime;
            }
        }

        private void btnizadji_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class ModelItem
        {
            public int ModelId { get; set; }
            public string Naziv { get; set; }

            public ModelItem(int modelId, string naziv)
            {
                ModelId = modelId;
                Naziv = naziv;
            }

            public override string ToString()
            {
                return Naziv;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprikazi_Click(object sender, EventArgs e)
        {
            int minYear = (int)nudOD.Value;
            int maxYear = (int)nudDO.Value;
            int kilometraza = int.Parse(txtkilometraza.Text);

            // Prikaz podataka u DataGridView kontroli
            UcitajVozilo(minYear, maxYear, kilometraza);

            // Prikaz podataka u Chart kontroli
            PrikaziChart();
        }

        private void UcitajVozilo(int minYear, int maxYear, int kilometraza)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT V.Registracija, V.Godina_proizvodnje, V.PredjenoKM, M.Naziv AS Model, B.Naziv AS Boja, G.Naziv AS Gorivo " +
                               "FROM Vozilo V " +
                               "INNER JOIN Model M ON V.ModelID = M.ModelID " +
                               "INNER JOIN Boja B ON V.BojaID = B.BojaID " +
                               "INNER JOIN Gorivo G ON V.GorivoID = G.GorivoID " +
                               "WHERE V.Godina_proizvodnje >= @MinYear AND V.Godina_proizvodnje <= @MaxYear AND V.PredjenoKM <= @Mileage";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MinYear", minYear);
                command.Parameters.AddWithValue("@MaxYear", maxYear);
                command.Parameters.AddWithValue("@Mileage", kilometraza);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void PrikaziChart()
        {
            chart1.Series.Clear();
            chart1.Series.Add("Broj vozila");
            chart1.Series["Broj vozila"].ChartType = SeriesChartType.Column;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string model = row.Cells["Model"].Value.ToString();
                int count = dataGridView1.Rows.Count;

                chart1.Series["Broj vozila"].Points.AddXY(model, count);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
