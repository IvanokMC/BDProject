using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Required for SQL operations

namespace ProjectBD
{
    public partial class FormVenta : Form
    {
        private DataTable cartDataTable; // DataTable to hold items in the shopping cart

        public FormVenta()
        {
            InitializeComponent();
            InitializeCartDataTable();
            LoadClients(); // Load clients when the form loads
            LoadProducts(); // Load products when the form loads
        }

        private void InitializeCartDataTable()
        {
            cartDataTable = new DataTable();
            cartDataTable.Columns.Add("ID Producto", typeof(string)); // Changed to string to match TId (VARCHAR)
            cartDataTable.Columns.Add("Nombre", typeof(string));
            cartDataTable.Columns.Add("Precio Unitario", typeof(decimal));
            cartDataTable.Columns.Add("Cantidad", typeof(int));
            cartDataTable.Columns.Add("Subtotal", typeof(decimal));

            dataGridViewCart.DataSource = cartDataTable;
            // Hide the ID column from the user
            dataGridViewCart.Columns["ID Producto"].Visible = false;
        }

        private void LoadClients()
        {
            string query = "SELECT id_cliente, nombre FROM Cliente";
            using (SqlDataReader reader = ConexionBD.ExecuteReader(query, CommandType.Text))
            {
                if (reader != null)
                {
                    DataTable clientsTable = new DataTable();
                    clientsTable.Load(reader);

                    // Add a default "Select Client" option
                    DataRow defaultRow = clientsTable.NewRow();
                    defaultRow["id_cliente"] = 0; // Use 0 as a placeholder for "no selection" (since id_cliente is INT NOT NULL)
                    defaultRow["nombre"] = "-- Seleccione un Cliente --";
                    clientsTable.Rows.InsertAt(defaultRow, 0);

                    cmbClientes.DataSource = clientsTable;
                    cmbClientes.DisplayMember = "nombre";
                    cmbClientes.ValueMember = "id_cliente";
                }
            }
        }

