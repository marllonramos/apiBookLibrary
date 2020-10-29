using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.ExemplaryCommands
{
    public class CreateExemplaryCommand : Notifiable, IValidatable, ICommand
    {
        public Guid IdReader { get; set; }
        public Guid IdBook { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(IdReader.ToString(), "IdReader", "Leitor não informado.")
                .IsNotNullOrEmpty(IdBook.ToString(), "IdBook", "Livro não informado.")
            );
        }
    }
}