using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Notey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly TaggingContext _context;

        public NoteController(TaggingContext context)
        {
            _context = context;
            Console.WriteLine("injected dbContext!");
        }

        // GET: api/Note
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            Console.WriteLine("Serviced Post!");
            return await _context.Notes.ToListAsync();
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/Note/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, Note note)
        {
            if (id != note.NoteId)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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

        // POST: api/Note
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        // curl it like this 
        // curl -X POST https://localhost:5001/api/Note -d '{"title":"Hey","content":"Wasaap"}' -k -H "Content-Type:application/json"

        

        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            Console.WriteLine("Serviced a Post!");

            return CreatedAtAction("GetNote", new { id = note.NoteId }, note);
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> DeleteNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return note;
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.NoteId == id);
        }
    }
}
