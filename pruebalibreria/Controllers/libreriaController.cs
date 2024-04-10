using Microsoft.AspNetCore.Mvc;
using pruebalibreria.Libreria.Clases;
using pruebalibreria.Libreria.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebalibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class libreriaController : ControllerBase
    {
        // GET: api/libreriaController
        [HttpGet("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "libro1", "librodos" };
        }

        // GET api/<libreriaController>/5
        [HttpGet("{Libro}")]
        public string Get(Libro libro)
        {
            return "value";
        }

        // POST api/<libreriaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<libreriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<libreriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("buscarLibros")]
        public ActionResult<string> buscarLibros()
        {
            return "Prueba Exitosa";
        }

        [HttpGet("buscarLibros/{numero}")]
        public ActionResult<List<Libro>> buscarLibros(int numero)
        {
            AdministracionLibro administracion = new AdministracionLibro();
            return administracion.consultarLibros();
        }
    }
}
