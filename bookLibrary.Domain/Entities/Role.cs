using bookLibrary.Domain.Shared;
using System;
using System.Collections.Generic;

namespace bookLibrary.Domain.Entities
{
    public class Role : Entity
    {
        private readonly List<Reader> _readers;

        public string Name { get; private set; }
        public int Priority { get; private set; }
        public IEnumerable<Reader> Readers { get { return _readers.ToArray(); } }

        public Role(string name, int priority)
        {
            Name = name;
            Priority = priority;
            _readers = new List<Reader>();
        }

        public void FillRoleId(Guid id)
        {
            Id = id;
        }

        public void UpdatePriority(int priority)
        {
            Priority = priority;
        }

        // Criar um m�todo para s� quem for admin puder cadastrar um perfil(� uma regra de neg�cio).
    }
}