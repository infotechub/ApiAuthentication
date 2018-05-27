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
    [Route("api/Answers")]
    public class AnswersController : Controller
    {
        private readonly ThribeDbContext _context;

        public AnswersController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet]
        public IEnumerable<Answer> GetAnswers()
        {
            return _context.Answers;
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answer = await _context.Answers.SingleOrDefaultAsync(m => m.AnswerId == id);

            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        // PUT: api/Answers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer([FromRoute] long id, [FromBody] Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answer.AnswerId)
            {
                return BadRequest();
            }

            _context.Entry(answer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        [HttpPost]
        public async Task<IActionResult> PostAnswer([FromBody] Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswer", new { id = answer.AnswerId }, answer);
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answer = await _context.Answers.SingleOrDefaultAsync(m => m.AnswerId == id);
            if (answer == null)
            {
                return NotFound();
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return Ok(answer);
        }

        private bool AnswerExists(long id)
        {
            return _context.Answers.Any(e => e.AnswerId == id);
        }
    }
}