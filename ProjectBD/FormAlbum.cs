using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectBD
{
    public partial class FormAlbum : Form
    {
        private int albumSeleccionadoId = -1;

        public FormAlbum()
        {
            InitializeComponent();
            CargarArtistas();
            CargarAlbums();
        }

        private void FormAlbum_Load(object sender, EventArgs e)
        {
            CargarAlbums();
        }

        private void CargarArtistas()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlDataReader reader = ConexionBD.ExecuteReader("GetArtistas", CommandType.StoredProcedure))
                {
                    if (reader != null)
                    {
                        dt.Load(reader);
                        cmbArtista.DataSource = dt;
                        cmbArtista.DisplayMember = "nombre";
                        cmbArtista.ValueMember = "id_artista";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artistas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAlbums()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlDataReader reader = ConexionBD.ExecuteReader("GetAlbums", CommandType.StoredProcedure))
                {
                    if (reader != null)
                    {
                        dt.Load(reader);
                        dgvAlbums.DataSource = dt;
                        dgvAlbums.Columns["id_album"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar álbumes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            cmbArtista.SelectedIndex = -1;
            txtAnioLanzamiento.Clear();
            txtGenero.Clear();
            albumSeleccionadoId = -1;
            btnGuardarAlbum.Text = "Guardar";
        }

        private void btnGuardarAlbum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                cmbArtista.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtAnioLanzamiento.Text) ||
                string.IsNullOrWhiteSpace(txtGenero.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@titulo", txtTitulo.Text.Trim()),
                    new SqlParameter("@id_artista", Convert.ToInt32(cmbArtista.SelectedValue)),
                    new SqlParameter("@anio_lanzamiento", Convert.ToInt32(txtAnioLanzamiento.Text.Trim())),
                    new SqlParameter("@genero", txtGenero.Text.Trim())
                };

                int rowsAffected;
                if (albumSeleccionadoId == -1)
                {
                    rowsAffected = ConexionBD.ExecuteNonQuery("InsertAlbum", CommandType.StoredProcedure, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Álbum guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el álbum. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SqlParameter[] updateParameters = new SqlParameter[parameters.Length + 1];
                    parameters.CopyTo(updateParameters, 0);
                    updateParameters[parameters.Length] = new SqlParameter("@id_album", albumSeleccionadoId);

                    rowsAffected = ConexionBD.ExecuteNonQuery("UpdateAlbum", CommandType.StoredProcedure, updateParameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Álbum actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el álbum. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LimpiarCampos();
                CargarAlbums();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar/actualizar el álbum: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAlbums_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAlbums.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAlbums.SelectedRows[0];
                albumSeleccionadoId = Convert.ToInt32(selectedRow.Cells["id_album"].Value);
                txtTitulo.Text = selectedRow.Cells["titulo"].Value.ToString();
                cmbArtista.SelectedValue = Convert.ToInt32(selectedRow.Cells["id_artista"].Value);
                txtAnioLanzamiento.Text = selectedRow.Cells["anio_lanzamiento"].Value.ToString();
                txtGenero.Text = selectedRow.Cells["genero"].Value.ToString();
                btnGuardarAlbum.Text = "Actualizar";
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void btnEditarAlbum_Click(object sender, EventArgs e)
        {
            if (albumSeleccionadoId != -1)
            {
                btnGuardarAlbum.Text = "Actualizar";
            }
            else
            {
                MessageBox.Show("Seleccione un álbum para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarAlbum_Click(object sender, EventArgs e)
        {
            if (albumSeleccionadoId != -1)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este álbum?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Primero, eliminar las canciones asociadas a este álbum
                        SqlParameter[] deleteCancionesParameters = {
                            new SqlParameter("@id_album", albumSeleccionadoId)
                        };
                        ConexionBD.ExecuteNonQuery("DeleteCancionesByAlbum", CommandType.StoredProcedure, deleteCancionesParameters);

                        // Luego, eliminar el álbum
                        SqlParameter[] deleteAlbumParameters = {
                            new SqlParameter("@id_album", albumSeleccionadoId)
                        };
                        int rowsAffected = ConexionBD.ExecuteNonQuery("DeleteAlbum", CommandType.StoredProcedure, deleteAlbumParameters);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Álbum eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            CargarAlbums();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el álbum.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el álbum: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un álbum para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}