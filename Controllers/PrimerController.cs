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
    public class PrimerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrimerController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrimeraDosis>>> GetPrimeraDosis()
        {
            return await _context.primeradosis.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrimeraDosis>> GetPrimeraDosis(int id)
        {
            var PrimeraDosis = await _context.primeradosis.FindAsync(id);

            if (PrimeraDosis == null)
            {
                return NotFound();
            }

            return PrimeraDosis;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrimeraDosis(int id, PrimeraDosis PrimeraDosis)
        {
            if (id != PrimeraDosis.id)
            {
                return BadRequest();
            }

            _context.Entry(PrimeraDosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimeraDosisExists(id))
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
        public async Task<ActionResult<PrimeraDosis>> PostPrimeraDosis(PrimeraDosis PrimeraDosis)
        {
            _context.primeradosis.Add(PrimeraDosis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrimeraDosis", new { id = PrimeraDosis.id }, PrimeraDosis);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PrimeraDosis>> DeletePrimeraDosis(int id)
        {
            var PrimeraDosis = await _context.primeradosis.FindAsync(id);
            if (PrimeraDosis == null)
            {
                return NotFound();
            }

            _context.primeradosis.Remove(PrimeraDosis);
            await _context.SaveChangesAsync();

            return PrimeraDosis;
        }

        private bool PrimeraDosisExists(int id)
        {
            return _context.primeradosis.Any(e => e.id == id);
        }
    }
}