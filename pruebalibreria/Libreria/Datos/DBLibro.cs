using pruebalibreria.Libreria.Clases;
using pruebalibreria.Utilitario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace pruebalibreria.Libreria.Datos
{
    public class DBLibro
    {

        public List<Libro> consultarTodosLibros()
        {
            ConexionBD conexion = new ConexionBD();
            List<Libro> resultadoLibros = new List<Libro>();
            List<Parametros> listaParametros = new List<Parametros>();

            DataTable resultado = conexion.ejecutarProcedimientoAlmacenadoConsulta(listaParametros, "consultarTodoLibros");

            foreach (DataRow item in resultado.Rows)
            {
                resultadoLibros.Add(new Libro()
                {
                    id = (int)item["id"],
                    nombre = item["nombre"].ToString(),
                    autor = item["autor"].ToString(),
                    categoria = item["categoria"].ToString(),
                    resumen = item["resumen"].ToString(),
                });
            }

            return resultadoLibros;
        }

        public List<Libro> consultarLibrosConFiltro(Libro libro)
        {
            ConexionBD conexion = new ConexionBD();
            List<Libro> resultadoLibros = new List<Libro>();
            List<Parametros> listaParametros = new List<Parametros>();
            listaParametros.Add(new Parametros() { nombre = "@nombre", valor = libro.nombre != null ? libro.nombre.Trim():string.Empty });
            listaParametros.Add(new Parametros() { nombre = "@autor", valor = libro.autor != null ? libro.autor.Trim() : string.Empty });
            listaParametros.Add(new Parametros() { nombre = "@categoria", valor = libro.categoria != null ? libro.categoria.Trim() : string.Empty });
            listaParametros.Add(new Parametros() { nombre = "@resumen", valor = libro.resumen != null ? libro.resumen.Trim() : string.Empty });
            listaParametros.Add(new Parametros() { nombre = "@id", valor = libro.id.ToString() });

            DataTable resultado = conexion.ejecutarProcedimientoAlmacenadoConsulta(listaParametros, "consultarLibrosFiltro");


            foreach (DataRow item in resultado.Rows)
            {
                resultadoLibros .Add(new Libro()
                {
                    id = (int)item["id"],
                    nombre = item["nombre"].ToString(),
                    autor = item["autor"].ToString(),
                    categoria = item["categoria"].ToString(),
                    resumen = item["resumen"].ToString(),
                });
            }

            return resultadoLibros;
        }

        public List<Resenas> consultarResenas(Resenas resenas)
        {
            ConexionBD conexion = new ConexionBD();
            List<Resenas> resultadoEesenas = new List<Resenas>();
            List<Parametros> listaParametros = new List<Parametros>();
            listaParametros.Add(new Parametros() { nombre = "@idLibro", valor = resenas.idLibro.ToString() });

            DataTable resultado = conexion.ejecutarProcedimientoAlmacenadoConsulta(listaParametros, "consultarResenas");

            foreach (DataRow item in resultado.Rows)
            {
                resultadoEesenas.Add(new Resenas()
                {
                    id = (int)item["id"],
                    usuario = item["usuario"].ToString(),
                    comentario = item["comentario"].ToString(),
                    calificacion = (int)item["calificacion"],
                    fecha = (DateTime)item["fecha"],
                });
            }

            return resultadoEesenas;
        }

        public int insertarResena(Resenas resena)
        {
            ConexionBD conexion = new ConexionBD();
            List<Parametros> listaParametros = new List<Parametros>();
            listaParametros.Add(new Parametros() { nombre = "@idLibro", valor = resena.idLibro.ToString() });
            listaParametros.Add(new Parametros() { nombre = "@usuario", valor = resena.usuario });
            listaParametros.Add(new Parametros() { nombre = "@comentario", valor = resena.comentario });
            listaParametros.Add(new Parametros() { nombre = "@calificacion", valor = resena.calificacion.ToString() });

            return conexion.ejecutarProcedimientoAlmacenadoAfectacionColumna(listaParametros, "insertarResena");

        }


    }
}
