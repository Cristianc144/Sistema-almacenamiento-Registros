using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend;
using Backend.Models;
using Backend.Contexts;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly ConexionSQLServer _context;

        public RegistrosController(ConexionSQLServer context)
        {
            _context = context;
        }

        // GET: api/Registros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registros>>> GetRegistros()
        {
            return await _context.Registros.ToListAsync();
        }

        // GET: api/Registros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registros>> GetRegistros(int id)
        {
            var registros = await _context.Registros.FindAsync(id);

            if (registros == null)
            {
                return NotFound();
            }

            return registros;
        }

        // PUT: api/Registros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistros(int id, Registros registros)
        {
            if (id != registros.Id)
            {
                return BadRequest();
            }

            _context.Entry(registros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrosExists(id))
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

        // POST: api/Registros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Registros>> PostRegistros(Registros registros)
        {
            _context.Registros.Add(registros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistros", new { id = registros.Id }, registros);
        }

        // DELETE: api/Registros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Registros>> DeleteRegistros(int id)
        {
            var registros = await _context.Registros.FindAsync(id);
            if (registros == null)
            {
                return NotFound();
            }

            _context.Registros.Remove(registros);
            await _context.SaveChangesAsync();

            return registros;
        }

        private bool RegistrosExists(int id)
        {
            return _context.Registros.Any(e => e.Id == id);
        }
    }
}
