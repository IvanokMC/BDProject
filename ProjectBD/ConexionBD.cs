
using System;
using System.Data.SqlClient;
using System.Data; // Required for CommandType
using System.Windows.Forms; // For MessageBox, consider a logging framework in a real app
using System.Configuration; // Required for ConfigurationManager

namespace ProjectBD
{
    public static class ConexionBD
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MelodiaUrbana"].ConnectionString;

        // Helper method to get an open connection
        public static SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Executes a non-query command (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                if (connection == null) return -1; // Connection failed

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        return command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al ejecutar la operación: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }
        }

        // Executes a query and returns a SqlDataReader
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection connection = GetOpenConnection(); // Connection needs to stay open for the reader
            if (connection == null) return null;

            SqlCommand command = new SqlCommand(commandText, connection);
            command.CommandType = commandType;
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            try
            {
                // CommandBehavior.CloseConnection ensures the connection is closed when the reader is closed
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al leer datos: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close(); // Ensure connection is closed on error
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close(); // Ensure connection is closed on error
                return null;
            }
        }

        // Executes a scalar query (returns a single value)
        public static object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                if (connection == null) return null;

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        return command.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al obtener valor: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
        }
    }
}
