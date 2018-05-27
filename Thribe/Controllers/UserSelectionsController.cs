using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thribe.Category.Models;
using Thribe.Data;

namespace Thribe.Controllers
{
    [Produces("application/json")]
    [Route("api/UserSelections")]
    public class UserSelectionsController : Controller
    {
        private readonly ThribeDbContext _context;

        public UserSelectionsController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/UserSelections
        [HttpGet]
        public IEnumerable<UserSelection> GetUserSelections()
        {
            return _context.UserSelections;
        }

        // GET: api/UserSelections/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserSelection([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userSelection = await _context.UserSelections.SingleOrDefaultAsync(m => m.UserSelectionId == id);

            if (userSelection == null)
            {
                return NotFound();
            }

            return Ok(userSelection);
        }

        // PUT: api/UserSelections/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSelection([FromRoute] long id, [FromBody] UserSelection userSelection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userSelection.UserSelectionId)
            {
                return BadRequest();
            }

            _context.Entry(userSelection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSelectionExists(id))
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

        // POST: api/UserSelections
        [HttpPost]
        public async Task<IActionResult> PostUserSelection([FromBody] UserSelection userSelection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserSelections.Add(userSelection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSelection", new { id = userSelection.UserSelectionId }, userSelection);
        }

        // DELETE: api/UserSelections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSelection([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userSelection = await _context.UserSelections.SingleOrDefaultAsync(m => m.UserSelectionId == id);
            if (userSelection == null)
            {
                return NotFound();
            }

            _context.UserSelections.Remove(userSelection);
            await _context.SaveChangesAsync();

            return Ok(userSelection);
        }

        private bool UserSelectionExists(long id)
        {
            return _context.UserSelections.Any(e => e.UserSelectionId == id);
        }
    }
}