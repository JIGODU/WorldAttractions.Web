using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldAttractionsExplorer.DataAccess.Models;
using WorldAttractionsExplorer.Services.Contracts;

namespace WorldAttractionsExplorer.Controllers
{
    [Route("api/v1/attractions")]
    [ApiController]
    public class AttractionsController(IAttractionContract attractionService) : Controller
    {
        private readonly IAttractionContract _attractionService = attractionService;

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
            return Ok(attraction);
        }

        [Authorize(Policy = "GuideOrAbove")]
        [HttpPost]
        public async Task<ActionResult<Attractions>> CreateAttraction(Attractions attraction)
        {
            var createdAttraction = await _attractionService.CreateAsync(attraction);
            return CreatedAtAction(nameof(GetAttraction), new { id = createdAttraction.AttractionId }, createdAttraction);
        }

        [Authorize(Policy = "GuideOrAbove")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttraction(int id, Attractions attraction)
        {
            var success = await _attractionService.UpdateAsync(id, attraction);
            if (!success) return NotFound();
            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttraction(int id)
        {
            var success = await _attractionService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
