using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace pruebalibreria.Utilitario
{
    public class ConexionBD
    {
        public void conectarBaseDeDatos()
        {          
            string connectionString = "Server=tcp:pruebacontrolbox.database.windows.net,1433;Initial " +
                "Catalog=pruebacontrolbox;Persist Security Info=False;User ID=efrain;Password=Prueba123;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // Crear una nueva conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta con éxito.");
                   
                    string sqlQuery = "SELECT * FROM usuario";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {                       
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al intentar conectarse a la base de datos: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
