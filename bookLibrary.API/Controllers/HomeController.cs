using bookLibrary.Domain.Commands.ReaderCommands;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IReaderRepository _readerRepository;
        public HomeController(TokenService tokenService, IReaderRepository readerRepository)
        {
            _tokenService = tokenService;
            _readerRepository = readerRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] TokenReaderCommand entity)
        {
            var reader = await _readerRepository.GetReader(entity.Id);

            if (reader == null)
                return NotFound(new { message = "Usuário ou senha inválido." });

            var token = _tokenService.GenerateToken(reader);

            reader.UpdatePassword(string.Empty);

            return new
            {
                reader = reader,
                token = token
            };
        }
    }
}
