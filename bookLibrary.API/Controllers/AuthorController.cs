using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.AuthorCommands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace bookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        private readonly AuthorHandler _handler;

        public AuthorController
        (
            IAuthorRepository repository,
            AuthorHandler handler
        )
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        public async Task<IResultCommand> Post
        (
           [FromBody] CreateAuthorCommand command
        )
        {
            try
            {
                return await _handler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        [HttpPut]
        public async Task<IResultCommand> Put
        (
            [FromBody] UpdateAuthorCommand command
        )
        {
            try
            {
                return await _handler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }


        [HttpDelete]
        public async Task<IResultCommand> Delete
        (
            [FromBody] Guid id
        )
        {
            try
            {
                await _repository.Delete(id);
                return new ResultCommand()
                {
                    Message = "Autor(a) excluído(a) com sucesso.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResultCommand()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IResultCommand> GetAll()
        {
            try
            {
                var authors = await _repository.GetAll();
                return new ResultCommand()
                {
                    Data = authors,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResultCommand()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        [HttpGet]
        [Route("id")]
        public async Task<IResultCommand> GetById
        (
            [FromQuery] Guid id
        )
        {
            try
            {
                var author = await _repository.GetById(id);
                return new ResultCommand()
                {
                    Data = author,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResultCommand()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}
