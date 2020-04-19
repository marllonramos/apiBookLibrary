using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class Author : Entity
    {
        public Author()
        {

        }

        public Author(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
