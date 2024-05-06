using AdoPsiak.Data;
using AdoPsiak.Dto;
using AdoPsiak.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace AdoPsiak.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {

        private static readonly string[] Breeds = new[]
        {
            "Boxer", "Owczarek niemiecki", "York", "Jamnik", "Husky", "Blablador", "Mops", "Corgi", "Szpic miniaturowy", "Cziłała"
        };

        private readonly ILogger<AnimalsController> _logger;
        private readonly DataContext _context;

        public AnimalsController(ILogger<AnimalsController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAnimal([FromBody] NewAnimalDto animalDto)
        {
            var animal = new Animal
            {
                Name = animalDto.Name,
                Age = animalDto.Age,
                Breed = animalDto.Breed,
                Localization = animalDto.Localization,
                Genus = animalDto.Genus,
                Gender = animalDto.Gender,
            };
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return Created($"/animals/{animal.Id}", animal.Id);
        }

        [HttpPost("{id}/addPhoto")]
        public async Task<IActionResult> AddAnimalPhoto(int id, [FromForm] AddPhotoDto addPhotoDto)
        {
            var contentType = addPhotoDto.Photo.ContentType;
            if (contentType != MediaTypeNames.Image.Jpeg
                && contentType != MediaTypeNames.Image.Png)
            {
                return BadRequest("API supports only Jpeg and Png photos");
            }

            var animal = await _context.Animals.FindAsync(id);

            if (animal is null)
            {
                return BadRequest();
            }

            var photoStream = addPhotoDto.Photo.OpenReadStream();

            using var memoryStream = new MemoryStream();
            await photoStream.CopyToAsync(memoryStream);

            var animalPhoto = new AnimalPhoto
            {
                Animal = animal,
                ContentType = contentType,
                ImageContent = Convert.ToBase64String(memoryStream.ToArray())
            };

            await _context.AnimalPhotos.AddAsync(animalPhoto);
            await _context.SaveChangesAsync();

            return Accepted();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await _context.Animals.ToListAsync();
            return Ok(animals);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimal(int id)
        {
            var animal = await _context.Animals
                .Include(a => a.AdoptionForms)
                .FirstOrDefaultAsync(a => a.Id == id);


            if (animal is null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _context.Animals.FindAsync(id);

            if (animal is null)
            {
                return NotFound("Animal not found");
            }
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
        {
            var dbAnimal = await _context.Animals.FindAsync(id);
            if (dbAnimal is null)
            {
                return NotFound("Animal not found.");
            }
;
            dbAnimal.Name = updatedAnimal.Name;
            dbAnimal.Age = updatedAnimal.Age;
            dbAnimal.Breed = updatedAnimal.Breed;
            dbAnimal.Localization = updatedAnimal.Localization;
            dbAnimal.Genus = updatedAnimal.Genus;
            dbAnimal.Gender = updatedAnimal.Gender;
            dbAnimal.Status = updatedAnimal.Status;

            await _context.SaveChangesAsync();

            return Ok(updatedAnimal);
        }

    }
}
