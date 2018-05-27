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
    [Route("api/ServiceCategories")]
    public class ServiceCategoriesController : Controller
    {
        private readonly ThribeDbContext _context;

        public ServiceCategoriesController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceCategories
        [HttpGet]
        public IEnumerable<ServiceCategory> GetServiceCategories()
        {
            return _context.ServiceCategories;
        }

        // GET: api/ServiceCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceCategory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceCategory = await _context.ServiceCategories.SingleOrDefaultAsync(m => m.CategoryId == id);

            if (serviceCategory == null)
            {
                return NotFound();
            }

            return Ok(serviceCategory);
        }

        // PUT: api/ServiceCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceCategory([FromRoute] long id, [FromBody] ServiceCategory serviceCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceCategory.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(serviceCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceCategoryExists(id))
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

        // POST: api/ServiceCategories
        [HttpPost]
        public async Task<IActionResult> PostServiceCategory([FromBody] ServiceCategory serviceCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServiceCategories.Add(serviceCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceCategory", new { id = serviceCategory.CategoryId }, serviceCategory);
        }

        // DELETE: api/ServiceCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceCategory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceCategory = await _context.ServiceCategories.SingleOrDefaultAsync(m => m.CategoryId == id);
            if (serviceCategory == null)
            {
                return NotFound();
            }

            _context.ServiceCategories.Remove(serviceCategory);
            await _context.SaveChangesAsync();

            return Ok(serviceCategory);
        }

        private bool ServiceCategoryExists(long id)
        {
            return _context.ServiceCategories.Any(e => e.CategoryId == id);
        }
    }
}