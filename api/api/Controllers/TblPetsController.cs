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
        [HttpGet("Pets/{userID}")]
    public async Task<ActionResult<List<TblPet?>>> GetUserPets()
        {
        
        try
        {
            var inputOwnerID = Convert.ToInt32(RouteData.Values["userID"]);

            var owneridArray = new List<int> { inputOwnerID };

            var ownerPetsObject = await _context.TblPets
            .Where(t => owneridArray.Contains(t.Ownerid)).ToListAsync();


            return Ok (new {ownerPetsObject});
        }
        catch (Exception ex)
        {

            return StatusCode(500, ex.ToString());
        }

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
        public async Task<ActionResult<List<TblPet>>> AddPet(TblPet pet)
        {
            _context.TblPets.Add(pet);
            await _context.SaveChangesAsync();

            return Ok(await _context.TblPets.ToListAsync());
        }

        // DELETE: api/TblPets/5
        [HttpDelete("{petname}/{ownerid}")]
        public async Task<ActionResult<List<TblPet>>> DeletePet(string petname, int ownerid)
        {
            var inputPet = Convert.ToString(RouteData.Values["petname"]);
            var inputOwner = Convert.ToInt32(RouteData.Values["ownerid"]);

            var dbPet = await _context.TblPets.FindAsync(inputPet, inputOwner);
            if (dbPet == null)
                return BadRequest("Pet not found.");

            _context.TblPets.Remove(dbPet);
            await _context.SaveChangesAsync();

            return Ok(await _context.TblPets.ToListAsync());
        }

        private bool TblPetExists(string id)
        {
            return (_context.TblPets?.Any(e => e.Petname == id)).GetValueOrDefault();
        }
    }
}
