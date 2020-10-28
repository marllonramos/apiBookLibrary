using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.ExemplaryCommands
{
    public class UpdateExemplaryCommand : Notifiable, IValidatable, ICommand
    {
        

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}