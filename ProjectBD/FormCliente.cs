using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectBD
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
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
                    new SqlParameter("@contraseña", txtContrasena.Text), // La contraseña se maneja en la app, cifrada idealmente
                    new SqlParameter("@direccion", txtDireccion.Text.Trim())
                };

                int rowsAffected = ConexionBD.ExecuteNonQuery("InsertCliente", CommandType.StoredProcedure, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar campos después de guardar
                    txtNombre.Clear();
                    txtCorreo.Clear();
                    txtContrasena.Clear();
                    txtDireccion.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cliente. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
