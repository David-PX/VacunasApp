using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacunasApp.Context;
using VacunasApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacunasApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public PersonasController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/<PersonasController>
        [HttpGet]
        public ActionResult<IEnumerable<Personas>> Get()
        {
            return  _dbContext.Set<Personas>().ToList();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{nombre}/{apellido?}")]
        public async Task<ActionResult<Personas>> Get(string nombre, string apellido)
        {
            if(nombre != null && apellido == null)
            {
                return _dbContext.personas.FirstOrDefault(x => x.nombre == nombre);
            }
            else if(apellido != null && nombre == null)
            {
                return  _dbContext.personas.FirstOrDefault(x => x.apellido == apellido);
            }
            else
            {
                return NotFound();
            }

            
        }

        // POST api/<PersonasController>
        [HttpPost]
        public async Task<ActionResult<Personas>> Post([FromBody] Personas personas)
        {
            await _dbContext.AddAsync(personas);
            await _dbContext.SaveChangesAsync();
            return Ok(personas);



        }

        // PUT api/<PersonasController>/5
        //[HttpPut("{cedula}")]
        //public void Put(string cedula, [FromBody] Personas persona)
        //{
        //   if(id != persona.cedula)
        //}

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
