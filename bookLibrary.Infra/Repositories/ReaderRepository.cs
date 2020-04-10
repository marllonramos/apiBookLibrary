using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace bookLibrary.Infra.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly DbBookContext _context;

        public ReaderRepository(DbBookContext context)
        {
            _context = context;
        }

        public void CreateReader(Reader reader)
        {
            _context.Readers.Add(reader);
            _context.SaveChanges();
        }

        public void DeleteReader(Guid id)
        {
            Reader reader = GetReader(id);

            _context.Readers.Remove(reader);
            _context.SaveChanges();
        }

        public Reader GetReader(Guid id)
        {
            return _context.Readers
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void UpdateReader(Reader reader)
        {
            _context.Entry<Reader>(reader).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
