using System;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }

        public void FillIdCategory(string id)
        {
            Id = Guid.Parse(id);
        }
    }
}
