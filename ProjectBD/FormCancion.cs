using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace ProjectBD
{
    public partial class FormCancion : Form
    {
        public FormCancion()
        {
            InitializeComponent();
        }

        private void FormCancion_Load(object sender, EventArgs e)
        {
            LoadArtistas();
            LoadAlbums();
            // Inicializar el estado del ComboBox de álbum según el checkbox
            chkEsSencillo_CheckedChanged(sender, e);
            // Asegurarse de que un formato esté seleccionado por defecto
            if (cmbFormato.Items.Count > 0)
            {
                cmbFormato.SelectedIndex = 0;
            }
        }

        private void LoadArtistas()
        {
            string query = "SELECT id_artista, nombre_artistico FROM Artista";
            using (SqlDataReader reader = ConexionBD.ExecuteReader(query, CommandType.Text))
            {
                if (reader != null)
                {
                    DataTable artistasTable = new DataTable();
                    artistasTable.Load(reader);

                    DataRow defaultRow = artistasTable.NewRow();
                    defaultRow["id_artista"] = ""; // Usar cadena vacía para el valor por defecto
                    defaultRow["nombre_artistico"] = "-- Seleccione un Artista Principal --";
                    artistasTable.Rows.InsertAt(defaultRow, 0);

                    cmbArtistaPrincipal.DataSource = artistasTable;
                    cmbArtistaPrincipal.DisplayMember = "nombre_artistico";
                    cmbArtistaPrincipal.ValueMember = "id_artista";
                }
            }
        }

        private void LoadAlbums()
        {
            string query = "SELECT A.id_producto, P.titulo FROM Album A JOIN Producto P ON A.id_producto = P.id_producto";
            using (SqlDataReader reader = ConexionBD.ExecuteReader(query, CommandType.Text))
            {
                if (reader != null)
                {
                    DataTable albumsTable = new DataTable();
                    albumsTable.Load(reader);

                    DataRow defaultRow = albumsTable.NewRow();
                    defaultRow["id_producto"] = ""; // Usar cadena vacía para el valor por defecto
                    defaultRow["titulo"] = "-- Seleccione un Álbum (Opcional) --";
                    albumsTable.Rows.InsertAt(defaultRow, 0);

                    cmbAlbum.DataSource = albumsTable;
                    cmbAlbum.DisplayMember = "titulo";
                    cmbAlbum.ValueMember = "id_producto";
                }
            }
        }

        private void chkEsSencillo_CheckedChanged(object sender, EventArgs e)
        {
            cmbAlbum.Enabled = !chkEsSencillo.Checked;
            if (chkEsSencillo.Checked)
            {
                cmbAlbum.SelectedIndex = 0; // Seleccionar la opción por defecto si es sencillo
            }
        }

        private string GenerateNewProductId()
        {
            // Obtener el último ID de producto para generar uno nuevo
            string maxId = null;
            string query = "SELECT MAX(id_producto) FROM Producto WHERE id_producto LIKE 'P%'";
            object result = ConexionBD.ExecuteScalar(query, CommandType.Text);

            if (result != null && result != DBNull.Value)
            {
                maxId = result.ToString();
            }

            int nextNumber = 1;
            if (maxId != null && maxId.Length > 1 && maxId.StartsWith("P"))
            {
                string numberPart = maxId.Substring(1);
                if (int.TryParse(numberPart, out int currentNumber))
                {
                    nextNumber = currentNumber + 1;
                }
            }
            // Formatear a P0000X
            return "P" + nextNumber.ToString("D5");
        }

        private void btnGuardarCancion_Click(object sender, EventArgs e)
        {
            // 1. Validar entradas
            // Ahora también valida que el id_artista principal no sea una cadena vacía
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtDuracion.Text) ||
                string.IsNullOrWhiteSpace(txtGenero.Text) ||
                cmbFormato.SelectedItem == null || // Cambiado a SelectedItem
                cmbArtistaPrincipal.SelectedValue == null || string.IsNullOrEmpty(cmbArtistaPrincipal.SelectedValue.ToString()))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (Título, Precio, Duración, Género, Formato, Artista Principal).", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Por favor, ingrese un precio válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan duracion;
            if (!TimeSpan.TryParse(txtDuracion.Text, out duracion))
            {
                MessageBox.Show("Por favor, ingrese una duración válida en formato HH:MM:SS.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idAlbum = null;
            if (!chkEsSencillo.Checked && cmbAlbum.SelectedValue != null && cmbAlbum.SelectedValue != DBNull.Value)
            {
                idAlbum = cmbAlbum.SelectedValue.ToString();
            }

            string idArtistaPrincipal = cmbArtistaPrincipal.SelectedValue.ToString();

            // 2. Generar un nuevo ID de producto para la canción
            string newProductId = GenerateNewProductId();

            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@id_producto", newProductId),
                    new SqlParameter("@titulo", txtTitulo.Text.Trim()),
                    new SqlParameter("@precio_unitario", precio),
                    new SqlParameter("@duracion", duracion),
                    new SqlParameter("@formato", cmbFormato.SelectedItem.ToString()),
                    new SqlParameter("@genero", txtGenero.Text.Trim()),
                    new SqlParameter("@es_sencillo", chkEsSencillo.Checked),
                    new SqlParameter("@id_album", (object)idAlbum ?? DBNull.Value),
                    new SqlParameter("@id_artista_principal", idArtistaPrincipal)
                };

                int rowsAffected = ConexionBD.ExecuteNonQuery("InsertCancion", CommandType.StoredProcedure, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Canción guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Indicar éxito al formulario padre
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la canción. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la canción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
