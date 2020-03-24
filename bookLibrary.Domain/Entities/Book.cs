namespace bookLibrary.Domain.Entities
{
    public sealed class Book : Entity
    {
        public Book(string name, string description, int status)
        {
            Name = name;
            Description = description;
            Status = status;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Status { get; private set; }
    }
}