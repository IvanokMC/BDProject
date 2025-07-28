using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBD; // Add this line

namespace ProjectBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ya no es necesario mostrar el mensaje de conexión exitosa aquí.
        }

        private void ArtistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDatosArtistas();
        }

        private void CargarDatosArtistas()
        {
            // Using the new helper method from ConexionBD
            string consulta = "SELECT id_artista, nombre_artistico, tipo_artista, pais_origen FROM Artista";
            using (SqlDataReader reader = ConexionBD.ExecuteReader(consulta, CommandType.Text))
            {
                if (reader != null)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void VentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVenta formVenta = new FormVenta();
            formVenta.Show();
        }
    }
}
