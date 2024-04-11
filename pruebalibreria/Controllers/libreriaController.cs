using Microsoft.AspNetCore.Cors;
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
    [DisableCors]
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
        public ActionResult<List<Libro>> buscarLibros()
        {
            AdministracionLibro administracion = new AdministracionLibro();
            return administracion.consultarTodosLosLibros();
        }

        [HttpPost("buscarLibrosFiltros")]
        public ActionResult<List<Libro>> buscarLibrosFiltros([FromBody] Libro libro)
        {
            AdministracionLibro administracion = new AdministracionLibro();
            return administracion.consultarLibrosConFiltro(libro);
        }

        [HttpPost("consultarUsuario")]
        public ActionResult<int> consultarUsuario([FromBody]  Usuario usuario)
        {
            AdministracionUsuariocs administracion = new AdministracionUsuariocs();
            return administracion.consultarUsuario(usuario);
        }

        [HttpPost("insertarUsuario")]
        public ActionResult<int> insertarUsuario([FromBody] Usuario usuario)
        {
            AdministracionUsuariocs administracion = new AdministracionUsuariocs();
            return administracion.CrearUsuario(usuario);
        }

        [HttpPost("insertarResena")]
        public ActionResult<int> insertarResena([FromBody] Resenas resenas)
        {
            AdministracionLibro administracion = new AdministracionLibro();
            return administracion.IngresarResena(resenas);
        }

        [HttpPost("ConsultarResena")]
        public ActionResult<List<Resenas>> ConsultarResena([FromBody] Resenas resenas)
        {
            AdministracionLibro administracion = new AdministracionLibro();
            return administracion.consultaResenasLibro(resenas);
        }

        [HttpPost("ExisteUsuario")]
        public ActionResult<bool> ConsultarResena([FromBody] Usuario usuario)
        {
            AdministracionUsuariocs administracion = new AdministracionUsuariocs();
            return administracion.exiteUsuario(usuario);
        }
    }
}
