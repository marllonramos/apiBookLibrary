using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class Author : Entity
    {
        public Author(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
