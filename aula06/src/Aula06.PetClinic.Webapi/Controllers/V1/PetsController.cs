using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aula06.PetClinic.Webapi.Data;
using Aula06.PetClinic.Webapi.Dominio;

namespace Aula06.PetClinic.Webapi.Controllers.V1
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> ToListAsync();
        Task<Pet> FindAsync(int id);
    }

    public class PetRepository : IPetRepository
    {
        private readonly Aula06PetClinicWebapiContext _context;

        public PetRepository(Aula06PetClinicWebapiContext context)
        {
            _context = context;
        }

        public async Task<Pet> FindAsync(int id)
        {
            return await _context.Pet.FindAsync(id);
        }

        public async Task<IEnumerable<Pet>> ToListAsync()
        {
            return await _context.Pet.ToListAsync();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _repository;

        public PetsController(IPetRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<IEnumerable<Pet>> GetPet()
        {
            return await _repository.ToListAsync();
        }

        /*
        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _repository.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _repository.Entry(pet).State = EntityState.Modified;

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            _repository.Add(pet);
            await _repository.SaveChangesAsync();

            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _repository.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _repository.Remove(pet);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(int id)
        {
            return _repository.Any(e => e.Id == id);
        }
        */
    }
}
