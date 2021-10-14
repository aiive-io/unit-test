using Microsoft.EntityFrameworkCore;

namespace Aula06.PetClinic.Webapi.Data
{
    public class Aula06PetClinicWebapiContext : DbContext
    {
        public Aula06PetClinicWebapiContext (DbContextOptions<Aula06PetClinicWebapiContext> options)
            : base(options)
        {
        }

        public DbSet<Aula06.PetClinic.Webapi.Dominio.Pet> Pet { get; set; }
    }
}
