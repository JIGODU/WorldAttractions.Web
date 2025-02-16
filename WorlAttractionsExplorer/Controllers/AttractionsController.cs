using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldAttractionsExplorer.DataAccess.Models;
using WorldAttractionsExplorer.Services.Contracts;

namespace WorldAttractionsExplorer.Controllers
{
    [Route("api/attractions")]
    [ApiController]
    public class AttractionsController(IAttractionService attractionService) : Controller
    {
        private readonly IAttractionService _attractionService = attractionService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attractions>>> GetAttractions()
        {
            return Ok(await _attractionService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attractions>> GetAttraction(int id)
        {
            var attraction = await _attractionService.GetByIdAsync(id);
            if (attraction == null) return NotFound();
            return attraction;
        }

        [HttpPost]
        public async Task<ActionResult<Attractions>> CreateAttraction(Attractions attraction)
        {
            var createdAttraction = await _attractionService.CreateAsync(attraction);
            return CreatedAtAction(nameof(GetAttraction), new { id = createdAttraction.AttractionId }, createdAttraction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttraction(int id, Attractions attraction)
        {
            var success = await _attractionService.UpdateAsync(id, attraction);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttraction(int id)
        {
            var success = await _attractionService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
