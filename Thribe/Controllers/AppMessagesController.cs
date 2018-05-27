using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thribe.AppMessage.Infrastructure;
using Thribe.Data;

namespace Thribe.Controllers
{
    [Produces("application/json")]
    [Route("api/AppMessages")]
    public class AppMessagesController : Controller
    {
        private readonly ThribeDbContext _context;

        public AppMessagesController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/AppMessages
        [HttpGet]
        public IEnumerable<AppMessages> GetAppMessages()
        {
            return _context.AppMessages;
        }

        // GET: api/AppMessages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppMessages([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appMessages = await _context.AppMessages.SingleOrDefaultAsync(m => m.MessageId == id);

            if (appMessages == null)
            {
                return NotFound();
            }

            return Ok(appMessages);
        }

        // PUT: api/AppMessages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppMessages([FromRoute] long id, [FromBody] AppMessages appMessages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appMessages.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(appMessages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppMessagesExists(id))
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

        // POST: api/AppMessages
        [HttpPost]
        public async Task<IActionResult> PostAppMessages([FromBody] AppMessages appMessages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AppMessages.Add(appMessages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppMessages", new { id = appMessages.MessageId }, appMessages);
        }

        // DELETE: api/AppMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppMessages([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appMessages = await _context.AppMessages.SingleOrDefaultAsync(m => m.MessageId == id);
            if (appMessages == null)
            {
                return NotFound();
            }

            _context.AppMessages.Remove(appMessages);
            await _context.SaveChangesAsync();

            return Ok(appMessages);
        }

        private bool AppMessagesExists(long id)
        {
            return _context.AppMessages.Any(e => e.MessageId == id);
        }
    }
}