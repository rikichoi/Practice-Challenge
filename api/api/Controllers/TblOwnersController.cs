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

            var temp = _context.TblOwners
                .Where(x => x.Surname == tblOwner.Surname
                && x.Firstname == tblOwner.Firstname && x.Phone == tblOwner.Phone && x.Username == tblOwner.Username
                && x.Password == tblOwner.Password && x.Admin == tblOwner.Admin)
                .FirstOrDefault();

            if (temp == null)
            {
                _context.TblOwners.Add(tblOwner);
                await _context.SaveChangesAsync();
            }
            else
                tblOwner = temp;

            return Ok(tblOwner);
        }

        // [HttpPost]
        // public async Task<ActionResult<TblOwner>> Login(TblOwner tblOwner)
        // {
        //     var temp = _context.TblOwners
        //         .Where(x => x.Username == tblOwner.Username
        //         && x.Password == tblOwner.Password)
        //         .FirstOrDefault();
        //     if (TblOwner.Username != tblOwner.Username)
        //     {
        //         return BadRequest("User not found.");
        //     }
        //     return Ok("User Logged In");
        // }

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

    [HttpGet("get-user")]
    public async Task<ActionResult<List<UserView?>>> ViewUsers()
    {
        
        try
        {
            var sub = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            
            var users = await _context.view_User.ToListAsync();

            return Ok(users);

        }
        catch (Exception ex)
        {

            return StatusCode(500, ex.ToString());
        }

    }

    [HttpGet("Login/{username}/{password}")]
    public async Task<ActionResult<List<UserValidation?>>> ValidateUser()
    {
        
        try
        {
            var inputUsername = Convert.ToString(RouteData.Values["username"]);
            var inputPassword = Convert.ToString(RouteData.Values["password"]);

            var usernameArray = new List<string> { inputUsername };

            var userValidationObject = await _context.view_User
            .Where(t => usernameArray.Contains(t.Username)).ToListAsync();

            var userValid = false;
            var adminStatus = false;

            if(userValidationObject[0].Username == (inputUsername) && userValidationObject[0].Password == (inputPassword) && userValidationObject[0].Admin == false)
            {
                userValid = true;
                adminStatus = false;
            return Ok (new {userValid, adminStatus, userValidationObject[0].Ownerid});
            }
            else if(userValidationObject[0].Username == (inputUsername) && userValidationObject[0].Password == (inputPassword) && userValidationObject[0].Admin == true)
            {
                userValid = true;
                adminStatus = true;
            return Ok (new {userValid, adminStatus, userValidationObject[0].Ownerid});
            }

            else
            {
                userValid = false;
                adminStatus = false;
                return Ok (new {userValid, adminStatus});
            }

        }
        catch (Exception ex)
        {

            return StatusCode(500, ex.ToString());
        }

    }
    }
}
