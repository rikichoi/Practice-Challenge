using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblOwnersController : ControllerBase
    {
        private readonly practiceContext _context;

        public TblOwnersController(practiceContext context)
        {
            _context = context;
        }

        // GET: api/TblOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblOwner>>> GetTblOwners()
        {
          if (_context.TblOwners == null)
          {
              return NotFound();
          }
            return await _context.TblOwners.ToListAsync();
        }

        // GET: api/TblOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblOwner>> GetTblOwner(int id)
        {
          if (_context.TblOwners == null)
          {
              return NotFound();
          }
            var tblOwner = await _context.TblOwners.FindAsync(id);

            if (tblOwner == null)
            {
                return NotFound();
            }

            return tblOwner;
        }

        // PUT: api/TblOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblOwner(int id, TblOwner tblOwner)
        {
            if (id != tblOwner.Ownerid)
            {
                return BadRequest();
            }

            _context.Entry(tblOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblOwnerExists(id))
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

        // POST: api/TblOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblOwner>> PostTblOwner(TblOwner tblOwner)
        {
          if (_context.TblOwners == null)
          {
              return Problem("Entity set 'practiceContext.TblOwners'  is null.");
          }
            _context.TblOwners.Add(tblOwner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblOwnerExists(tblOwner.Ownerid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblOwner", new { id = tblOwner.Ownerid }, tblOwner);
        }

        // DELETE: api/TblOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblOwner(int id)
        {
            if (_context.TblOwners == null)
            {
                return NotFound();
            }
            var tblOwner = await _context.TblOwners.FindAsync(id);
            if (tblOwner == null)
            {
                return NotFound();
            }

            _context.TblOwners.Remove(tblOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblOwnerExists(int id)
        {
            return (_context.TblOwners?.Any(e => e.Ownerid == id)).GetValueOrDefault();
        }
    }
}
