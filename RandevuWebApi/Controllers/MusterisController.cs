using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuWebApi.Data;
using Randevuobject;

namespace RandevuWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusterisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MusterisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Musteris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musteri>>> GetMusteriler()
        {
          if (_context.Musteriler == null)
          {
              return NotFound();
          }
            return await _context.Musteriler.ToListAsync();
        }

        // GET: api/Musteris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musteri>> GetMusteri(int id)
        {
          if (_context.Musteriler == null)
          {
              return NotFound();
          }
            var musteri = await _context.Musteriler.FindAsync(id);

            if (musteri == null)
            {
                return NotFound();
            }

            return musteri;
        }

        // PUT: api/Musteris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusteri(int id, Musteri musteri)
        {
            if (id != musteri.Id)
            {
                return BadRequest();
            }

            _context.Entry(musteri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusteriExists(id))
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

        // POST: api/Musteris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Musteri>> PostMusteri(Musteri musteri)
        {
          if (_context.Musteriler == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Musteriler'  is null.");
          }
            _context.Musteriler.Add(musteri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusteri", new { id = musteri.Id }, musteri);
        }

        // DELETE: api/Musteris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusteri(int id)
        {
            if (_context.Musteriler == null)
            {
                return NotFound();
            }
            var musteri = await _context.Musteriler.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }

            _context.Musteriler.Remove(musteri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusteriExists(int id)
        {
            return (_context.Musteriler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
