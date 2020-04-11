using bookLibrary.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Repositories
{
    public interface IReaderRepository
    {
        Task<Reader> GetReader(Guid id);
        Task CreateReader(Reader reader);
        Task UpdateReader(Reader reader);
        Task DeleteReader(Guid id);
    }
}
