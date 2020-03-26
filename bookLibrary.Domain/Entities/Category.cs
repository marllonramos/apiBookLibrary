﻿using bookLibrary.Domain.Shared;

namespace bookLibrary.Domain.Entities
{
    public class Category : Entity
    {
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
