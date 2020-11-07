using System;
using System.Threading.Tasks;
using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.ExemplaryCommands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bookLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemplaryController : ControllerBase
    {
        private readonly IExemplaryRepository _exemplaryRepository;
        private readonly ExemplaryHandler _exemplaryHandler;

        public ExemplaryController(IExemplaryRepository exemplaryRepository, ExemplaryHandler exemplaryHandler)
        {
            _exemplaryRepository = exemplaryRepository;
            _exemplaryHandler = exemplaryHandler;
        }

        [HttpPost]
        [Route("")]
        public async Task<IResultCommand> Post([FromBody] CreateExemplaryCommand command)
        {
            try
            {
                return await _exemplaryHandler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Ocorreu um erro ao inserir o Exemplar", Success = false, Data = ex.Message };
            }
        }

        [HttpPut]
        [Route("start")]
        public async Task<IResultCommand> StartReading([FromBody] StartReadingCommand command)
        {
            try
            {
                return await _exemplaryHandler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Ocorreu um erro ao inserir o Exemplar", Success = false, Data = ex.Message };
            }
        }

        [HttpPut]
        [Route("pause")]
        public async Task<IResultCommand> PauseReading([FromBody]PauseReadingCommand command)
        {
            try
            {
                return await _exemplaryHandler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Ocorreu um erro ao inserir o Exemplar", Success = false, Data = ex.Message };
            }
        }

        [HttpPut]
        [Route("restart")]
        public async Task<IResultCommand> RestartReading([FromBody]RestartReadingCommand command)
        {
            try
            {
                return await _exemplaryHandler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Ocorreu um erro ao inserir o Exemplar", Success = false, Data = ex.Message };
            }
        }

        [HttpPut]
        [Route("finish")]
        public async Task<IResultCommand> FinishReading([FromBody]FinishReadingCommand command)
        {
            try
            {
                return await _exemplaryHandler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Ocorreu um erro ao inserir o Exemplar", Success = false, Data = ex.Message };
            }
        }

        [HttpPut]
        [Route("reading-in-queue")]
        public async Task<IResultCommand> ReadingInQueue([FromBody]PutInReadingQueueCommand command)
        {
            try
            {
                return await _exemplaryHandler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Ocorreu um erro ao inserir o Exemplar", Success = false, Data = ex.Message };
            }
        }
    }
}