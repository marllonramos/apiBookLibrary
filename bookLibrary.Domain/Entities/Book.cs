using System.Collections.Generic;
using System.Linq;
using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public sealed class Book : Entity
    {
        private IList<Exemplary> _exemplaries;

        public string Title { get; private set; }
        public string Description { get; private set; }
        public StatusBook Status { get; private set; }
        public PublishingCompany PublishingCompany { get; private set; }
        public Author Author { get; private set; }
        public Category Category { get; private set; }
        public IEnumerable<Exemplary> Exemplaries { get { return _exemplaries.ToList(); } }

        public Book(string title, string description, PublishingCompany publishingCompany, Author author, Category category)
        {
            Title = title;
            Description = description;
            Status = StatusBook.Ativo;
            PublishingCompany = publishingCompany;
            Author = author;
            Category = category;
            _exemplaries = new List<Exemplary>();
        }

        public void AddExemplaryOfTheBook(Book book)
        {
            foreach (var exemplary in book.Exemplaries)
                _exemplaries.Add(exemplary);
        }

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