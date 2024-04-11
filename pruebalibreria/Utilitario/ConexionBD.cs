using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace pruebalibreria.Utilitario
{
    public class ConexionBD
    {
        string connectionString = "Server=tcp:pruebacontrolbox.database.windows.net,1433;Initial " +
                "Catalog=pruebacontrolbox;Persist Security Info=False;User ID=efrain;Password=Prueba123;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public SqlConnection conectarBaseDeDatos()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public DataTable ejecutarProcedimientoAlmacenadoConsulta(List<Parametros> parametros, 
            string nombreProcedimiento)
        {
            // Crear una nueva conexión
            using (SqlConnection connection = conectarBaseDeDatos())
            {
                try
                {
                   
                    Console.WriteLine("Conexión abierta con éxito.");
                    using (SqlCommand command = new SqlCommand(nombreProcedimiento, connection))
                    {
                      command.CommandType = CommandType.StoredProcedure;
                        foreach (var parametro in parametros)
                        {
                            command.Parameters.AddWithValue(parametro.nombre, parametro.valor);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al intentar conectarse a la base de datos: {ex.Message}");
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
        public int ejecutarProcedimientoAlmacenadoAfectacionColumna(List<Parametros> parametros,
            string nombreProcedimiento)
        {
            // Crear una nueva conexión
            using (SqlConnection connection = conectarBaseDeDatos())
            {
                try
                {

                    Console.WriteLine("Conexión abierta con éxito.");
                    using (SqlCommand command = new SqlCommand(nombreProcedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (var parametro in parametros)
                        {
                            command.Parameters.AddWithValue(parametro.nombre, parametro.valor);
                        }

                        return command.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al intentar conectarse a la base de datos: {ex.Message}");
                    return 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }



    }
}
