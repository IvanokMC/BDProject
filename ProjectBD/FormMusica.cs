using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectBD
{
    public partial class FormMusica : Form
    {
        public FormMusica()
        {
            InitializeComponent();
        }

        private void btnSearchArtistas_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchTerm.Text.Trim();
            SqlParameter[] parameters = { new SqlParameter("@nombre_artistico_filtro", string.IsNullOrEmpty(searchTerm) ? (object)DBNull.Value : searchTerm) };
            LoadData("GetArtistas", parameters);
        }

        private void btnSearchCanciones_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchTerm.Text.Trim();
            SqlParameter[] parameters = {
                new SqlParameter("@titulo_filtro", string.IsNullOrEmpty(searchTerm) ? (object)DBNull.Value : searchTerm),
                new SqlParameter("@genero_filtro", (object)DBNull.Value), // Puedes añadir un campo para filtrar por género si lo necesitas
                new SqlParameter("@artista_filtro", (object)DBNull.Value) // Puedes añadir un campo para filtrar por artista si lo necesitas
            };
            LoadData("GetCanciones", parameters);
        }

        private void btnSearchAlbums_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchTerm.Text.Trim();
            SqlParameter[] parameters = {
                new SqlParameter("@titulo_filtro", string.IsNullOrEmpty(searchTerm) ? (object)DBNull.Value : searchTerm),
                new SqlParameter("@artista_filtro", (object)DBNull.Value) // Puedes añadir un campo para filtrar por artista si lo necesitas
            };
            LoadData("GetAlbums", parameters);
        }

        private void LoadData(string storedProcedureName, SqlParameter[] parameters)
        {
            using (SqlDataReader reader = ConexionBD.ExecuteReader(storedProcedureName, CommandType.StoredProcedure, parameters))
            {
                if (reader != null)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvResultados.DataSource = dt;
                }
            }
        }

        private void btnAgregarCancion_Click(object sender, EventArgs e)
        {
            FormCancion formCancion = new FormCancion();
            // Si el formulario de agregar canción se cierra con éxito, refrescar los datos
            if (formCancion.ShowDialog() == DialogResult.OK)
            {
                // Refrescar la lista de canciones si se estaba mostrando
                btnSearchCanciones_Click(null, null); 
            }
        }

        private void btnGestionarAlbums_Click(object sender, EventArgs e)
        {
            FormAlbum formAlbum = new FormAlbum();
            formAlbum.ShowDialog();
        }

        private void btnGestionarArtistas_Click(object sender, EventArgs e)
        {
            FormArtista formArtista = new FormArtista();
            formArtista.ShowDialog();
        }
    }
}