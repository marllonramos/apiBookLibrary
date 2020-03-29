using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace bookLibrary.Domain.Commands.AuthorCommands
{
    public class UpdateAuthorCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                .Requires()
                .IsNotEmpty(Id, "Id", "Informe o id do autor.")
                .IsNotNullOrEmpty(Name, "Name", "Informe o nome do autor.")
                .HasMinLen(Name, 3, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para o autor.")
                .HasMaxLen(Name, 30, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para o autor.")
            );
        }
    }
}
