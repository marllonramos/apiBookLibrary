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

        public AuthorController(IAuthorRepository repository, AuthorHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        public async Task<ActionResult<IResultCommand>> Post([FromBody] CreateAuthorCommand command)
        {
            try
            {
                var result = await _handler.Handler(command);
                if (result != null)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<IResultCommand>> Put([FromBody] UpdateAuthorCommand command)
        {
            try
            {
                var result = await _handler.Handler(command);
                if (result != null)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Ocorreu um erro! Fale com o Administrador.", 
                    success = false, 
                    data = ex.Message
                });
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<IResultCommand>> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok(new 
                {
                    message = "Autor(a) excluído(a) com sucesso.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Ocorreu um erro! Fale com o Administrador.", 
                    success = false, 
                    data = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("all/{qtditems}/{page}")]
        public async Task<IResultCommand> GetAll(int qtdItems, int page)
        {
            try
            {
                var authors = await _repository.GetAll(qtdItems, page);
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
        [Route("")]
        public async Task<IResultCommand> GetById([FromQuery] Guid id)
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
