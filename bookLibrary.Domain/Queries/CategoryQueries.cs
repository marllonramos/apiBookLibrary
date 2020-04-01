using bookLibrary.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace bookLibrary.Domain.Queries
{
    public static class CategoryQueries
    {
        public static Expression<Func<Category, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
