using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.CategoryCommands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        public CategoryController(CategoryHandler handler, ICategoryRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }


        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IResultCommand>> Post([FromBody] CreateCategoryCommand command)
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IResultCommand>> Put([FromBody] UpdateCategoryCommand command)
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


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IResultCommand>> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok(new { message = "Categoria excluída com sucesso.", success = true });
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
                var categories = await _repository.GetAll(qtdItems, page);
                if (categories != null)
                    return Ok(new { Data = categories, Success = true });

                return NotFound(new { message = "Nenhuma categoria encontrada!", success = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Leitor, Administrador")]
        public async Task<ActionResult<IResultCommand>> GetById([FromQuery] Guid id)
        {
            try
            {
                var category = await _repository.GetById(id);
                if (category != null)
                    return Ok(new { data = category, success = true });

                return NotFound(new { message = "Nenhuma categoria encontrada!", success = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }
    }
}
