using System;
using System.Threading.Tasks;
using bookLibrary.Domain.Entities;

namespace bookLibrary.Domain.Repositories
{
    public interface IExemplaryRepository
    {
        Task<Exemplary> GetExemplary(Guid id);
        Task CreateExemplary(Exemplary exemplary);
        Task UpdateExemplary(Exemplary exemplary);
    }
}