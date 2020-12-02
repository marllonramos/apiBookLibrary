using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.PublishingCompanyCommands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        public PublishingCompanyController(IPublishingCompanyRepository repository, PublishingCompanyHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IResultCommand>> Post([FromBody] CreatePublishingCompanyCommand command)
        {
            try
            {
                ResultCommand result = (ResultCommand)await _handler.Handler(command);
                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IResultCommand>> Put([FromBody] UpdatePublishingCompanyCommand command)
        {
            try
            {
                ResultCommand result = (ResultCommand)await _handler.Handler(command);
                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IResultCommand>> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok(new { message = "Editora excluída com sucesso.", success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }

        [HttpGet]
        [Route("all/{qtdItems}/{page}")]
        [Authorize(Roles = "Leitor, Administrador")]
        public async Task<ActionResult<IResultCommand>> GetAll(int qtdItems, int page)
        {
            try
            {
                var publishingCompanies = await _repository.GetAll(qtdItems, page);
                if (publishingCompanies != null)
                    return Ok(new { success = true, data = publishingCompanies });

                return NotFound(new { message = "Nenhuma editora encontrada!", success = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Leitor, Administrador")]
        public async Task<ActionResult<IResultCommand>> GetByI([FromQuery] Guid id)
        {
            try
            {
                var publishingCompany = await _repository.GetById(id);
                if (publishingCompany != null)
                    return Ok(new { success = true, data = publishingCompany });

                return NotFound(new { message = "Nenhuma editora encontrada!", success = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }
    }
}
