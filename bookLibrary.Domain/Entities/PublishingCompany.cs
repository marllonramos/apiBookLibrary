namespace bookLibrary.Domain.Entities
{
    public class PublishingCompany : Entity
    {
        public PublishingCompany(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
