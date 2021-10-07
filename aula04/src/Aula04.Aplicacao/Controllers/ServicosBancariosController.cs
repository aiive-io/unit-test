using Aula04.Negocios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Aula04.Aplicacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicosBancariosController : ControllerBase
    {
        private readonly IContaBancariaService _contaBancariaService;
        private readonly ILogger<ServicosBancariosController> _logger;

        public ServicosBancariosController(
            IContaBancariaService contaBancariaService,
            ILogger<ServicosBancariosController> logger)
        {
            _contaBancariaService = contaBancariaService;
            _logger = logger;
        }

        [HttpGet(":id")]
        public IActionResult Debitar([FromRoute] string id, [FromQuery] decimal valor)
        {
            _contaBancariaService.Debitar(Guid.Parse(id), valor);

            return Ok();
        }
    }
}
