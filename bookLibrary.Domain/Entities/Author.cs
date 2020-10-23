using System;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class Author : Entity
    {
        public string Name { get; private set; }

        public Author(string name)
        {
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void FillIdAuthor(string id)
        {
            Id = Guid.Parse(id);
        }
    }
}
