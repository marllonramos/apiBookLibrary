using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class PublishingCompany : Entity
    {
        public PublishingCompany()
        {

        }

        public PublishingCompany(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
