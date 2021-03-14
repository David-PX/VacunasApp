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
    public class ProvinciasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProvinciasController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provincias>>> GetProvincias()
        {
            return await _context.provincias
            .Include(p => p.Pais)
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Provincias>> GetProvincia(int id)
        {
            var Provincia = await _context.provincias
            .Include(p => p.Pais)
            .SingleAsync(x => x.id == id);

            if (Provincia == null)
            {
                return NotFound();
            }

            return Provincia;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincia(int id, Provincias Provincias)
        {
            if (id != Provincias.id)
            {
                return BadRequest();
            }

            _context.Entry(Provincias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciasExists(id))
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
        public async Task<ActionResult<Provincias>> PostProvincias(Provincias Provincias)
        {
            _context.provincias.Add(Provincias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvincias", new { id = Provincias.id }, Provincias);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Provincias>> DeleteProvincias(int id)
        {
            var Provincias = await _context.provincias.FindAsync(id);
            if (Provincias == null)
            {
                return NotFound();
            }

            _context.provincias.Remove(Provincias);
            await _context.SaveChangesAsync();

            return Provincias;
        }

        private bool ProvinciasExists(int id)
        {
            return _context.provincias.Any(e => e.id == id);
        }
    }
}