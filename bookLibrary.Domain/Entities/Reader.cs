using System;
using System.Collections.Generic;
using System.Linq;
using bookLibrary.Domain.Shared;
using Flunt.Validations;

namespace bookLibrary.Domain.Entities
{
    public sealed class Reader : Entity
    {
        private readonly IList<Exemplary> _exemplaries;

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public IEnumerable<Exemplary> Exemplaries { get { return _exemplaries.ToList(); } }
        public Guid RoleId { get; private set; }
        public Role Role { get; private set; }

        public Reader(string name, string email, string password, Guid roleId)
        {
            Name = name;
            Email = email;
            Password = password;
            _exemplaries = new List<Exemplary>();
            RoleId = roleId;
        }

        public void AddRole(Role role)
        {
            Role = role;
        }

        public void AddExemplary(Exemplary exemplary)
        {
            foreach (var myExemplary in Exemplaries)
            {
                AddNotifications(new Contract()
                    .Requires()
                    .AreNotEquals(myExemplary.Id, exemplary.Id, "Book", $"O livro {exemplary.Book.Title} já existe na sua lista de livros.")
                );
            }            

            if(Invalid)
                return;

            _exemplaries.Add(exemplary);
        }

        public void IsExist(string email)
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(Email, email, "Email", "Esse email já está em uso.")
            );
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public void UpdateRole(Guid idRole)
        {
            RoleId = idRole;
        }

        public void FillReaderId(Guid id)
        {
            Id = id;
        }
    }
}