using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula07.WebApi.Models;

namespace Aula07.WebApi.Data
{
    public class Aula07WebApiContext : DbContext
    {
        public Aula07WebApiContext (DbContextOptions<Aula07WebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Aula07.WebApi.Models.Pessoa> Pessoa { get; set; }
    }
}
