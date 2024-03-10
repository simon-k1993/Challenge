using Challenge.DTOs;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NoteToReturnDTO>> GetTasks()
        {
            var notes = _noteService.GetAllNotes();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public ActionResult<NoteToReturnDTO> GetTask(int id)
        {
            try
            {
                var note = _noteService.GetById(id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<NoteToReturnDTO> CreateTask(NoteAddDTO noteAddDTO)
        {
            _noteService.AddNote(noteAddDTO);
            var responseMessage = $"Note '{noteAddDTO.Name}' created successfully on {DateTime.Now}";
            return Ok(new { Message = responseMessage });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] NoteUpdatedDTO updatedNoteDTO)
        {
            try
            {
                _noteService.UpdateNote(id, updatedNoteDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                _noteService.DeleteNote(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
