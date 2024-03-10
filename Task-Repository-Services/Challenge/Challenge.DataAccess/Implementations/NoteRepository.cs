using Challenge.DataAccess.Interfaces;
using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.DataAccess.Implementations
{
    public class NoteRepository : INoteRepository<Note>
    {
        private readonly AppDbContext _appDbContext;

        public NoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Note entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _appDbContext.Notes.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(Note entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _appDbContext.Notes.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public List<Note> GetAll()
        {
            return _appDbContext.Notes.ToList();
        }

        public Note GetById(int id)
        {
            return _appDbContext.Notes.Find(id);
        }

        public void Update(Note entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }

            _appDbContext.Notes.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
