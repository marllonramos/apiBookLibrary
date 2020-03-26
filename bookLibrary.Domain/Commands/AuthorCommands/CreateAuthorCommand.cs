using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.AuthorCommands
{
    public class CreateAuthorCommand : Notifiable, ICommand
    {
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications
           (
                new Contract()
                .Requires()
                .IsNullOrEmpty(Name, "Name", "Informe o nome do autor.")
                .HasMinLen(Name, 3, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para o autor.")
                .HasMaxLen(Name, 30, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para o autor.")
           );
        }
    }
}
