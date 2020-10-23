using System.Collections.Generic;
using System.Linq;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public sealed class Reader : Entity
    {
        private readonly IList<Book> _books;

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public IEnumerable<Book> Books { get { return _books.ToList(); } }

        public Reader(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public bool IsExist(string email)
        {
            bool existEmail = false;

            if (Email.Equals(email))
                existEmail = true;

            return existEmail;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }
    }
}