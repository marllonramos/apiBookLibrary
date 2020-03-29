using bookLibrary.Domain.Entities;
using System;

namespace bookLibrary.Domain.Repositories
{
    public interface ReaderRepository
    {
        Reader GetReader(Guid id);
        void CreateReader(Reader reader);
        void UpdateReader(Reader reader);
        void DeleteReader(Guid id);
    }
}
