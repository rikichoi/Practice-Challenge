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
    public class TblPetsController : ControllerBase
    {
        private readonly practiceContext _context;

        public TblPetsController(practiceContext context)
        {
            _context = context;
        }

        // GET: api/TblPets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPet>>> GetTblPets()
        {
          if (_context.TblPets == null)
          {
              return NotFound();
          }
            return await _context.TblPets.ToListAsync();
        }

        // GET: api/TblPets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPet>> GetTblPet(string id)
        {
          if (_context.TblPets == null)
          {
              return NotFound();
          }
            var tblPet = await _context.TblPets.FindAsync(id);

            if (tblPet == null)
            {
                return NotFound();
            }

            return tblPet;
        }

        // PUT: api/TblPets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPet(string id, TblPet tblPet)
        {
            if (id != tblPet.Petname)
            {
                return BadRequest();
            }

            _context.Entry(tblPet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPetExists(id))
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

        // POST: api/TblPets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPet>> PostTblPet(TblPet tblPet)
        {

            var temp = _context.TblPets
                .Where(x => x.Ownerid == tblPet.Ownerid
                && x.Petname == tblPet.Petname && x.Type == tblPet.Type)
                .FirstOrDefault();

            if (temp == null)
            {
                _context.TblPets.Add(tblPet);
                await _context.SaveChangesAsync();
            }
            else
                tblPet = temp;

            return Ok(tblPet);
        }

        // DELETE: api/TblPets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPet(string id)
        {
            if (_context.TblPets == null)
            {
                return NotFound();
            }
            var tblPet = await _context.TblPets.FindAsync(id);
            if (tblPet == null)
            {
                return NotFound();
            }

            _context.TblPets.Remove(tblPet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPetExists(string id)
        {
            return (_context.TblPets?.Any(e => e.Petname == id)).GetValueOrDefault();
        }
    }
}
