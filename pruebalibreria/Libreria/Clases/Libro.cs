using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebalibreria.Libreria.Clases
{
    public class Libro
    {
        public int id{ get; set; } 
        public string nombre { get; set; }
        public string autor { get; set; }
        public string categoria { get; set; }
        public string resumen { get; set; }                
        public List<Resenas> resenas { get; set; }
    }
}
