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
            if (command.Invalid)
                return new ResultCommand { Message = "Erro na validação da editora.", Success = false, Data = command.Notifications };

            var publishingCompany = new PublishingCompany(command.Name);
            await _repository.Create(publishingCompany);

            return new ResultCommand { Message = "Sucesso ao cadastrar editora.", Success = true, Data = publishingCompany };
        }

        public async Task<IResultCommand> Handler(UpdatePublishingCompanyCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new ResultCommand { Message = "Erro na validação da editora.", Success = false, Data = command.Notifications };
            
            // TODO: 2 awaits our result?
            var publishingCompany = _repository.GetById(command.Id).Result;
            publishingCompany.Update(command.Name);
            await _repository.Update(publishingCompany);

            return new ResultCommand { Message = "Sucesso ao atualizar editora.", Success = true, Data = publishingCompany };
        }
    }
}
