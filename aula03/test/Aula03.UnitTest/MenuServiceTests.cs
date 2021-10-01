using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula03.UnitTest
{
    public class MenuServiceTests
    {
        [Fact]
        public void BuscarMenu_UsuarioDoTipoAdministrador_RetornaMenuCompleto()
        {            
            var fakeMenuRepositorio = new FakeMenuRepositorio(); //Colaborador

            var menuService = new MenuService(fakeMenuRepositorio);

            //Colaborador
            var user = new User(); 
            user.IsAdmin = true;
            user.Id = Guid.NewGuid();

            var result = menuService.BuscarMenu(user);

            result.All(x => x.IsAdminOnly).Should().BeTrue();
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
