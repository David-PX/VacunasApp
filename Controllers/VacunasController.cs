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
    public class VacunasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VacunasController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacunas>>> GetVacunas()
        {
            return await _context.vacunas
            .Include(p => p.PrimeraDosis)
            .Include(p => p.SegundaDosis)
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vacunas>> GetVacuna(int id)
        {
            var Vacuna = await _context.vacunas
            .Include(p => p.PrimeraDosis)
            .Include(p => p.SegundaDosis)
            .SingleAsync(x => x.id == id);

            if (Vacuna == null)
            {
                return NotFound();
            }

            return Vacuna;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacuna(int id, Vacunas Vacuna)
        {
            if (id != Vacuna.id)
            {
                return BadRequest();
            }

            _context.Entry(Vacuna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacunasExists(id))
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
        public async Task<ActionResult<Vacunas>> PostVacunas(Vacunas Vacunas)
        {
            _context.vacunas.Add(Vacunas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacunas", new { id = Vacunas.id }, Vacunas);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacunas>> DeleteVacunas(int id)
        {
            var Vacunas = await _context.vacunas.FindAsync(id);
            if (Vacunas == null)
            {
                return NotFound();
            }

            _context.vacunas.Remove(Vacunas);
            await _context.SaveChangesAsync();

            return Vacunas;
        }

        private bool VacunasExists(int id)
        {
            return _context.vacunas.Any(e => e.id == id);
        }
    }
}