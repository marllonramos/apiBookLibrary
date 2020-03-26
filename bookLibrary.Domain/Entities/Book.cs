using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public sealed class Book : Entity
    {
        public Book(string name, string description, int status, PublishingCompany publishingCompany, Author author, Category category)
        {
            Name = name;
            Description = description;
            Status = status;
            PublishingCompany = publishingCompany;
            Author = author;
            Category = category;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Status { get; private set; }
        public PublishingCompany PublishingCompany { get; private set; }
        public Author Author { get; private set; }
        public Category Category { get; private set; }
    }
}