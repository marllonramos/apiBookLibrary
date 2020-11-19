using bookLibrary.Domain.Shared;
using System;

namespace bookLibrary.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; private set; }
        public int Priority { get; private set; }

        public Role(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }

        public void FillRoleId(Guid id)
        {
            Id = Id;
        }

        public void UpdatePriority(int priority)
        {
            Priority = priority;
        }

        // Criar um m�todo para s� quem for admin puder cadastrar um perfil(� uma regra de neg�cio).
    }
}