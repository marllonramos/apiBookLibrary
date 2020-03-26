using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace bookLibrary.Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                .Requires()
                .IsNotEmpty(Id, "Id", "Informe o id da categoria.")
                .IsNotNullOrEmpty(Name, "Name", "Informe o nome da categoria.")
                .HasMinLen(Name, 3, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para a categoria.")
                .HasMaxLen(Name, 30, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para a categoria.")
            );
        }
    }
}
