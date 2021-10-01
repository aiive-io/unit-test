using NUnit.Framework;

namespace Aula02.NUnit.UnitTest
{
    [TestFixture]
    public class ProdutoTests
    {
        private Produto _produto;

        [SetUp]
        public void Setup()
        {
            _produto = new Produto();
        }

        [TearDown]
        public void TeardDown()
        {
            _produto = null;
        }

        [Test]
        public void EstaValido_ProdutoComDataValidadeMaiorQueHoje_RetornaVerdadeiro()
        {
            //_produto 1 
        }

        [Test]
        public void Produto_Dentro_Do_Prazo_De_Validade_Eh_Valido()
        {
            // _produto 2
        }
    }
}