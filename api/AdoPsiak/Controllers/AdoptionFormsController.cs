using AdoPsiak.Data;
using AdoPsiak.Dto;
using AdoPsiak.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdoPsiak.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdoptionFormsController : Controller
    {
        private readonly ILogger<AdoptionFormsController> _logger;
        private readonly DataContext _context;
        public AdoptionFormsController(ILogger<AdoptionFormsController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddForm([FromBody] NewAdoptionFormDto formDto)
        {
            var animal = await _context.Animals.FirstAsync(animal => animal.Id == formDto.SelectedAnimalId);

            var form = new AdoptionForm { 
                FirstName = formDto.FirstName,
                LastName = formDto.LastName,
                City = formDto.Address.City,
                SelectedAnimal = animal,
                EmailAddress = formDto.EmailAddress,
                AboutEnviroment = formDto.Answer.AboutEnviroment,
                PhoneNumber = formDto.Address.PhoneNumber,
                AboutExperienceWithAnimals = formDto.Answer.AboutExperienceWithAnimals,
                StreetName = formDto.Address.StreetName,
                AboutOtherAnimals = formDto.Answer.AboutOtherAnimals,
                Voivodeship = formDto.Address.Voivodeship,
                ZipCode = formDto.Address.ZipCode,
                ApartmentNumber = formDto.Address.ApartmentNumber,
                AboutResponsibility = formDto.Answer.AboutResponsibility,              
                SendingDate = DateTime.Now,
            };
            _context.AdoptionForms.Add(form);
            await _context.SaveChangesAsync();
            return Created($"/adoptionforms/{form.Id}", form.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForms()
        {
            var forms = await _context.AdoptionForms.ToListAsync();
            return Ok(forms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForm(int id)
        {
            var form = await _context.AdoptionForms.FindAsync(id);
            if (form == null)
                return NotFound();
            return Ok(form);
        }
    }
}
