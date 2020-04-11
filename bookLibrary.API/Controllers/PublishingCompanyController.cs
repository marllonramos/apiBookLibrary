using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.PublishingCompanyCommands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace bookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/publishingcompany")]
    public class PublishingCompanyController : ControllerBase
    {
        private readonly IPublishingCompanyRepository _repository;
        private readonly PublishingCompanyHandler _handler;

        public PublishingCompanyController
        (
            IPublishingCompanyRepository repository, 
            PublishingCompanyHandler handler
        )
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        public async Task<IResultCommand> Post
       (
          [FromBody] CreatePublishingCompanyCommand command
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
            [FromBody] UpdatePublishingCompanyCommand command
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
                    Message = "Editora excluída com sucesso.",
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
                var publishingCompanies = await _repository.GetAll();
                return new ResultCommand()
                {
                    Data = publishingCompanies,
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
                var publishingCompany = await _repository.GetById(id);
                return new ResultCommand()
                {
                    Data = publishingCompany,
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
