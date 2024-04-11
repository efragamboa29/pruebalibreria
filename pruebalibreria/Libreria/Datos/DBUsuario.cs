using pruebalibreria.Libreria.Clases;
using pruebalibreria.Utilitario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace pruebalibreria.Libreria.Datos
{
    public class DBUsuario
    {
        public Usuario consultarUsuario(Usuario usuario)
        {
            ConexionBD conexion = new ConexionBD();
            Usuario usuarioSalida = new Usuario();
            List<Parametros> listaParametros = new List<Parametros>();
            listaParametros.Add(new Parametros() { nombre = "@nombre", valor = usuario.nombre });
            listaParametros.Add(new Parametros() { nombre = "@contrasena", valor = usuario.contrasena });


            DataTable resultado = conexion.ejecutarProcedimientoAlmacenadoConsulta(listaParametros, "consultarUsuario");


            foreach (DataRow item in resultado.Rows)
            {
                usuarioSalida.nombre = item["nombre"].ToString();
                usuarioSalida.contrasena = item["contrasena"].ToString();
            }

            return usuarioSalida;
        }

        public int insertarUsuario(Usuario usuario)
        {
            ConexionBD conexion = new ConexionBD();
            List<Parametros> listaParametros = new List<Parametros>();
            listaParametros.Add(new Parametros() { nombre = "@nombre", valor = usuario.nombre });
            listaParametros.Add(new Parametros() { nombre = "@contrasena", valor = usuario.contrasena });

            return conexion.ejecutarProcedimientoAlmacenadoAfectacionColumna(listaParametros, "insertarUsuario");
        }

        public bool exiteUsuario(Usuario usuario)
        {
            ConexionBD conexion = new ConexionBD();
            List<Parametros> listaParametros = new List<Parametros>();
            listaParametros.Add(new Parametros() { nombre = "@nombre", valor = usuario.nombre });
            DataTable resultado = conexion.ejecutarProcedimientoAlmacenadoConsulta(listaParametros, "existeUsuario");
            return resultado.Rows.Count > 0;
        }
    }
}
