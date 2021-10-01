using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula03
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public bool IsAdminOnly { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class MenuRepositorio
    {
        private readonly DbContext _dbContext;

        public MenuRepositorio(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Menu> GetByUser(Guid idUsuario)
        {
            return _dbContext.Set<Menu>().Where(x => x.UserId == idUsuario).ToList();
        }

        public IList<Menu> GetByUserAdmin(Guid idUsuario)
        {
            return _dbContext.Set<Menu>().Where(x => x.UserId == idUsuario && x.IsAdminOnly).ToList();
        }
    }

    public class MenuService
    {
        private readonly MenuRepositorio _menuRepositorio;

        public MenuService(MenuRepositorio menuRepositorio)
        {
            _menuRepositorio = menuRepositorio;
        }

        public IList<Menu> BuscarMenu(User usuario)
        {
            if (usuario.IsAdmin) return _menuRepositorio.GetByUserAdmin(usuario.Id);

            else return _menuRepositorio.GetByUser(usuario.Id);
        }
    }
}
