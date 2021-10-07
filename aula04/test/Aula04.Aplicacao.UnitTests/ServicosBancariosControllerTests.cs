using Aula04.Aplicacao.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Aula04.Aplicacao.UnitTests
{
    public class ServicosBancariosControllerTests
    {
        [Fact]
        public void Debitar_ComSaldo_RetornaOk()
        {
            //arrange
            var controller = new ServicosBancariosController(null, null);
            var context = new ActionContext();

            //act
            IActionResult result = controller.Debitar("", 10);

            //assert
            result.ExecuteResultAsync(context);
            context.HttpContext.Response.StatusCode.Should().Be(200);
        }
    }
}
