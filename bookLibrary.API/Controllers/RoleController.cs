using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.RolesCommands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace bookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleHandler _handler;

        public RoleController(IRoleRepository roleRepository, RoleHandler handler)
        {
            _roleRepository = roleRepository;
            _handler = handler;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<IResultCommand>> Post([FromBody] CreateRoleCommand command)
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
        [Route("")]
        public async Task<ActionResult<IResultCommand>> Put([FromBody] UpdatePriorityRoleCommand command)
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
        [Route("{id:Guid}")]
        public async Task<ActionResult<IResultCommand>> Delete(Guid id)
        {
            try
            {
                await _roleRepository.DeleteRole(id);
                
                return Ok(new 
                {
                    message = "Perfil excluído com sucesso.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro! Fale com o Administrador.", success = false, data = ex.Message });
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IResultCommand>> GetById([FromQuery] Guid id)
        {
            try
            {
                var role = await _roleRepository.GetRole(id);
                return new ResultCommand()
                {
                    Data = role,
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
        public async Task<ActionResult<IResultCommand>> GetAll()
        {
            try
            {
                var roles = await _roleRepository.GetAllRoles();
                return new ResultCommand()
                {
                    Data = roles,
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