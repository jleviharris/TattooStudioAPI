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
    public class ClientNotesController : ControllerBase
    {
        private readonly TattooStudioDbContext _context;

        public ClientNotesController(TattooStudioDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientNote>>> GetClientNotes()
        {
            return await _context.ClientNotes.ToListAsync();
        }

        // GET: api/ClientNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientNote>> GetClientNote(Guid id)
        {
            var clientNote = await _context.ClientNotes.FindAsync(id);

            if (clientNote == null)
            {
                return NotFound();
            }

            return clientNote;
        }

        // PUT: api/ClientNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientNote(Guid id, ClientNote clientNote)
        {
            if (id != clientNote.RowKey)
            {
                return BadRequest();
            }

            _context.Entry(clientNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientNoteExists(id))
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

        // POST: api/ClientNotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientNote>> PostClientNote(ClientNote clientNote)
        {
            _context.ClientNotes.Add(clientNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientNote", new { id = clientNote.RowKey }, clientNote);
        }

        // DELETE: api/ClientNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientNote(Guid id)
        {
            var clientNote = await _context.ClientNotes.FindAsync(id);
            if (clientNote == null)
            {
                return NotFound();
            }

            _context.ClientNotes.Remove(clientNote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientNoteExists(Guid id)
        {
            return _context.ClientNotes.Any(e => e.RowKey == id);
        }
    }
}
