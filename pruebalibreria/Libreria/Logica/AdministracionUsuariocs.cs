using pruebalibreria.Libreria.Clases;
using pruebalibreria.Libreria.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebalibreria.Libreria.Logica
{
    public class AdministracionUsuariocs
    {
        public int CrearUsuario(Usuario usuario )
        {

            DBUsuario dbUsuario = new DBUsuario();
            if (!dbUsuario.exiteUsuario(usuario))
            {
                return dbUsuario.insertarUsuario(usuario);
            }
            return 2;
        }

        public bool exiteUsuario(Usuario usuario)
        {
            DBUsuario dbUsuario = new DBUsuario();
            return dbUsuario.exiteUsuario(usuario);
        }


        public int consultarUsuario(Usuario usuario)
        {
            DBUsuario dbUsuario = new DBUsuario();
            var resultado = dbUsuario.consultarUsuario(usuario);

            return resultado.nombre == usuario.nombre ? 1 : 0;
        }


    }
}
