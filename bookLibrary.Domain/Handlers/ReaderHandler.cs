using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.ReaderCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Handlers
{
    public class ReaderHandler : Notifiable, IHandler<CreateReaderCommand>, IHandler<UpdateReaderCommand>
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderHandler(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public async Task<IResultCommand> Handler(CreateReaderCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            Reader reader = new Reader(command.Name, command.Email, command.Password);

            await _readerRepository.CreateReader(reader);

            return new ResultCommand { Message = "Leitor cadastrado com sucesso!", Success = true, Data = reader };
        }

        public async Task<IResultCommand> Handler(UpdateReaderCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            Reader reader = await _readerRepository.GetReader(command.Id);

            reader.UpdateName(command.Name);
            reader.UpdatePassword(command.Password);

            await _readerRepository.UpdateReader(reader);

            return new ResultCommand { Message = "Leitor atualizado com sucesso!", Success = true, Data = reader };
        }
    }
}
