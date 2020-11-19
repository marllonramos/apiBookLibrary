using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.RolesCommands
{
    public class CreateRoleCommand : Notifiable, IValidatable, ICommand
    {
        public string Name { get; set; }
        public int Priority { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Informe o nome do leitor.")
                .HasMinLen(Name, 3, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para o leitor.")
                .HasMaxLen(Name, 30, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para o leitor.")
                .IsGreaterThan(Priority, 0, "Priority", "Informe a prioridade do perfil e ela deve ser maior que 0.")
            );
        }
    }
}
