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
    public class MedicamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicamentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Medicamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicamento>>> GetMedicamento()
        {
          if (_context.Medicamento == null)
          {
              return NotFound();
          }
            return await _context.Medicamento.ToListAsync();
        }

        // GET: api/Medicamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicamento>> GetMedicamento(int id)
        {
          if (_context.Medicamento == null)
          {
              return NotFound();
          }
            var medicamento = await _context.Medicamento.FindAsync(id);

            if (medicamento == null)
            {
                return NotFound();
            }

            return medicamento;
        }

        // PUT: api/Medicamento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamento(int id, Medicamento medicamento)
        {
            if (id != medicamento.IdMedicamento)
            {
                return BadRequest();
            }

            _context.Entry(medicamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoExists(id))
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
        // PUT: api/Medicamentos/ActualizarCantidad
        [HttpPut("ActualizarCantidad")]
        public IActionResult ActualizarCantidad(string nombreProducto, int cantidad)
        {
            try
            {
                var medicamento = _context.Medicamento.FirstOrDefault(m => m.Nombre == nombreProducto);

                if (medicamento == null)
                {
                    return NotFound($"No se encontró ningún medicamento con el nombre '{nombreProducto}'.");
                }

                // Resta la cantidad especificada de la cantidad actual del medicamento
                if (cantidad > 0 && cantidad <= medicamento.Cantidad)
                {
                    medicamento.Cantidad -= cantidad;
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return BadRequest("La cantidad especificada es inválida.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        // POST: api/Medicamento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicamento>> PostMedicamento(Medicamento medicamento)
        {
          if (_context.Medicamento == null)
          {
              return Problem("Entity set 'AppDbContext.Medicamento'  is null.");
          }
            _context.Medicamento.Add(medicamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicamento", new { id = medicamento.IdMedicamento }, medicamento);
        }

        // DELETE: api/Medicamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicamento(int id)
        {
            if (_context.Medicamento == null)
            {
                return NotFound();
            }
            var medicamento = await _context.Medicamento.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            _context.Medicamento.Remove(medicamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicamentoExists(int id)
        {
            return (_context.Medicamento?.Any(e => e.IdMedicamento == id)).GetValueOrDefault();
        }
    }
}
