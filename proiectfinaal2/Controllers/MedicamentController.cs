using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using proiectfinaal2.Entities.DTOs;
using proiectfinaal2.Entities;
using proiectfinaal2.Repositories.StapanRepository;
using System.Threading.Tasks;
using proiectfinaal2.Repositories.MedicamentRepository;

namespace proiectfinaal2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentController : ControllerBase
    {
        private readonly IMedicamentRepository _repository;
        public MedicamentController(IMedicamentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicamentById(int id)
        {
            var medicament = await _repository.GetByIdAsync(id);
            return Ok(new MedicamentDTO(medicament));
        }

        [HttpDelete("{denumire}")]
        public async Task<IActionResult> DeleteMedicamentByDenumire(string denumire)
        {
            var medicament = await _repository.GetByDenumire(denumire);
            if (medicament == null)
            {
                return NotFound("Medicament does not exists!");
            }
            _repository.Delete(medicament);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicament(CreateMedicamentDTO dto)
        {
            Medicament newmedicament = new Medicament();
            newmedicament.Denumire = dto.Denumire;
            newmedicament.Gramaj = dto.Gramaj;

            _repository.Create(newmedicament);

            await _repository.SaveAsync();
            return Ok(new MedicamentDTO(newmedicament));
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<Medicament> medicament)
        {
            if (medicament != null)
            {
                var medicamentForUpdate = await _repository.GetByIdAsync(id);
                medicament.ApplyTo(medicamentForUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _repository.SaveAsync();
                return Ok(new MedicamentDTO(medicamentForUpdate));
            }
            else
            {
                return BadRequest();
            }

        }
    }
}