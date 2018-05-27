using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thribe.Data;
using Thribe.MyOrder;

namespace Thribe.Controllers
{
    [Produces("application/json")]
    [Route("api/Jobs")]
    public class JobsController : Controller
    {
        private readonly ThribeDbContext _context;

        public JobsController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        public IEnumerable<Job> GetMyJobs()
        {
            return _context.MyJobs;
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var job = await _context.MyJobs.SingleOrDefaultAsync(m => m.JobId == id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob([FromRoute] long id, [FromBody] Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.JobId)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Jobs
        [HttpPost]
        public async Task<IActionResult> PostJob([FromBody] Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MyJobs.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = job.JobId }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var job = await _context.MyJobs.SingleOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            _context.MyJobs.Remove(job);
            await _context.SaveChangesAsync();

            return Ok(job);
        }

        private bool JobExists(long id)
        {
            return _context.MyJobs.Any(e => e.JobId == id);
        }
    }
}