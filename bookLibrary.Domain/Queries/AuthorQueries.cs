using bookLibrary.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace bookLibrary.Domain.Queries
{
    public static class AuthorQueries
    {
        public static Expression<Func<Author, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
