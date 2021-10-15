using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula07.UnitTests
{
    public class PessoaTests
    {
        [Fact]
        public void Fake_PessoaPartial()
        {
            var pessoa = A.Fake<IPessoa>();
            
        }
    }
}
