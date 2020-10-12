using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.AuthorCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;
using System;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Handlers
{
    public class AuthorHandler : Notifiable, IHandler<CreateAuthorCommand>, IHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResultCommand> Handler(CreateAuthorCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            try
            {
                var author = new Author(command.Name);
                await _authorRepository.Create(author);

                return new ResultCommand { Message = "Autor cadastrado com sucesso!", Success = true, Data = author };
            }
            catch(Exception ex)
            {
                return new ResultCommand { Message = "Ocorreu um erro no servidor!", Success = true, Data = ex };
            }
        }

        public async Task<IResultCommand> Handler(UpdateAuthorCommand command)
        {
            command.Validate();
            ResultCommand result;
            if (command.Invalid)
            {
                result = new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };
            }
            else
            {
                // TODO: 2 awaits our result?
                var author = _authorRepository.GetById(command.Id).Result;
                author.UpdateName(command.Name);
                await _authorRepository.Update(author);
                result = new ResultCommand { Message = "Autor atualizado com sucesso!", Success = true, Data = author };
            }

            return result;
        }
    }
}