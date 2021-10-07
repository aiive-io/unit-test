using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aula04.Aplicacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicosBancariosController : ControllerBase
    {
        private readonly IServicoBancarioService _servicoBancarioService;

        public ServicosBancariosController(IServicoBancarioService servicoBancarioService)
        {

        }
        private readonly ILogger<ServicosBancariosController> _logger;

        public ServicosBancariosController(ILogger<ServicosBancariosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(":id")]
        public IActionResult Debitar([FromRoute] string id, [FromQuery] decimal valor)
        {
            return Ok();
        }
    }
}
