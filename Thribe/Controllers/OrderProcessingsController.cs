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
    [Route("api/OrderProcessings")]
    public class OrderProcessingsController : Controller
    {
        private readonly ThribeDbContext _context;

        public OrderProcessingsController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderProcessings
        [HttpGet]
        public IEnumerable<OrderProcessing> GetProcessings()
        {
            return _context.Processings;
        }

        // GET: api/OrderProcessings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderProcessing([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderProcessing = await _context.Processings.SingleOrDefaultAsync(m => m.ProcessingId == id);

            if (orderProcessing == null)
            {
                return NotFound();
            }

            return Ok(orderProcessing);
        }

        // PUT: api/OrderProcessings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderProcessing([FromRoute] long id, [FromBody] OrderProcessing orderProcessing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderProcessing.ProcessingId)
            {
                return BadRequest();
            }

            _context.Entry(orderProcessing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderProcessingExists(id))
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

        // POST: api/OrderProcessings
        [HttpPost]
        public async Task<IActionResult> PostOrderProcessing([FromBody] OrderProcessing orderProcessing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Processings.Add(orderProcessing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderProcessing", new { id = orderProcessing.ProcessingId }, orderProcessing);
        }

        // DELETE: api/OrderProcessings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderProcessing([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderProcessing = await _context.Processings.SingleOrDefaultAsync(m => m.ProcessingId == id);
            if (orderProcessing == null)
            {
                return NotFound();
            }

            _context.Processings.Remove(orderProcessing);
            await _context.SaveChangesAsync();

            return Ok(orderProcessing);
        }

        private bool OrderProcessingExists(long id)
        {
            return _context.Processings.Any(e => e.ProcessingId == id);
        }
    }
}