using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.PublishingCompanyCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Handlers
{
    public class PublishingCompanyHandler : 
        Notifiable,
        IHandler<CreatePublishingCompanyCommand>,
        IHandler<UpdatePublishingCompanyCommand>
    {
        private readonly IPublishingCompanyRepository _repository;
        public PublishingCompanyHandler(IPublishingCompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResultCommand> Handler(CreatePublishingCompanyCommand command)
        {
            command.Validate();
            ResultCommand result;
            if (command.Invalid)
            {
                result = new ResultCommand { Message = "Erro ao cadastrar editora.", Success = false, Data = command.Notifications };
            }
            else
            {
                var publishingCompany = new PublishingCompany(command.Name);
                await _repository.Create(publishingCompany);
                result = new ResultCommand { Message = "Sucesso ao cadastrar editora.", Success = true, Data = publishingCompany };
            }

            return result;
        }

        public async Task<IResultCommand> Handler(UpdatePublishingCompanyCommand command)
        {
            command.Validate();
            ResultCommand result;
            if(command.Invalid)
            {
                result = new ResultCommand() { Message = "Erro ao atualizar editora.", Success = true, Data = command.Notifications };
            }
            else
            {
                // TODO: 2 awaits our result?
                var publishingCompany = _repository.GetById(command.Id).Result;
                publishingCompany.Update(command.Name);
                await _repository.Update(publishingCompany);
                result = new ResultCommand() { Message = "Sucesso ao atualizar editora.", Success = true, Data = publishingCompany };
            }

            return result;
        }
    }
}
