using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thribe.AppSupport.Infrastructure;
using Thribe.Data;

namespace Thribe.Controllers
{
    [Produces("application/json")]
    [Route("api/Supports")]
    public class SupportsController : Controller
    {
        private readonly ThribeDbContext _context;

        public SupportsController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/Supports
        [HttpGet]
        public IEnumerable<Support> GetSupports()
        {
            return _context.Supports;
        }

        // GET: api/Supports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupport([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var support = await _context.Supports.SingleOrDefaultAsync(m => m.SupportId == id);

            if (support == null)
            {
                return NotFound();
            }

            return Ok(support);
        }

        // PUT: api/Supports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupport([FromRoute] long id, [FromBody] Support support)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != support.SupportId)
            {
                return BadRequest();
            }

            _context.Entry(support).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportExists(id))
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

        // POST: api/Supports
        [HttpPost]
        public async Task<IActionResult> PostSupport([FromBody] Support support)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Supports.Add(support);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupport", new { id = support.SupportId }, support);
        }

        // DELETE: api/Supports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupport([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var support = await _context.Supports.SingleOrDefaultAsync(m => m.SupportId == id);
            if (support == null)
            {
                return NotFound();
            }

            _context.Supports.Remove(support);
            await _context.SaveChangesAsync();

            return Ok(support);
        }

        private bool SupportExists(long id)
        {
            return _context.Supports.Any(e => e.SupportId == id);
        }
    }
}