using System;
using Flunt.Notifications;

namespace bookLibrary.Domain.Shared
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}