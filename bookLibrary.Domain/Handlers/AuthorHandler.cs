using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.AuthorCommands;
using bookLibrary.Domain.Entities;
using Flunt.Notifications;

namespace bookLibrary.Domain.Handlers
{
    public class AuthorHandler : Notifiable, IHandler<CreateAuthorCommand>, IHandler<UpdateAuthorCommand>
    {
        public AuthorHandler()
        {
        }

        public IResultCommand Handler(CreateAuthorCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            Author author = new Author(command.Name);

            //TODO: implementar repositório

            return new ResultCommand { Message = "Autor cadastrado com sucesso!", Success = true, Data = author };
        }

        public IResultCommand Handler(UpdateAuthorCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            //TODO: consultar autor e alterar os dados com os dados novos
            // Author autor = repository.Get(command.Id);

            return new ResultCommand { Message = "Autor atualizado com sucesso!", Success = true, Data = new Author("") };
        }
    }
}