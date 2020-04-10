using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace bookLibrary.Domain.Queries
{
    public static class ReaderQueries
    {
        public static Expression<Func<Reader, IEnumerable<Book>>> GetBookByReader(Guid id)
        {
            return x => x.Books.Where(b => b.Reader.Id == id);
        }
    }
}
