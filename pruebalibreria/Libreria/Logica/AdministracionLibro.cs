using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pruebalibreria.Libreria.Clases;
using pruebalibreria.Libreria.Datos;

namespace pruebalibreria.Libreria.Logica
{
    public class AdministracionLibro
    {
        public List<Libro> consultarTodosLosLibros()
        {
            DBLibro dblibro = new DBLibro();
            return dblibro.consultarTodosLibros();
        }

        public List<Resenas> consultaResenasLibro(Resenas resenas)
        {
            DBLibro dblibro = new DBLibro();
            return dblibro.consultarResenas(resenas);
        }

        public List<Libro> consultarLibrosConFiltro(Libro libro)
        {
            DBLibro dblibro = new DBLibro();
            return dblibro.consultarLibrosConFiltro(libro);
        }

        public int IngresarResena(Resenas resenas)
        {
            DBLibro dblibro = new DBLibro();
            return dblibro.insertarResena(resenas);
        }
    }
}
