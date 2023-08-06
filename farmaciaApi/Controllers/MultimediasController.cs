﻿using System;
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
    public class MultimediasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MultimediasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Multimedias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Multimedia>>> GetMultimedia()
        {
          if (_context.Multimedia == null)
          {
              return NotFound();
          }
            return await _context.Multimedia.ToListAsync();
        }

        // GET: api/Multimedias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Multimedia>> GetMultimedia(int id)
        {
          if (_context.Multimedia == null)
          {
              return NotFound();
          }
            var multimedia = await _context.Multimedia.FindAsync(id);

            if (multimedia == null)
            {
                return NotFound();
            }

            return multimedia;
        }

        // PUT: api/Multimedias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultimedia(int id, Multimedia multimedia)
        {
            if (id != multimedia.Id)
            {
                return BadRequest();
            }

            _context.Entry(multimedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultimediaExists(id))
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

        // POST: api/Multimedias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Multimedia>> PostMultimedia(Multimedia multimedia)
        {
          if (_context.Multimedia == null)
          {
              return Problem("Entity set 'AppDbContext.Multimedia'  is null.");
          }
            _context.Multimedia.Add(multimedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMultimedia", new { id = multimedia.Id }, multimedia);
        }

        // DELETE: api/Multimedias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMultimedia(int id)
        {
            if (_context.Multimedia == null)
            {
                return NotFound();
            }
            var multimedia = await _context.Multimedia.FindAsync(id);
            if (multimedia == null)
            {
                return NotFound();
            }

            _context.Multimedia.Remove(multimedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MultimediaExists(int id)
        {
            return (_context.Multimedia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
