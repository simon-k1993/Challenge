using Challenge.DataAccess.Interfaces;
using Challenge.Domain.Entities;
using Challenge.DTOs;
using Challenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.Implentations
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository<Note> _noteRepository;

        public NoteService(INoteRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public void AddNote(NoteAddDTO addNoteDto)
        {
            if (addNoteDto == null)
            {
                throw new Exception("Entity cannot be null");
            }

            var noteToAdd = new Note
            {
                Name = addNoteDto.Name,
                DueDate = addNoteDto.DueDate,
                Description = addNoteDto.Description,
                Status = addNoteDto.Status
            };

            _noteRepository.Add(noteToAdd);
        }

        public void DeleteNote(int id)
        {
            var note = _noteRepository.GetById(id);

            if (note == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _noteRepository.Delete(note);
        }

        public List<NoteToReturnDTO> GetAllNotes()
        {
            var notes = _noteRepository.GetAll();

            return notes.Select(note => new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString()
            }).ToList();
        }

        public NoteToReturnDTO GetById(int id)
        {
            var note = _noteRepository.GetById(id);

            if (note == null)
            {
                throw new Exception("Entity cannot be null");
            }

            return new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString()
            };
        }

        public void UpdateNote(int id, NoteUpdatedDTO updateNoteDto)
        {
            if (updateNoteDto == null)
            {
                throw new Exception("Entity cannot be null");
            }

            var existingNote = _noteRepository.GetById(id);

            if (existingNote == null)
            {
                throw new Exception("Entity cannot be null");
            }

            existingNote.Name = updateNoteDto.Name;
            existingNote.DueDate = updateNoteDto.DueDate;
            existingNote.Description = updateNoteDto.Description;
            existingNote.Status = updateNoteDto.Status;

            _noteRepository.Update(existingNote);
        }
    }
}
