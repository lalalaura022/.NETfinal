using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using proiectfinaal2.Entities.DTOs;
using proiectfinaal2.Entities;
using proiectfinaal2.Repositories.AnimalRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using proiectfinaal2.Repositories.StapanRepository;
using System.Xml.Linq;

namespace proiectfinaal2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StapanController : ControllerBase
    {
        private readonly IStapanRepository _repository;
        public StapanController(IStapanRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStapanById(int id)
        {
            var stapan = await _repository.GetByIdAsync(id);
            return Ok(new StapanDTO(stapan));
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteStapanByName(string name)
        {
            var stapan = await _repository.GetByName(name);
            if (stapan == null)
            {
                return NotFound("Stapan does not exists!");
            }
            _repository.Delete(stapan);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStapan(CreateStapanDTO dto)
        {
            Stapan newstapan = new Stapan();
            newstapan.Name = dto.Name;
            newstapan.Animal = dto.Animal;

            _repository.Create(newstapan);

            await _repository.SaveAsync();
            return Ok(new StapanDTO(newstapan));
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<Stapan> stapan)
        {
            if (stapan != null)
            {
                var stapanForUpdate = await _repository.GetByIdAsync(id);
                stapan.ApplyTo(stapanForUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _repository.SaveAsync();
                return Ok(new StapanDTO(stapanForUpdate));
            }
            else
            {
                return BadRequest();
            }

        }
    }
}