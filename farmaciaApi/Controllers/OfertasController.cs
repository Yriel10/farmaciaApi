using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using farmaciaApi.Context;
using farmaciaApi.Models;

namespace farmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OfertasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ofertas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ofertas>>> GetOfertas()
        {
          if (_context.Ofertas == null)
          {
              return NotFound();
          }
            return await _context.Ofertas.ToListAsync();
        }

        // GET: api/Ofertas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ofertas>> GetOfertas(int id)
        {
          if (_context.Ofertas == null)
          {
              return NotFound();
          }
            var ofertas = await _context.Ofertas.FindAsync(id);

            if (ofertas == null)
            {
                return NotFound();
            }

            return ofertas;
        }

        // PUT: api/Ofertas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfertas(int id, Ofertas ofertas)
        {
            if (id != ofertas.Id)
            {
                return BadRequest();
            }

            _context.Entry(ofertas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertasExists(id))
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

        // POST: api/Ofertas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ofertas>> PostOfertas(Ofertas ofertas)
        {
          if (_context.Ofertas == null)
          {
              return Problem("Entity set 'AppDbContext.Ofertas'  is null.");
          }
            _context.Ofertas.Add(ofertas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfertas", new { id = ofertas.Id }, ofertas);
        }

        // DELETE: api/Ofertas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfertas(int id)
        {
            if (_context.Ofertas == null)
            {
                return NotFound();
            }
            var ofertas = await _context.Ofertas.FindAsync(id);
            if (ofertas == null)
            {
                return NotFound();
            }

            _context.Ofertas.Remove(ofertas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertasExists(int id)
        {
            return (_context.Ofertas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
