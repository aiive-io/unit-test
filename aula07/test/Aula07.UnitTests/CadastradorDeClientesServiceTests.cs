using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula07.UnitTests
{
    public class CadastradorDeClientesServiceTests
    {
        //Comunicação -> Se um mock foi invocado quando o nosso método foi chamado. 
        [Fact]
        public void EnviarBoasVindas_InvocarMetodo_EnviaEmail()
        {
            var mockEmailService = A.Fake<IEmailService>();

            var service = new CadastradorDeClientesService(mockEmailService);

            service.EnviarBoasVindas("user@email.com");

            A.CallTo(() => mockEmailService.Enviar("user@email.com")).MustHaveHappenedOnceExactly();
            
        }
    }
}
