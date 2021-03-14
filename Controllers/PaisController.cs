using System;
using System.Linq;
using VacunasApp.Models;
using VacunasApp.Context;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VacunasApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaisController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            return await _context.pais.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var Pais = await _context.pais.FindAsync(id);

            if (Pais == null)
            {
                return NotFound();
            }

            return Pais;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, Pais Pais)
        {
            if (id != Pais.id)
            {
                return BadRequest();
            }

            _context.Entry(Pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais Pais)
        {
            _context.pais.Add(Pais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPais", new { id = Pais.id }, Pais);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pais>> DeletePais(int id)
        {
            var Pais = await _context.pais.FindAsync(id);
            if (Pais == null)
            {
                return NotFound();
            }

            _context.pais.Remove(Pais);
            await _context.SaveChangesAsync();

            return Pais;
        }

        private bool PaisExists(int id)
        {
            return _context.pais.Any(e => e.id == id);
        }
    }
}