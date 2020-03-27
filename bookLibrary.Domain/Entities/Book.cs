using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public sealed class Book : Entity
    {
        public Book(string title, string description, PublishingCompany publishingCompany, Author author, Category category)
        {
            Title = title;
            Description = description;
            Status = StatusBook.QueroComprar;
            PublishingCompany = publishingCompany;
            Author = author;
            Category = category;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public StatusBook Status { get; private set; }
        public PublishingCompany PublishingCompany { get; private set; }
        public Author Author { get; private set; }
        public Category Category { get; private set; }
    }
}