using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class Exemplary : Entity
    {
        public StatusExemplary Status { get; private set; }
        public Book Book { get; private set; }
        public Reader Reader { get; private set; }

        public Exemplary(Book book, Reader reader)
        {
            Status = StatusExemplary.FilaDeLeitura;
            Book = book;
            Reader = reader;

            AddNotifications(book, reader);
        }
    }
}