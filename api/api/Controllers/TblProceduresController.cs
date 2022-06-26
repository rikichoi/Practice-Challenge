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
    public class TblProceduresController : ControllerBase
    {
        private readonly practiceContext _context;

        public TblProceduresController(practiceContext context)
        {
            _context = context;
        }

        // GET: api/TblProcedures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProcedure>>> GetTblProcedures()
        {
          if (_context.TblProcedures == null)
          {
              return NotFound();
          }
            return await _context.TblProcedures.ToListAsync();
        }

        // GET: api/TblProcedures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProcedure>> GetTblProcedure(int id)
        {
          if (_context.TblProcedures == null)
          {
              return NotFound();
          }
            var tblProcedure = await _context.TblProcedures.FindAsync(id);

            if (tblProcedure == null)
            {
                return NotFound();
            }

            return tblProcedure;
        }

        // PUT: api/TblProcedures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProcedure(int id, TblProcedure tblProcedure)
        {
            if (id != tblProcedure.Procedureid)
            {
                return BadRequest();
            }

            _context.Entry(tblProcedure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProcedureExists(id))
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

        // POST: api/TblProcedures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProcedure>> PostTblProcedure(TblProcedure tblProcedure)
        {
          if (_context.TblProcedures == null)
          {
              return Problem("Entity set 'practiceContext.TblProcedures'  is null.");
          }
            _context.TblProcedures.Add(tblProcedure);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblProcedureExists(tblProcedure.Procedureid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblProcedure", new { id = tblProcedure.Procedureid }, tblProcedure);
        }

        // DELETE: api/TblProcedures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProcedure(int id)
        {
            if (_context.TblProcedures == null)
            {
                return NotFound();
            }
            var tblProcedure = await _context.TblProcedures.FindAsync(id);
            if (tblProcedure == null)
            {
                return NotFound();
            }

            _context.TblProcedures.Remove(tblProcedure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProcedureExists(int id)
        {
            return (_context.TblProcedures?.Any(e => e.Procedureid == id)).GetValueOrDefault();
        }
    }
}
