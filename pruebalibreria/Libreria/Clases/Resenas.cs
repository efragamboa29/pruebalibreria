using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebalibreria.Libreria.Clases
{
    public class Resenas
    {
        public int id { get; set; }
        public int idLibro { get; set; }
        public string comentario { get; set; }
        public int calificacion { get; set; }
        public string usuario { get; set; }
        public DateTime fecha { get; set; }
    }
}
