using System.Collections.Generic;
using System.Linq;
using bookLibrary.Domain.ValueObject;

namespace bookLibrary.Domain.Entities
{
    public sealed class Reader : Entity
    {
        private readonly IList<Book> _books;

        public Reader(string name, User user)
        {
            Name = name;
            User = user;
            _books = new List<Book>();
        }

        public string Name { get; private set; }
        public User User { get; private set; }
        public IEnumerable<Book> Books { get { return _books.ToArray(); } }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
    }
}