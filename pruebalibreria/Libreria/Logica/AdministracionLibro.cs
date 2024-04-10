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
        public List<Libro> consultarLibros()
        {
            DBLibro dblibro = new DBLibro();
            dblibro.consultarLibros();
            return new List<Libro>() { new Libro() { autor = "pedro", id = 1, categoria = "suspenso", nombre = "El final", resumen = "es bueno" } };
        }

        public Libro consultaResenasLibro()
        {
            return new Libro() { autor = "pedro", id = 1, categoria = "suspenso", nombre = "El final", resumen = "es bueno" };
        }

        public int IngresarResena(Libro libro)
        {
            return 1;
        }
    }
}
