using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.CategoryCommands
{
    public class CreateCategoryCommand : Notifiable, ICommand 
    {
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Informe o nome da categoria.")
                .HasMinLen(Name, 3, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para a categoria.")
                .HasMaxLen(Name, 30, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para a categoria.")
            );
        }
    }
}
