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

        public void UpdateTitle(string title)
        {
            Title = title;
        }
        public void UpdateDescription(string description)
        {
            Description = description;
        }
        public void UpdateStatus(StatusBook status)
        {
            Status = status;
        }
        public void UpdatePublishingCompany(PublishingCompany publishingCompany)
        {
            PublishingCompany = publishingCompany;
        }
        public void UpdateAuthor(Author author)
        {
            Author = author;
        }
        public void UpdateCategory(Category category)
        {
            Category = category;
        }
    }
}