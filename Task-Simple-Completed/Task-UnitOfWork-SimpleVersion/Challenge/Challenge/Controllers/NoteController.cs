using Challenge.DataAccess.Interfaces;
using Challenge.Domain.Entities;
using Challenge.DTOs;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteToReturnDTO>>> GetAllNotes()
        {
            try
            {
                var notes = await _noteService.GetAllNotes();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteToReturnDTO>> GetNoteById(int id)
        {
            try
            {
                var note = await _noteService.GetById(id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNote([FromBody] NoteAddDTO addNoteDto)
        {
            try
            {
                await _noteService.AddNote(addNoteDto);
                return Ok("Note added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNote(int id, [FromBody] NoteUpdatedDTO updateNoteDto)
        {
            try
            {
                await _noteService.UpdateNote(id, updateNoteDto);
                return Ok("Note updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            try
            {
                await _noteService.DeleteNote(id);
                return Ok("Note deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
