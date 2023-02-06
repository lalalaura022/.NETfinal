using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using proiectfinaal2.Entities;
using proiectfinaal2.Entities.DTOs;
using proiectfinaal2.Repositories.AnimalRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiectfinaal2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repository;
        public AnimalController(IAnimalRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await _repository.AllAnimalsWithAddress();
            var animalsToReturn = new List<AnimalDTO>();

            foreach (var anim in animals)
            {
                animalsToReturn.Add(new AnimalDTO(anim));
            }

            return Ok(animalsToReturn);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _repository.GetByIdWithAddress(id);
            return Ok(new AnimalDTO(animal));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(int id)
        {
            var animal = await _repository.GetByIdAsync(id);
            if(animal == null)
            {
                return NotFound("Animal does not exists!");
            }
            _repository.Delete(animal);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal(CreateAnimalDTO dto)
        {
            Animal newanimal = new Animal();
            newanimal.Denumire = dto.Denumire;
            newanimal.Address = dto.Address;

            _repository.Create(newanimal);

            await _repository.SaveAsync();
            return Ok(new AnimalDTO(newanimal));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<Animal> animal)
        {
            if (animal != null)
            {
                var animalForUpdate = await _repository.GetByIdAsync(id);
                animal.ApplyTo(animalForUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _repository.SaveAsync();
                return Ok(new AnimalDTO(animalForUpdate));
            }
            else
            {
                return BadRequest();
            }

        }
       /* [HttpGet("AS")]
        public async Task<IActionResult> GetAllAnimalsWithNumberOfStapani()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict = await _repository.GetNumberOfStapani();

            return Ok(dict);
        }
       */

    }
}
