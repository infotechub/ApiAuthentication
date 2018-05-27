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
    [Route("api/GetQuestions")]
    public class GetQuestionsController : Controller
    {
        private readonly ThribeDbContext _context;

        public GetQuestionsController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/GetQuestions
        [HttpGet]
        public IEnumerable<GetQuestion> GetQuestions()
        {
            return _context.Questions;
        }

        // GET: api/GetQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGetQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var getQuestion = await _context.Questions.SingleOrDefaultAsync(m => m.QuestionId == id);

            if (getQuestion == null)
            {
                return NotFound();
            }

            return Ok(getQuestion);
        }

        // PUT: api/GetQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetQuestion([FromRoute] long id, [FromBody] GetQuestion getQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != getQuestion.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(getQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetQuestionExists(id))
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

        // POST: api/GetQuestions
        [HttpPost]
        public async Task<IActionResult> PostGetQuestion([FromBody] GetQuestion getQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Questions.Add(getQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGetQuestion", new { id = getQuestion.QuestionId }, getQuestion);
        }

        // DELETE: api/GetQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGetQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var getQuestion = await _context.Questions.SingleOrDefaultAsync(m => m.QuestionId == id);
            if (getQuestion == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(getQuestion);
            await _context.SaveChangesAsync();

            return Ok(getQuestion);
        }

        private bool GetQuestionExists(long id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }
}