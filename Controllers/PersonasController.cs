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
            return _dbContext.Set<Personas>().ToList();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{nombre}/{apellido?}")]
        // Filtro de vacunados por nombre y apellido
        public async Task<ActionResult<Personas>> Get(string nombre, string apellido)
        {
            if (nombre != null && apellido == null)
            {
                return await _dbContext.personas.FindAsync(nombre);
            }
            else if (apellido != null && nombre == null)
            {
                return await _dbContext.personas.FindAsync(apellido);
            }
            else
            {
                return NotFound();
            }


        }

        [HttpGet("{provincia_id}")]
        // Listado de vacunados por provincia

        public ActionResult<IEnumerable<Personas>> Get(int provincia_id)
        {
            return _dbContext.personas.Where(x => x.provincia_id == provincia_id).ToList();

        }

        [HttpGet("{vacuna_id}")]
        // Listado de personas por tipo de vacuna
        public ActionResult<IEnumerable<Personas>> GetVacuna(int vacuna_id)
        {
            return _dbContext.personas.Where(x => x.vacuna_id == vacuna_id).ToList();

        }

        [HttpGet("{signo_id}")]
        // Listado de vacunados por signo zodiacal
        public ActionResult<IEnumerable<Personas>> GetSigno(int signo_id)
        {
            return _dbContext.personas.Where(x => x.signosodiacal_id == signo_id).ToList();

        }



        // POST api/<PersonasController>
        // Guardar Persona con vacuna y demas datos
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

        // Anular registro de vacunacion.  Vamos a digitar una cedula de un vacunado... 
        // y vamos a poder eliminar el registro de que se vacuno. 
        // Esto es por si lo agregaron por error.
        [HttpDelete("{persona_id}")]
        public async Task<ActionResult> Delete(int persona_id)
        {
            var persona = await _dbContext.personas.FindAsync(persona_id);
            if(persona != null)
            {
                 _dbContext.personas.Remove(persona);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
