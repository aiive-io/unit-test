using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Aula04.UnitTest
{
    public class MenuServiceTests
    {

        [Fact]
        public void BuscarMenu_MetodoInvocado_LogEhAdicionado()
        {
            var stubMenuRepositorio = A.Fake<IMenuRepositorio>();

            var mockLogger = new FakeLogger();

            var menuService = new MenuService(mockLogger, stubMenuRepositorio);

            var user = new User
            {
                Id = Guid.NewGuid(),
                IsAdmin = true
            };

            menuService.BuscarMenu(user);

            A.CallTo(() => mockLogger.LogInformation("BuscarMenu chamado")).MustHaveHappened();            
        }

        [Fact]
        public void BuscarMenu_UsuarioDoTipoAdministrador_RetornaMenuCompleto()
        {            
            var mockMenuRepositorio = new FakeMenuRepositorio(); //Colaborador
            var stubLogger = new FakeLogger();

            var menuService = new MenuService(stubLogger, mockMenuRepositorio);

            //Colaborador
            var user = new User(); 
            user.IsAdmin = true;
            user.Id = Guid.NewGuid();

            var result = menuService.BuscarMenu(user);
            
            Assert.True(result.All(x => x.IsAdminOnly));

            result.All(x => x.IsAdminOnly).Should().BeTrue();
        }
    }


    public class FakeLogger : ILogger
    {
        public bool Logged { get; set; }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Logged = true;
        }
    }

    public class FakeMenuRepositorio : IMenuRepositorio
    {
        public IList<Menu> GetByUser(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public IList<Menu> GetAdminMenu()
        {
            return new List<Menu>()
            {
                new Menu () { Id = Guid.NewGuid(), IsAdminOnly = true}
            };
        }
    }
    

}
