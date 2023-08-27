using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using farmaciaApi.Context;
using farmaciaApi.Models;
using System.Net.Mail;
using System.Net;

namespace farmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificacionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Notificaiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificaiones>>> GetNotificaiones()
        {
          if (_context.Notificaiones == null)
          {
              return NotFound();
          }
            return await _context.Notificaiones.ToListAsync();
        }

        // GET: api/Notificaiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificaiones>> GetNotificaiones(int id)
        {
          if (_context.Notificaiones == null)
          {
              return NotFound();
          }
            var notificaiones = await _context.Notificaiones.FindAsync(id);

            if (notificaiones == null)
            {
                return NotFound();
            }

            return notificaiones;
        }

        // PUT: api/Notificaiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificaiones(int id, Notificaiones notificaiones)
        {
            if (id != notificaiones.IdNotificaciones)
            {
                return BadRequest();
            }

            _context.Entry(notificaiones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificaionesExists(id))
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

        // POST: api/Notificaiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notificaiones>> PostNotificaiones(Notificaiones notificaiones)
        {
            if (_context.Notificaiones == null)
            {
                return Problem("Entity set 'AppDbContext.Notificaiones' is null.");
            }

            try
            {
                // Agrega la notificación a la base de datos
                _context.Notificaiones.Add(notificaiones);
                await _context.SaveChangesAsync();

                // Envía un correo electrónico
                EnviarCorreoElectronico(notificaiones);

                return CreatedAtAction("GetNotificaiones", new { id = notificaiones.IdNotificaciones }, notificaiones);
            }
            catch (Exception ex)
            {
                return Problem($"Error al crear la notificación: {ex.Message}");
            }
        }
        // Método para enviar un correo electrónico
        private void EnviarCorreoElectronico(Notificaiones notificacion)
        {
            try
            {
                // Configura el cliente SMTP (ajusta estos valores)
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("yrielcabreravaldez@gmail.com", "qyqffgjtfhaaufpj"),
                    EnableSsl = true,
                };

                // Configura el correo electrónico
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("yrielcabreravaldez@gmail.com"),
                    Subject = "Nueva notificación creada",
                    Body = notificacion.Descripcion, // Establece la descripción como el contenido del mensaje
                };

                // Destinatario (usando la dirección de correo electrónico desde la notificación)
                mailMessage.To.Add(notificacion.Correo);

                // Envía el correo electrónico
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }

        // DELETE: api/Notificaiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificaiones(int id)
        {
            if (_context.Notificaiones == null)
            {
                return NotFound();
            }
            var notificaiones = await _context.Notificaiones.FindAsync(id);
            if (notificaiones == null)
            {
                return NotFound();
            }

            _context.Notificaiones.Remove(notificaiones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificaionesExists(int id)
        {
            return (_context.Notificaiones?.Any(e => e.IdNotificaciones == id)).GetValueOrDefault();
        }
    }
}
