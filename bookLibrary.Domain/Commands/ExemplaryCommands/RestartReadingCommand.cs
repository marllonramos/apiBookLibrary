using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.ExemplaryCommands
{
    public class RestartReadingCommand : Notifiable, IValidatable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), "Id", "Exemplar não informado.")
            );
        }
    }
}