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
        List<NoteToReturnDTO> GetAllNotes();
        NoteToReturnDTO GetById(int id);
        void AddNote(NoteAddDTO addNoteDto);
        public void UpdateNote(int id, NoteUpdatedDTO updateNoteDto);
        void DeleteNote(int id);
    }
}
