using Aula06.PetClinic.Webapi.Controllers.V1;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Aula06.PetClinic.Webapi.UnitTests
{
    public class PetsControllerTests
    {
        [Fact]
        public async Task GetPet_WithNoPetsRegistered_ReturnsEmptyList()
        {            
            var controller = new PetsController(null);

        }
    }
}
