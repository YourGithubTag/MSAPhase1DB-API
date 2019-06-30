using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomTracker.Model;

namespace RoomTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardrobesController : ControllerBase
    {
        private readonly roomTrackingContext _context;

        public WardrobesController(roomTrackingContext context)
        {
            _context = context;
        }

        // GET: api/Wardrobes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wardrobe>>> GetWardrobe()
        {
            return await _context.Wardrobe.ToListAsync();
        }

        // GET: api/Wardrobes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wardrobe>> GetWardrobe(int id)
        {
            var wardrobe = await _context.Wardrobe.FindAsync(id);

            if (wardrobe == null)
            {
                return NotFound();
            }

            return wardrobe;
        }

        // PUT: api/Wardrobes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWardrobe(int id, Wardrobe wardrobe)
        {
            if (id != wardrobe.Id)
            {
                return BadRequest();
            }

            _context.Entry(wardrobe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardrobeExists(id))
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

        // POST: api/Wardrobes
        [HttpPost]
        public async Task<ActionResult<Wardrobe>> PostWardrobe(Wardrobe wardrobe)
        {
            _context.Wardrobe.Add(wardrobe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWardrobe", new { id = wardrobe.Id }, wardrobe);
        }

        // DELETE: api/Wardrobes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wardrobe>> DeleteWardrobe(int id)
        {
            var wardrobe = await _context.Wardrobe.FindAsync(id);
            if (wardrobe == null)
            {
                return NotFound();
            }

            _context.Wardrobe.Remove(wardrobe);
            await _context.SaveChangesAsync();

            return wardrobe;
        }

        private bool WardrobeExists(int id)
        {
            return _context.Wardrobe.Any(e => e.Id == id);
        }
    }
}
