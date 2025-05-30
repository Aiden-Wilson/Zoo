using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ZooApi.Data;
using ZooApi.Dto;
using ZooApi.DTO;
using ZooApi.Services;

namespace ZooApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly ZooContext _context;
        private readonly IAnimalService _animalService;
        public AnimalsController(IAnimalService animalService, ZooContext context)
        {
            _context = context;
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimalsAsync()
        {
            var animals = await _animalService.GetAllAsync();
            if (animals.Count == 0)
                return NotFound("Животные отсутствуют");
            return Ok(animals);
            
        }

        [HttpGet("{id}", Name = "GetAnimalById") ]
        public async Task<IActionResult> GetCurrentAnimalAsync(Guid id)
        {
            var animal = await _animalService.GetByIdAsync(id);
            if (animal is null)
                return NotFound("Животное не найдено");
            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimalAsync([FromBody] AnimalDto animalDto)
        {
            try
            {

                if (string.IsNullOrEmpty(animalDto.Name) || string.IsNullOrEmpty(animalDto.Species))
                {
                    return BadRequest("Имя и вид животного не могут быть пустыми");
                }
                else
                {
                    var animal = await _animalService.AddAsync(animalDto.Name, animalDto.Species);
                    return CreatedAtRoute("GetAnimalById", new { id = animal.Id }, animal);
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Данные введены не верно");
            }
        }

        [HttpPut("{id}/feed")]
        public async Task<IActionResult> FeedAsync(FeedDto feedDto, Guid id)
        {

            if (Int32.TryParse(feedDto.Amount, out int amount) == false)
                return BadRequest("Введите число");
            var isFed = await _animalService.FeedAnimalAsync(id, amount);
            if (isFed == false)
                return BadRequest("Животное не найдено");
            return Ok("Животное накормеленно");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _animalService.DeleteAsync(id);
            if (result == false) return NotFound("Животное не найдено");
            else return NoContent();
        }
    }
}

