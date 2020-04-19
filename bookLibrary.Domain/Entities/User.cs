using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public abstract class User : Entity
    {
        protected User() { }

        protected User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public bool IsExist(string email)
        {
            bool existEmail = false;

            if (Email.Equals(email))
                existEmail = true;

            return existEmail;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }
    }
}