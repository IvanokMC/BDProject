
using System;
using System.Data.SqlClient;
using ProjectBD.Properties;

namespace ProjectBD
{
    public class ConexionBD
    {
        private static SqlConnection conexion;

        public static SqlConnection ObtenerConexion()
        {
            if (conexion == null)
            {
                try
                {
                    string connectionString = Settings.Default.MelodiaUrbanaConnectionString;
                    conexion = new SqlConnection(connectionString);
                    conexion.Open();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                }
            }
            return conexion;
        }

        public static void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
