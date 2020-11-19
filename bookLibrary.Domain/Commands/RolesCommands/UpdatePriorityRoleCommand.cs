using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.RolesCommands
{
    public class UpdatePriorityRoleCommand : Notifiable, IValidatable, ICommand
    {
        public Guid Id { get; set; }
        public int Priority { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Priority, 0, "Priority", "Informe a prioridade do perfil e ela deve ser maior que 0.")
            );
        }
    }
}
