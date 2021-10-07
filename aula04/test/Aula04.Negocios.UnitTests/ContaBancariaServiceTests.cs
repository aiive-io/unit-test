using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula04.Negocios.UnitTests
{
    public class ContaBancariaServiceTests
    {
        [Fact]
        public void Debitar_ContaComSaldo_ValorDebitadoDaConta()
        {
            //arrange
            var contaBancariaService = new ContaBancariaService(null, null);

            //act

            //assert
        }
    }
}
