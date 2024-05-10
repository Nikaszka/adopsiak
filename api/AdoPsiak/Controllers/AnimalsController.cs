using AdoPsiak.Data;
using AdoPsiak.Dto;
using AdoPsiak.Entities;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize]
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
                ChildFriendly = animalDto.ChildFriendly,
                CatFriendly = animalDto.CatFriendly,
                DogFriendly = animalDto.DogFriendly,
                LikesToPlay = animalDto.LikesToPlay,
                LikesToCuddle = animalDto.LikesToCuddle,
                DoesntLikeShelter = animalDto.DoesntLikeShelter,
                Description = animalDto.Description,
                Status = animalDto.Status,
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
        [HttpDelete("{id}/deletePhoto")]
        public async Task<IActionResult> DeleteAnimalPhoto(int id)
        {
            var animal = await _context.Animals.FindAsync(id);

            if (animal is null)
            {
                return NotFound("Animal not found");

            }
            
            var animalPhoto = await _context.AnimalPhotos.FindAsync(animal.AnimalPhotoId);
            
            if (animal.AnimalPhotoId is null || animalPhoto is null)
            {
                return NotFound("Animal Photo not found");
            }
            _context.AnimalPhotos.Remove(animalPhoto);
            animal.AnimalPhotoId = null;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals(int page, int pageSize, string? genus, string? gender)
        {
            var query = _context.Animals.AsQueryable();

            if (genus is not null)
            {
                if (genus == "dog")
                {
                    query = query.Where(a => a.Genus == Genus.Dog);
                }
                if (genus == "cat")
                {
                    query = query.Where(a => a.Genus == Genus.Cat);
                }
            }

            if (gender is not null)
            {
                if (gender == "male")
                {
                    query = query.Where(a => a.Gender == Gender.Male);
                }
                if (gender == "female")
                {
                    query = query.Where(a => a.Gender == Gender.Female);
                }
            }


            var animals = await query.OrderByDescending(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] UpdateAnimalDto updatedAnimal)
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
            dbAnimal.Genus = (Genus)updatedAnimal.Genus;
            dbAnimal.Gender = (Gender)updatedAnimal.Gender;
            dbAnimal.Status = (AnimalStatus)updatedAnimal.Status;
            dbAnimal.Description = updatedAnimal.Description;
            dbAnimal.CatFriendly = updatedAnimal.CatFriendly;
            dbAnimal.DogFriendly = updatedAnimal.DogFriendly;
            dbAnimal.ChildFriendly = updatedAnimal.ChildFriendly;
            dbAnimal.LikesToCuddle = updatedAnimal.LikesToCuddle;
            dbAnimal.LikesToPlay = updatedAnimal.LikesToPlay;
            dbAnimal.DoesntLikeShelter = updatedAnimal.DoesntLikeShelter;


            await _context.SaveChangesAsync();

            return Ok(updatedAnimal);
        }

    }
}
