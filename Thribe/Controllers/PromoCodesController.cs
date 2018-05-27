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
    [Route("api/PromoCodes")]
    public class PromoCodesController : Controller
    {
        private readonly ThribeDbContext _context;

        public PromoCodesController(ThribeDbContext context)
        {
            _context = context;
        }

        // GET: api/PromoCodes
        [HttpGet]
        public IEnumerable<PromoCode> GetPromoCodes()
        {
            return _context.PromoCodes;
        }

        // GET: api/PromoCodes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromoCode([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var promoCode = await _context.PromoCodes.SingleOrDefaultAsync(m => m.Code == id);

            if (promoCode == null)
            {
                return NotFound();
            }

            return Ok(promoCode);
        }

        // PUT: api/PromoCodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromoCode([FromRoute] long id, [FromBody] PromoCode promoCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promoCode.Code)
            {
                return BadRequest();
            }

            _context.Entry(promoCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoCodeExists(id))
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

        // POST: api/PromoCodes
        [HttpPost]
        public async Task<IActionResult> PostPromoCode([FromBody] PromoCode promoCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PromoCodes.Add(promoCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromoCode", new { id = promoCode.Code }, promoCode);
        }

        // DELETE: api/PromoCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromoCode([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var promoCode = await _context.PromoCodes.SingleOrDefaultAsync(m => m.Code == id);
            if (promoCode == null)
            {
                return NotFound();
            }

            _context.PromoCodes.Remove(promoCode);
            await _context.SaveChangesAsync();

            return Ok(promoCode);
        }

        private bool PromoCodeExists(long id)
        {
            return _context.PromoCodes.Any(e => e.Code == id);
        }
    }
}