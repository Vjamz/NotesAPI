using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Models;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesContext _context;

        public NotesController(NotesContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notes>>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> GetNotesModel(int id)
        {
            var notesModel = await _context.Notes.FindAsync(id);

            if (notesModel == null)
            {
                return NotFound();
            }

            return notesModel;
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotesModel(int id, Notes notesModel)
        {
            if (id != notesModel.id)
            {
                return BadRequest();
            }

            _context.Entry(notesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesModelExists(id))
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

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<Notes>> PostNotesModel(Notes notesModel)
        {
            _context.Notes.Add(notesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNotesModel), new { id = notesModel.id }, notesModel);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notes>> DeleteNotesModel(int id)
        {
            var notesModel = await _context.Notes.FindAsync(id);
            if (notesModel == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(notesModel);
            await _context.SaveChangesAsync();

            return notesModel;
        }

        private bool NotesModelExists(int id)
        {
            return _context.Notes.Any(e => e.id == id);
        }
    }
}
