using Challenge.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.Interfaces
{
    public interface INoteService
    {
        Task<List<NoteToReturnDTO>> GetAllNotes();
        Task<NoteToReturnDTO> GetById(int id);
        Task AddNote(NoteAddDTO addNoteDto);
        Task UpdateNote(int id, NoteUpdatedDTO updateNoteDto);
        Task DeleteNote(int id);
    }
}
