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
    public class MonetarySupportController : ControllerBase
    {
        private readonly ILogger<MonetarySupportController> _logger;
        private readonly DataContext _context;
        public MonetarySupportController(ILogger<MonetarySupportController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMonetarySupport([FromBody] MonetarySupportDto monetarySupportDto)
        {
            var support = new MonetarySupport
            {
                Name = monetarySupportDto.Name,
                Value = monetarySupportDto.Value,
                Date = DateTime.Now,
            };

            _context.MonetarySupportEntries.Add(support);
            await _context.SaveChangesAsync();
            return Created($"/monetarysupport/{support.Id}", support.Id);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllMonetarySupport()
        {
            var support = await _context.MonetarySupportEntries.ToListAsync();
            return Ok(support);
        }

        [HttpGet("sum")]
        public async Task<IActionResult> GetSumMonetarySupport()
        {
            var sumSupport = await _context.MonetarySupportEntries.SumAsync(m => m.Value);

            return Ok(sumSupport);
        }
    }
}
