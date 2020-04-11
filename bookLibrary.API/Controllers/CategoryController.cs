using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.CategoryCommands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace bookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryHandler _handler;
        private readonly ICategoryRepository _repository;
        public CategoryController
        (
            CategoryHandler handler,
            ICategoryRepository repository
        )
        {
            _handler = handler;
            _repository = repository;
        }


        [HttpPost]
        public async Task<IResultCommand> Post
        (
            [FromBody] CreateCategoryCommand command
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
            [FromBody] UpdateCategoryCommand command
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
                    Message = "Categoria excluída com sucesso.",
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
                var categories = await _repository.GetAll();
                return new ResultCommand()
                {
                    Data = categories,
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
                var category = await _repository.GetById(id);
                return new ResultCommand()
                {
                    Data = category,
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
