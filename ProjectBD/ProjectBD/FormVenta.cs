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
            LoadProducts(); // Load products when the form loads
        }

        private void InitializeCartDataTable()
        {
            cartDataTable = new DataTable();
            cartDataTable.Columns.Add("ID Producto", typeof(int));
            cartDataTable.Columns.Add("Nombre", typeof(string));
            cartDataTable.Columns.Add("Precio Unitario", typeof(decimal));
            cartDataTable.Columns.Add("Cantidad", typeof(int));
            cartDataTable.Columns.Add("Subtotal", typeof(decimal));

            dataGridViewCart.DataSource = cartDataTable;
            // Hide the ID column from the user
            dataGridViewCart.Columns["ID Producto"].Visible = false;
        }

        private void LoadProducts()
        {
            string query = "SELECT IdProducto, NombreProducto, PrecioUnitario FROM Productos WHERE Stock > 0";
            using (SqlDataReader reader = ConexionBD.ExecuteReader(query, CommandType.Text))
            {
                if (reader != null)
                {
                    DataTable productsTable = new DataTable();
                    productsTable.Load(reader);
                    cmbProducts.DataSource = productsTable;
                    cmbProducts.DisplayMember = "NombreProducto";
                    cmbProducts.ValueMember = "IdProducto";
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

            int productId = (int)cmbProducts.SelectedValue;
            string productName = cmbProducts.Text;
            decimal unitPrice = 0;

            // Get unit price from the selected product
            string priceQuery = "SELECT PrecioUnitario, Stock FROM Productos WHERE IdProducto = @IdProducto";
            SqlParameter[] priceParams = { new SqlParameter("@IdProducto", productId) };
            using (SqlDataReader reader = ConexionBD.ExecuteReader(priceQuery, CommandType.Text, priceParams))
            {
                if (reader != null && reader.Read())
                {
                    unitPrice = reader.GetDecimal(0);
                    int stock = reader.GetInt32(1);

                    if (quantity > stock)
                    {
                        MessageBox.Show($"No hay suficiente stock para {productName}. Stock disponible: {stock}", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            decimal subtotal = unitPrice * quantity;

            // Check if product already exists in cart
            DataRow existingRow = cartDataTable.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID Producto") == productId);

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
                    // 1. Insert into Ventas table
                    string insertVentaQuery = "INSERT INTO Ventas (FechaVenta, TotalVenta) VALUES (@FechaVenta, @TotalVenta); SELECT SCOPE_IDENTITY();";
                    SqlParameter[] ventaParams = {
                        new SqlParameter("@FechaVenta", DateTime.Now),
                        new SqlParameter("@TotalVenta", cartDataTable.AsEnumerable().Sum(row => row.Field<decimal>("Subtotal")))
                    };

                    SqlCommand ventaCmd = new SqlCommand(insertVentaQuery, connection, transaction);
                    ventaCmd.Parameters.AddRange(ventaParams);
                    int ventaId = Convert.ToInt32(ventaCmd.ExecuteScalar());

                    // 2. Insert into DetalleVenta and update Productos stock
                    string insertDetalleQuery = "INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal)";
                    string updateStockQuery = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto";

                    foreach (DataRow row in cartDataTable.Rows)
                    {
                        int productId = row.Field<int>("ID Producto");
                        int quantity = row.Field<int>("Cantidad");
                        decimal unitPrice = row.Field<decimal>("Precio Unitario");
                        decimal subtotal = row.Field<decimal>("Subtotal");

                        // Insert detalle
                        SqlParameter[] detalleParams = {
                            new SqlParameter("@IdVenta", ventaId),
                            new SqlParameter("@IdProducto", productId),
                            new SqlParameter("@Cantidad", quantity),
                            new SqlParameter("@PrecioUnitario", unitPrice),
                            new SqlParameter("@Subtotal", subtotal)
                        };
                        SqlCommand detalleCmd = new SqlCommand(insertDetalleQuery, connection, transaction);
                        detalleCmd.Parameters.AddRange(detalleParams);
                        detalleCmd.ExecuteNonQuery();

                        // Update stock
                        SqlParameter[] stockParams = {
                            new SqlParameter("@Cantidad", quantity),
                            new SqlParameter("@IdProducto", productId)
                        };
                        SqlCommand stockCmd = new SqlCommand(updateStockQuery, connection, transaction);
                        stockCmd.Parameters.AddRange(stockParams);
                        stockCmd.ExecuteNonQuery();
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
        }
    }
}
