using Challenge.DataAccess.Interfaces;
using Challenge.Domain.Entities;
using Challenge.DTOs;
using Challenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddNote(NoteAddDTO addNoteDto)
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

            _unitOfWork.NoteRepository.Add(noteToAdd);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteNote(int id)
        {
            var note = _unitOfWork.NoteRepository.GetById(id);

            if (note == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _unitOfWork.NoteRepository.Delete(note);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<NoteToReturnDTO>> GetAllNotes()
        {
            var notes = _unitOfWork.NoteRepository.GetAll();

            return notes.Select(note => new NoteToReturnDTO
            {
                Id = note.Id,
                Name = note.Name,
                DueDate = note.DueDate,
                Description = note.Description,
                Status = note.Status.ToString()
            }).ToList();
        }

        public async Task<NoteToReturnDTO> GetById(int id)
        {
            var note = _unitOfWork.NoteRepository.GetById(id);

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

        public async Task UpdateNote(int id, NoteUpdatedDTO updateNoteDto)
        {
            if (updateNoteDto == null)
            {
                throw new Exception("Entity cannot be null");
            }

            var existingNote = _unitOfWork.NoteRepository.GetById(id);

            if (existingNote == null)
            {
                throw new Exception("Entity cannot be null");
            }

            existingNote.Name = updateNoteDto.Name;
            existingNote.DueDate = updateNoteDto.DueDate;
            existingNote.Description = updateNoteDto.Description;
            existingNote.Status = updateNoteDto.Status;

            _unitOfWork.NoteRepository.Update(existingNote);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}

