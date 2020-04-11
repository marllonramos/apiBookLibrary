using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.ReaderCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace bookLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly ReaderHandler _readerHandler;
        private readonly IReaderRepository _readerRepository;

        public ReaderController(ReaderHandler readerHandler, IReaderRepository readerRepository)
        {
            _readerHandler = readerHandler;
            _readerRepository = readerRepository;
        }

        [HttpPost]
        [Route("")]
        public async Task<IResultCommand> Post([FromBody]CreateReaderCommand command)
        {
            return await _readerHandler.Handler(command);
        }

        [HttpPut]
        [Route("")]
        public async Task<IResultCommand> Put([FromBody]UpdateReaderCommand command)
        {
            return await _readerHandler.Handler(command);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IResultCommand> Get(Guid id)
        {
            Reader reader = await _readerRepository.GetReader(id);

            return new ResultCommand { Message = "", Success = true, Data = reader };
        }

        [HttpDelete]
        [Route("")]
        public async Task<IResultCommand> Delete(Guid id)
        {
            await _readerRepository.DeleteReader(id);

            return new ResultCommand { Message = "Leitor excluído com sucesso!", Success = true, Data = null };
        }
    }
}
