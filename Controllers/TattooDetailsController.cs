using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TattooStudioApi.Data;
using TattooStudioApi.Models;

namespace TattooStudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TattooDetailsController : ControllerBase
    {
        private readonly TattooStudioDbContext _context;

        public TattooDetailsController(TattooStudioDbContext context)
        {
            _context = context;
        }

        // GET: api/TattooDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TattooDetail>>> GetTattooDetails()
        {
            return await _context.TattooDetails.ToListAsync();
        }

        // GET: api/TattooDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TattooDetail>> GetTattooDetail(Guid id)
        {
            var tattooDetail = await _context.TattooDetails.FindAsync(id);

            if (tattooDetail == null)
            {
                return NotFound();
            }

            return tattooDetail;
        }

        // PUT: api/TattooDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTattooDetail(Guid id, TattooDetail tattooDetail)
        {
            if (id != tattooDetail.RowKey)
            {
                return BadRequest();
            }

            _context.Entry(tattooDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TattooDetailExists(id))
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

        // POST: api/TattooDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TattooDetail>> PostTattooDetail(TattooDetail tattooDetail)
        {
            _context.TattooDetails.Add(tattooDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTattooDetail", new { id = tattooDetail.RowKey }, tattooDetail);
        }

        // DELETE: api/TattooDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTattooDetail(Guid id)
        {
            var tattooDetail = await _context.TattooDetails.FindAsync(id);
            if (tattooDetail == null)
            {
                return NotFound();
            }

            _context.TattooDetails.Remove(tattooDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TattooDetailExists(Guid id)
        {
            return _context.TattooDetails.Any(e => e.RowKey == id);
        }
    }
}
