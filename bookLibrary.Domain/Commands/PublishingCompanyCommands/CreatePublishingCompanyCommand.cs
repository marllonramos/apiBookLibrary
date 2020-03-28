using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.PublishingCompanyCommands
{
    public class CreatePublishingCompanyCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Informe o nome da editora.")
                .HasMinLen(Name, 3, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para a editora.")
                .HasMaxLen(Name, 30, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para a editora.")
            );
        }
    }
}
