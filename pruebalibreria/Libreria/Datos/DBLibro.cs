using pruebalibreria.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebalibreria.Libreria.Datos
{
    public class DBLibro
    {

        public void consultarLibros()
        {
            ConexionBD conexion = new ConexionBD();
            conexion.conectarBaseDeDatos();
        }
    }
}
