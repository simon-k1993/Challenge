using Challenge.DataAccess;
using Challenge.Domain.Entities;
using Challenge.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Challenge.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NoteToReturnDTO>> GetTasks()
        {
            var notes = _context.Notes.ToList();

            var notesToReturn = notes.Select(note => new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString()
            }).ToList();

            return notesToReturn;
        }

        [HttpPost]
        public ActionResult<Note> CreateTask(NoteCreateDTO noteCreateDTO)
        {

            var note = new Note
            {
                Name = noteCreateDTO.Name,
                DueDate = noteCreateDTO.DueDate,
                Description = noteCreateDTO.Description,
                Status = noteCreateDTO.Status
            };

            _context.Notes.Add(note);
            _context.SaveChanges();

            var responseMessage = $"Note '{note.Name}' created successfully on {DateTime.Now}";

            return Ok(new { Message = responseMessage, CreatedNote = note });
        }



        [HttpGet("{id}")]
        public ActionResult<NoteToReturnDTO> GetTask(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
                return NotFound();

            var noteToReturn = new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString()
            };

            return noteToReturn;
        }


        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] NoteUpdatedDTO updatedNoteDTO)
        {
            var existingNote = _context.Notes.Find(id);

            if (existingNote == null)
            {
                return NotFound();
            }

            if (updatedNoteDTO.Name != null)
            {
                existingNote.Name = updatedNoteDTO.Name;
            }

            if (updatedNoteDTO.DueDate != default)
            {
                existingNote.DueDate = updatedNoteDTO.DueDate;
            }

            if (updatedNoteDTO.Description != null)
            {
                existingNote.Description = updatedNoteDTO.Description;
            }

            if (updatedNoteDTO.Status != null)
            {
                existingNote.Status = updatedNoteDTO.Status;
            }


            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
                return NotFound();

            _context.Notes.Remove(note);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
