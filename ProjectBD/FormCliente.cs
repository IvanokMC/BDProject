using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectBD
{
    public partial class FormCliente : Form
    {
        private int clienteSeleccionadoId = -1; // Para almacenar el ID del cliente seleccionado

        public FormCliente()
        {
            InitializeComponent();
            CargarClientes();
            this.Load += new EventHandler(FormCliente_Load);
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlDataReader reader = ConexionBD.ExecuteReader("GetClientes", CommandType.StoredProcedure))
                {
                    if (reader != null)
                    {
                        dt.Load(reader);
                        dgvClientes.DataSource = dt;
                        dgvClientes.Columns["id_cliente"].Visible = false; // Ocultar la columna ID
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            txtDireccion.Clear();
            clienteSeleccionadoId = -1; // Resetear el ID seleccionado
            btnGuardarCliente.Text = "Guardar"; // Cambiar texto del botón a "Guardar"
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@nombre", txtNombre.Text.Trim()),
                    new SqlParameter("@correo_electronico", txtCorreo.Text.Trim()),
                    new SqlParameter("@contraseña", txtContrasena.Text),
                    new SqlParameter("@direccion", txtDireccion.Text.Trim())
                };

                int rowsAffected;
                if (clienteSeleccionadoId == -1)
                {
                    // Insertar nuevo cliente
                    rowsAffected = ConexionBD.ExecuteNonQuery("InsertCliente", CommandType.StoredProcedure, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el cliente. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Actualizar cliente existente
                    SqlParameter[] updateParameters = new SqlParameter[parameters.Length + 1];
                    parameters.CopyTo(updateParameters, 0);
                    updateParameters[parameters.Length] = new SqlParameter("@id_cliente", clienteSeleccionadoId);

                    rowsAffected = ConexionBD.ExecuteNonQuery("UpdateCliente", CommandType.StoredProcedure, updateParameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el cliente. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar/actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvClientes.SelectedRows[0];
                clienteSeleccionadoId = Convert.ToInt32(selectedRow.Cells["id_cliente"].Value);
                txtNombre.Text = selectedRow.Cells["nombre"].Value.ToString();
                txtCorreo.Text = selectedRow.Cells["correo_electronico"].Value.ToString();
                // No cargar la contraseña por seguridad
                txtDireccion.Text = selectedRow.Cells["direccion"].Value.ToString();
                btnGuardarCliente.Text = "Actualizar"; // Cambiar texto del botón a "Actualizar"
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId != -1)
            {
                // Los campos ya están cargados por dgvClientes_SelectionChanged
                // Solo aseguramos que el botón de guardar cambie a "Actualizar"
                btnGuardarCliente.Text = "Actualizar";
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId != -1)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Primero, eliminar los comprobantes de venta asociados a este cliente
                        SqlParameter[] deleteComprobantesParameters = {
                            new SqlParameter("@id_cliente", clienteSeleccionadoId)
                        };
                        ConexionBD.ExecuteNonQuery("DeleteComprobantesByCliente", CommandType.StoredProcedure, deleteComprobantesParameters);

                        // Luego, eliminar el cliente
                        SqlParameter[] deleteClienteParameters = {
                            new SqlParameter("@id_cliente", clienteSeleccionadoId)
                        };
                        int rowsAffected = ConexionBD.ExecuteNonQuery("DeleteCliente", CommandType.StoredProcedure, deleteClienteParameters);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            CargarClientes();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
