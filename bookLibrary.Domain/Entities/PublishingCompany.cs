using System;
using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class PublishingCompany : Entity
    {
        public PublishingCompany(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }

        public void FillIdPublishingCompany(string id)
        {
            Id = Guid.Parse(id);
        }
    }
}
