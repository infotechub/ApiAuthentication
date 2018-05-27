using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thribe.ApplicationUser.UserModel;
using Thribe.Data;

namespace Thribe.Controllers
{
    [Produces("application/json")]
    [Route("api/SelectedSkills")]
    public class SelectedSkillsController : Controller
    {
        private readonly ThribeDbContext _context;

        public SelectedSkillsController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/SelectedSkills
        [HttpGet]
        public IEnumerable<SelectedSkill> GetSelectedSkills()
        {
            return _context.SelectedSkills;
        }

        // GET: api/SelectedSkills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSelectedSkill([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selectedSkill = await _context.SelectedSkills.SingleOrDefaultAsync(m => m.SelectedSkillId == id);

            if (selectedSkill == null)
            {
                return NotFound();
            }

            return Ok(selectedSkill);
        }

        // PUT: api/SelectedSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelectedSkill([FromRoute] long id, [FromBody] SelectedSkill selectedSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selectedSkill.SelectedSkillId)
            {
                return BadRequest();
            }

            _context.Entry(selectedSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectedSkillExists(id))
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

        // POST: api/SelectedSkills
        [HttpPost]
        public async Task<IActionResult> PostSelectedSkill([FromBody] SelectedSkill selectedSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SelectedSkills.Add(selectedSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelectedSkill", new { id = selectedSkill.SelectedSkillId }, selectedSkill);
        }

        // DELETE: api/SelectedSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelectedSkill([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selectedSkill = await _context.SelectedSkills.SingleOrDefaultAsync(m => m.SelectedSkillId == id);
            if (selectedSkill == null)
            {
                return NotFound();
            }

            _context.SelectedSkills.Remove(selectedSkill);
            await _context.SaveChangesAsync();

            return Ok(selectedSkill);
        }

        private bool SelectedSkillExists(long id)
        {
            return _context.SelectedSkills.Any(e => e.SelectedSkillId == id);
        }
    }
}