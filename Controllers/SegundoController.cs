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
    public class SegundoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SegundoController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SegundaDosis>>> GetSegundaDosis()
        {
            return await _context.segundadosis.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SegundaDosis>> GetSegundaDosis(int id)
        {
            var SegundaDosis = await _context.segundadosis.FindAsync(id);

            if (SegundaDosis == null)
            {
                return NotFound();
            }

            return SegundaDosis;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSegundaDosis(int id, SegundaDosis SegundaDosis)
        {
            if (id != SegundaDosis.id)
            {
                return BadRequest();
            }

            _context.Entry(SegundaDosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SegundaDosisExists(id))
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
        public async Task<ActionResult<SegundaDosis>> PostSegundaDosis(SegundaDosis SegundaDosis)
        {
            _context.segundadosis.Add(SegundaDosis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSegundaDosis", new { id = SegundaDosis.id }, SegundaDosis);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SegundaDosis>> DeleteSegundaDosis(int id)
        {
            var SegundaDosis = await _context.segundadosis.FindAsync(id);
            if (SegundaDosis == null)
            {
                return NotFound();
            }

            _context.segundadosis.Remove(SegundaDosis);
            await _context.SaveChangesAsync();

            return SegundaDosis;
        }

        private bool SegundaDosisExists(int id)
        {
            return _context.segundadosis.Any(e => e.id == id);
        }
    }
}