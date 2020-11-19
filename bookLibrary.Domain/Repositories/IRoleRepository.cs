using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRole(Guid id);
        Task<List<Role>> GetAllRoles();
        Task CreateRole(Role role);
        Task UpdateRole(Role role);
        Task DeleteRole(Guid id);
    }
}