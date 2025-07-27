using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                if (conexion != null)
                {
                    string consulta = "SELECT id_artista, nombre_artistico, tipo_artista, pais_origen FROM Artista";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
