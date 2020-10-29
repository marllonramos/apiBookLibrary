using System.Threading.Tasks;
using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.ExemplaryCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;

namespace bookLibrary.Domain.Handlers
{
    public class ExemplaryHandler : Notifiable, 
    IHandler<CreateExemplaryCommand>, 
    IHandler<StartReadingCommand>, 
    IHandler<FinishReadingCommand>, 
    IHandler<PauseReadingCommand>
    {
        private readonly IExemplaryRepository _exemplaryRepository;
        
        public ExemplaryHandler(IExemplaryRepository exemplaryRepository)
        {
            _exemplaryRepository = exemplaryRepository;
        }

        public async Task<IResultCommand> Handler(CreateExemplaryCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            var exemplary = new Exemplary(command.IdBook, command.IdReader);

            await _exemplaryRepository.CreateExemplary(exemplary);

            return new ResultCommand { Message = "Exemplar cadastrado com sucesso!", Success = true, Data = exemplary };
        }

        public async Task<IResultCommand> Handler(StartReadingCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            var exemplary = await _exemplaryRepository.GetExemplary(command.Id);

            exemplary.StartReading();

            if(exemplary.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = exemplary.Notifications };

            await _exemplaryRepository.UpdateExemplary(exemplary);

            return new ResultCommand { Message = "Leitura iniciada com sucesso!", Success = true, Data = exemplary };
        }

        public async Task<IResultCommand> Handler(FinishReadingCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            var exemplary = await _exemplaryRepository.GetExemplary(command.Id);

            exemplary.FinishReading();

            if(exemplary.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = exemplary.Notifications };

            await _exemplaryRepository.UpdateExemplary(exemplary);

            return new ResultCommand { Message = "Leitura finalizada com sucesso!", Success = true, Data = exemplary };
        }

        public async Task<IResultCommand> Handler(PauseReadingCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            var exemplary = await _exemplaryRepository.GetExemplary(command.Id);

            exemplary.PauseReading();

            if(exemplary.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = exemplary.Notifications };

            await _exemplaryRepository.UpdateExemplary(exemplary);

            return new ResultCommand { Message = "Leitura pausada com sucesso!", Success = true, Data = exemplary };
        }
    }
}