        private void LoadProducts()
        {
            // Modified to use 'Producto' table and its columns from MelodiaUrbana.sql
            string query = "SELECT id_producto, titulo, precio_unitario FROM Producto";
            using (SqlDataReader reader = ConexionBD.ExecuteReader(query, CommandType.Text))
            {
                if (reader != null)
                {
                    DataTable productsTable = new DataTable();
                    productsTable.Load(reader);
                    cmbProducts.DataSource = productsTable;
                    cmbProducts.DisplayMember = "titulo"; // Display 'titulo' from Producto table
                    cmbProducts.ValueMember = "id_producto"; // Use 'id_producto' as value
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productId = cmbProducts.SelectedValue.ToString(); // Changed to string
            string productName = cmbProducts.Text;
            decimal unitPrice = 0;

            // Get unit price from the selected product
            // Modified to use 'Producto' table and 'id_producto'
            string priceQuery = "SELECT precio_unitario FROM Producto WHERE id_producto = @id_producto";
            SqlParameter[] priceParams = { new SqlParameter("@id_producto", productId) };
            using (SqlDataReader reader = ConexionBD.ExecuteReader(priceQuery, CommandType.Text, priceParams))
            {
                if (reader != null && reader.Read())
                {
                    unitPrice = reader.GetDecimal(0);
                    // Stock check removed as 'Stock' column is not in MelodiaUrbana.sql's Producto table
                }
            }

            decimal subtotal = unitPrice * quantity;

            // Check if product already exists in cart
            DataRow existingRow = cartDataTable.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID Producto") == productId); // Changed to string

            if (existingRow != null)
            {
                // Update quantity and subtotal
                existingRow["Cantidad"] = existingRow.Field<int>("Cantidad") + quantity;
                existingRow["Subtotal"] = existingRow.Field<decimal>("Subtotal") + subtotal;
            }
            else
            {
                // Add new row to cart
                cartDataTable.Rows.Add(productId, productName, unitPrice, quantity, subtotal);
            }

            CalculateTotal();
            txtQuantity.Clear();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewCart.SelectedRows[0].Index;
                cartDataTable.Rows.RemoveAt(rowIndex);
                CalculateTotal();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto del carrito para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalculateTotal()
        {
            decimal total = cartDataTable.AsEnumerable().Sum(row => row.Field<decimal>("Subtotal"));
            lblTotal.Text = $"Total: {total:C}"; // Format as currency
        }

        private void btnProcessSale_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue == null || cmbClientes.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cartDataTable.Rows.Count == 0)
            {
                MessageBox.Show("El carrito de ventas está vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Start a transaction
            using (SqlConnection connection = ConexionBD.GetOpenConnection())
            {
                if (connection == null) return;
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. Insert into ComprobanteVenta using stored procedure
                    int idCliente = Convert.ToInt32(cmbClientes.SelectedValue); // Get selected client ID

                    SqlParameter idComprobanteParam = new SqlParameter("@id_comprobante", SqlDbType.Int);
                    idComprobanteParam.Direction = ParameterDirection.Output;

                    SqlParameter[] comprobanteParams = {
                        new SqlParameter("@id_cliente", idCliente),
                        new SqlParameter("@fecha_venta", DateTime.Now), // Can be NULL to use GETDATE() in SP
                        idComprobanteParam
                    };

                    SqlCommand comprobanteCmd = new SqlCommand("InsertComprobanteVenta", connection, transaction);
                    comprobanteCmd.CommandType = CommandType.StoredProcedure;
                    comprobanteCmd.Parameters.AddRange(comprobanteParams);
                    comprobanteCmd.ExecuteNonQuery();

                    int ventaId = Convert.ToInt32(idComprobanteParam.Value); // Get the newly generated comprobante ID

                    // 2. Insert into DetalleVenta using stored procedure
                    // Note: The SQL schema for DetalleVenta does not include 'Cantidad' or 'Subtotal'.
                    // It only has 'id_comprobante', 'id_producto', 'precio_unitario'.
                    // We will use the 'Precio Unitario' from the cart for 'precio_unitario' in DetalleVenta.
                    // The 'Cantidad' and 'Subtotal' from the cart will not be directly inserted into DetalleVenta.
                    // Also, the 'Productos' table and its 'Stock' column are not in the provided MelodiaUrbana.sql schema.
                    // The stock update logic will be commented out.

                    foreach (DataRow row in cartDataTable.Rows)
                    {
                        string productId = row.Field<string>("ID Producto"); // Changed to string
                        // int quantity = row.Field<int>("Cantidad"); // Not directly used for DetalleVenta insertion
                        decimal unitPrice = row.Field<decimal>("Precio Unitario");
                        // decimal subtotal = row.Field<decimal>("Subtotal"); // Not directly used for DetalleVenta insertion

                        // Insert detalle using stored procedure
                        SqlParameter[] detalleParams = {
                            new SqlParameter("@id_comprobante", ventaId),
                            new SqlParameter("@id_producto", productId),
                            new SqlParameter("@precio_unitario", unitPrice)
                        };
                        SqlCommand detalleCmd = new SqlCommand("InsertDetalleVenta", connection, transaction);
                        detalleCmd.CommandType = CommandType.StoredProcedure;
                        detalleCmd.Parameters.AddRange(detalleParams);
                        detalleCmd.ExecuteNonQuery();

                        // The following stock update logic is commented out because the 'Productos' table
                        // and 'Stock' column are not present in the provided MelodiaUrbana.sql schema.
                        // If you have a 'Stock' column in your 'Producto' table or a separate 'Inventario' table,
                        // you would need a stored procedure to handle stock updates.
                        /*
                        SqlParameter[] stockParams = {
                            new SqlParameter("@Cantidad", quantity),
                            new SqlParameter("@IdProducto", productId)
                        };
                        SqlCommand stockCmd = new SqlCommand(updateStockQuery, connection, transaction);
                        stockCmd.Parameters.AddRange(stockParams);
                        stockCmd.ExecuteNonQuery();
                        */
                    }

                    transaction.Commit();
                    MessageBox.Show("Venta procesada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearSale();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al procesar la venta: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Ocurrió un error inesperado al procesar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClearSale_Click(object sender, EventArgs e)
        {
            ClearSale();
        }

        private void ClearSale()
        {
            cartDataTable.Clear();
            CalculateTotal();
            txtQuantity.Clear();
            cmbProducts.SelectedIndex = -1; // Clear product selection
            LoadProducts(); // Reload products to reflect updated stock
            cmbClientes.SelectedIndex = 0; // Reset client selection
        }
    }
}