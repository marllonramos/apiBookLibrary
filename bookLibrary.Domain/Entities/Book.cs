using System;
using System.Collections.Generic;
using System.Linq;
using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public sealed class Book : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public EStatusBook Status { get; private set; }
        public PublishingCompany PublishingCompany { get; private set; }
        public Author Author { get; private set; }
        public Category Category { get; private set; }

        public Book(string title, string description, PublishingCompany publishingCompany, Author author, Category category)
        {
            Title = title;
            Description = description;
            Status = EStatusBook.Ativo;
            PublishingCompany = publishingCompany;
            Author = author;
            Category = category;
        }

        public void FillIdBook(string id)
        {
            Id = Guid.Parse(id);
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
        public void UpdateDescription(string description)
        {
            Description = description;
        }
        public void UpdateStatus(EStatusBook status)
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