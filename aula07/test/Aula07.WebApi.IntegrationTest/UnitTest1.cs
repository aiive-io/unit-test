using System;
using Xunit;
using static Aula07.WebApi.IntegrationTest.Startup;

namespace Aula07.WebApi.IntegrationTest
{
    [Collection(MyFixtureCollectionName.MyFixture)]
    public class UnitTest1
    {
        private readonly TesteDbContext _fixture;        

        private readonly IPessoaRepositorio _pessoaRepositorio;

        public UnitTest1(TesteDbContext fixture, IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [Fact]
        public void Test1()
        {
            Assert.IsType(typeof(FakePessoaRepository), _pessoaRepositorio);
        }
    }
}
