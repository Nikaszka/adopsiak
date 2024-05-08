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
    public class ContactFormsController: ControllerBase
    {
        private readonly ILogger<ContactFormsController> _logger;
        private readonly DataContext _context;
        public ContactFormsController(ILogger<ContactFormsController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddContactForm([FromBody] NewContactFormDto contactFormDto)
        {

            var form = new ContactForm
            {
                FirstName = contactFormDto.FirstName,
                LastName = contactFormDto.LastName,
                Topic = contactFormDto.Topic,
                EmailAddress = contactFormDto.EmailAddress,
                PhoneNumber = contactFormDto.PhoneNumber,
                MessageContent = contactFormDto.MessageContent,
                SendingDate = DateTime.Now,
            };
            _context.ContactForms.Add(form);
            await _context.SaveChangesAsync();
            return Created($"/contactforms/{form.Id}", form.Id);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllContactForms()
        {
            var forms = await _context.ContactForms.ToListAsync();
            return Ok(forms);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactForm(int id)
        {
            var form = await _context.ContactForms.FindAsync(id);
            if (form == null)
                return NotFound();
            return Ok(form);
        }
    }
}
