using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thribe.ApplicationUser.AddressModel;
using Thribe.Data;

namespace Thribe.Controllers
{
    [Produces("application/json")]
    [Route("api/UserAddresses")]
    public class UserAddressesController : Controller
    {
        private readonly ThribeDbContext _context;

        public UserAddressesController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/UserAddresses
        [HttpGet]
        public IEnumerable<UserAddress> GetUserAddresses()
        {
            return _context.UserAddresses;
        }

        // GET: api/UserAddresses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userAddress = await _context.UserAddresses.SingleOrDefaultAsync(m => m.Id == id);

            if (userAddress == null)
            {
                return NotFound();
            }

            return Ok(userAddress);
        }

        // PUT: api/UserAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAddress([FromRoute] int id, [FromBody] UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressExists(id))
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

        // POST: api/UserAddresses
        [HttpPost]
        public async Task<IActionResult> PostUserAddress([FromBody] UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserAddresses.Add(userAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAddress", new { id = userAddress.Id }, userAddress);
        }

        // DELETE: api/UserAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userAddress = await _context.UserAddresses.SingleOrDefaultAsync(m => m.Id == id);
            if (userAddress == null)
            {
                return NotFound();
            }

            _context.UserAddresses.Remove(userAddress);
            await _context.SaveChangesAsync();

            return Ok(userAddress);
        }

        private bool UserAddressExists(int id)
        {
            return _context.UserAddresses.Any(e => e.Id == id);
        }
    }
}