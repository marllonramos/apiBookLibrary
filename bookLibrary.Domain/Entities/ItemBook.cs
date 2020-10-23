using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class ItemBook : Entity
    {
        public StatusItemBook Status { get; private set; }
        public Book Book { get; private set; }
        public Reader Reader { get; private set; }

        public ItemBook(StatusItemBook status, Book book, Reader reader)
        {
            Status = status;
            Book = book;
            Reader = reader;
        }
    }
}