using System.Collections.Generic;
using System.Threading.Tasks;
using bookLibrary.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/autor")]
    public class AutorController : ControllerBase
    {
        public async Task<ActionResult<IEnumerable<AutorViewModel>>> Get()
        {
            return Ok();
        }
    }
}