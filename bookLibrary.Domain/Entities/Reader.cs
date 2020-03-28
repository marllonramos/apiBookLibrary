using System.Collections.Generic;
using System.Linq;

namespace bookLibrary.Domain.Entities
{
    public sealed class Reader : User
    {
        private readonly IList<Book> _books;

        public Reader(string name, string email, string password)
            : base(name, email, password)
        {
            _books = new List<Book>();
        }

        public IEnumerable<Book> Books { get { return _books.ToArray(); } }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
    }
}