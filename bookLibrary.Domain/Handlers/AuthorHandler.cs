using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.AuthorCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;

namespace bookLibrary.Domain.Handlers
{
    public class AuthorHandler : Notifiable, IHandler<CreateAuthorCommand>, IHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorHandler(IAuthorRepository authorRepository)
        {
            authorRepository = _authorRepository;
        }

        public IResultCommand Handler(CreateAuthorCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            Author author = new Author(command.Name);

            // Autor não possui regras de negócio. Caso possuísse, chamaríamos ela aqui e adicionaríamos ao AddNotifications.

            _authorRepository.Create(author);

            return new ResultCommand { Message = "Autor cadastrado com sucesso!", Success = true, Data = author };
        }

        public IResultCommand Handler(UpdateAuthorCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            Author author = _authorRepository.GetById(command.Id);
            author.UpdateName(command.Name);

            _authorRepository.Update(author);

            return new ResultCommand { Message = "Autor atualizado com sucesso!", Success = true, Data = author };
        }
    }
}