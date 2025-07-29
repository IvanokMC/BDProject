using System;
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
            // No es necesario mostrar el mensaje de conexión exitosa aquí.
        }

        private void btnGestionarMusica_Click(object sender, EventArgs e)
        {
            // Abrir el nuevo formulario de gestión de música
            FormMusica formMusica = new FormMusica();
            formMusica.Show();
        }

        private void btnGestionarVentas_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de ventas existente
            FormVenta formVenta = new FormVenta();
            formVenta.Show();
        }

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            // Abrir el nuevo formulario de gestión de clientes
            FormCliente formCliente = new FormCliente();
            formCliente.Show();
        }
    }
}
