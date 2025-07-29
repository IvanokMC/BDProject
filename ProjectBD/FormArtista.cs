using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectBD
{
    public partial class FormArtista : Form
    {
        private string artistaSeleccionadoId = null;

        public FormArtista()
        {
            InitializeComponent();
            CargarArtistas();
            cmbTipoArtista.SelectedIndex = 0; // Default to solista
        }

        private void FormArtista_Load(object sender, EventArgs e)
        {
            CargarArtistas();
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
                        dgvArtistas.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artistas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtIdArtista.Clear();
            txtNombreArtistico.Clear();
            cmbTipoArtista.SelectedIndex = 0;
            txtPaisOrigen.Clear();
            txtGeneroPrincipal.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            txtBiografia.Clear();
            txtImagen.Clear();
            txtNombreReal.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            cmbSexo.SelectedIndex = -1;
            dtpFechaFormacion.Value = DateTime.Now;
            dtpFechaDisolucion.Value = DateTime.Now;
            artistaSeleccionadoId = null;
            btnGuardarArtista.Text = "Guardar";
            txtIdArtista.ReadOnly = false;
        }

        private void cmbTipoArtista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoArtista.SelectedItem != null)
            {
                string tipo = cmbTipoArtista.SelectedItem.ToString();
                grpSolista.Visible = (tipo == "solista");
                grpGrupo.Visible = (tipo == "grupo");
            }
        }

        private void btnGuardarArtista_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdArtista.Text) ||
                string.IsNullOrWhiteSpace(txtNombreArtistico.Text) ||
                string.IsNullOrWhiteSpace(txtPaisOrigen.Text) ||
                string.IsNullOrWhiteSpace(txtGeneroPrincipal.Text))
            {
                MessageBox.Show("Por favor, complete los campos principales del artista.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tipo = cmbTipoArtista.SelectedItem.ToString();
                int rowsAffected = 0;

                if (artistaSeleccionadoId == null) // Insertar
                {
                    if (tipo == "solista")
                    {
                        SqlParameter[] parameters = {
                            new SqlParameter("@id_artista", txtIdArtista.Text.Trim()),
                            new SqlParameter("@nombre_artistico", txtNombreArtistico.Text.Trim()),
                            new SqlParameter("@pais_origen", txtPaisOrigen.Text.Trim()),
                            new SqlParameter("@genero_principal", txtGeneroPrincipal.Text.Trim()),
                            new SqlParameter("@fecha_inicio", dtpFechaInicio.Value),
                            new SqlParameter("@biografia", txtBiografia.Text.Trim()),
                            new SqlParameter("@imagen", txtImagen.Text.Trim()),
                            new SqlParameter("@nombre_real", txtNombreReal.Text.Trim()),
                            new SqlParameter("@fecha_nacimiento", dtpFechaNacimiento.Value),
                            new SqlParameter("@sexo", cmbSexo.SelectedItem.ToString())
                        };
                        rowsAffected = ConexionBD.ExecuteNonQuery("InsertArtistaSolista", CommandType.StoredProcedure, parameters);
                    }
                    else if (tipo == "grupo")
                    {
                        SqlParameter[] parameters = {
                            new SqlParameter("@id_artista", txtIdArtista.Text.Trim()),
                            new SqlParameter("@nombre_artistico", txtNombreArtistico.Text.Trim()),
                            new SqlParameter("@pais_origen", txtPaisOrigen.Text.Trim()),
                            new SqlParameter("@genero_principal", txtGeneroPrincipal.Text.Trim()),
                            new SqlParameter("@fecha_inicio", dtpFechaInicio.Value),
                            new SqlParameter("@biografia", txtBiografia.Text.Trim()),
                            new SqlParameter("@imagen", txtImagen.Text.Trim()),
                            new SqlParameter("@fecha_formacion", dtpFechaFormacion.Value),
                            new SqlParameter("@fecha_disolucion", dtpFechaDisolucion.Checked ? (object)dtpFechaDisolucion.Value : DBNull.Value)
                        };
                        rowsAffected = ConexionBD.ExecuteNonQuery("InsertGrupoMusical", CommandType.StoredProcedure, parameters);
                    }
                }
                else // Actualizar
                {
                    if (tipo == "solista")
                    {
                        SqlParameter[] parameters = {
                            new SqlParameter("@id_artista", artistaSeleccionadoId),
                            new SqlParameter("@nombre_artistico", txtNombreArtistico.Text.Trim()),
                            new SqlParameter("@pais_origen", txtPaisOrigen.Text.Trim()),
                            new SqlParameter("@genero_principal", txtGeneroPrincipal.Text.Trim()),
                            new SqlParameter("@fecha_inicio", dtpFechaInicio.Value),
                            new SqlParameter("@biografia", txtBiografia.Text.Trim()),
                            new SqlParameter("@imagen", txtImagen.Text.Trim()),
                            new SqlParameter("@nombre_real", txtNombreReal.Text.Trim()),
                            new SqlParameter("@fecha_nacimiento", dtpFechaNacimiento.Value),
                            new SqlParameter("@sexo", cmbSexo.SelectedItem.ToString())
                        };
                        rowsAffected = ConexionBD.ExecuteNonQuery("UpdateArtistaSolista", CommandType.StoredProcedure, parameters);
                    }
                    else if (tipo == "grupo")
                    {
                        SqlParameter[] parameters = {
                            new SqlParameter("@id_artista", artistaSeleccionadoId),
                            new SqlParameter("@nombre_artistico", txtNombreArtistico.Text.Trim()),
                            new SqlParameter("@pais_origen", txtPaisOrigen.Text.Trim()),
                            new SqlParameter("@genero_principal", txtGeneroPrincipal.Text.Trim()),
                            new SqlParameter("@fecha_inicio", dtpFechaInicio.Value),
                            new SqlParameter("@biografia", txtBiografia.Text.Trim()),
                            new SqlParameter("@imagen", txtImagen.Text.Trim()),
                            new SqlParameter("@fecha_formacion", dtpFechaFormacion.Value),
                            new SqlParameter("@fecha_disolucion", dtpFechaDisolucion.Checked ? (object)dtpFechaDisolucion.Value : DBNull.Value)
                        };
                        rowsAffected = ConexionBD.ExecuteNonQuery("UpdateGrupoMusical", CommandType.StoredProcedure, parameters);
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Artista guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarArtistas();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el artista. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar/actualizar el artista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvArtistas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArtistas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvArtistas.SelectedRows[0];
                artistaSeleccionadoId = selectedRow.Cells["id_artista"].Value.ToString();
                txtIdArtista.Text = artistaSeleccionadoId;
                txtIdArtista.ReadOnly = true; // No permitir cambiar el ID al editar
                txtNombreArtistico.Text = selectedRow.Cells["nombre_artistico"].Value.ToString();
                cmbTipoArtista.SelectedItem = selectedRow.Cells["tipo_artista"].Value.ToString();
                txtPaisOrigen.Text = selectedRow.Cells["pais_origen"].Value.ToString();
                txtGeneroPrincipal.Text = selectedRow.Cells["genero_principal"].Value.ToString();
                dtpFechaInicio.Value = Convert.ToDateTime(selectedRow.Cells["fecha_inicio"].Value);
                txtBiografia.Text = selectedRow.Cells["biografia"].Value.ToString();
                txtImagen.Text = selectedRow.Cells["imagen"].Value.ToString();

                if (cmbTipoArtista.SelectedItem.ToString() == "solista")
                {
                    txtNombreReal.Text = selectedRow.Cells["nombre_real_solista"].Value.ToString();
                    dtpFechaNacimiento.Value = Convert.ToDateTime(selectedRow.Cells["fecha_nacimiento_solista"].Value);
                    cmbSexo.SelectedItem = selectedRow.Cells["sexo_solista"].Value.ToString();
                }
                else if (cmbTipoArtista.SelectedItem.ToString() == "grupo")
                {
                    dtpFechaFormacion.Value = Convert.ToDateTime(selectedRow.Cells["fecha_formacion_grupo"].Value);
                    if (selectedRow.Cells["fecha_disolucion_grupo"].Value != DBNull.Value)
                    {
                        dtpFechaDisolucion.Value = Convert.ToDateTime(selectedRow.Cells["fecha_disolucion_grupo"].Value);
                        dtpFechaDisolucion.Checked = true;
                    }
                    else
                    {
                        dtpFechaDisolucion.Checked = false;
                    }
                }
                btnGuardarArtista.Text = "Actualizar";
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void btnEditarArtista_Click(object sender, EventArgs e)
        {
            if (artistaSeleccionadoId != null)
            {
                btnGuardarArtista.Text = "Actualizar";
            }
            else
            {
                MessageBox.Show("Seleccione un artista para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarArtista_Click(object sender, EventArgs e)
        {
            if (artistaSeleccionadoId != null)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este artista? Esto eliminará también sus álbumes y canciones asociadas.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SqlParameter[] parameters = {
                            new SqlParameter("@id_artista", artistaSeleccionadoId)
                        };
                        int rowsAffected = ConexionBD.ExecuteNonQuery("DeleteArtista", CommandType.StoredProcedure, parameters);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Artista eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            CargarArtistas();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el artista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el artista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un artista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}