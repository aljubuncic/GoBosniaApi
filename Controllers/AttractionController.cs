using AutoMapper;
using GoTravnikApi.Dto;

using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : TouristContentController<Attraction, AttractionDtoRequest, AttractionDtoResponse>
    {
        private readonly IAttractionService _attractionService;
        private readonly ISubcategoryService _subcategoryService;

        public AttractionController(IAttractionService attractionService, ISubcategoryService subcategoryService, IRatingService ratingService) : base(attractionService, subcategoryService, ratingService)
        {
            _attractionService = attractionService;
            _subcategoryService = subcategoryService;
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<AttractionDtoResponse>>> GetFilteredAttractions([FromQuery] List<string> subcategoryNames)
        {

            var attractionDtoResponses = await _attractionService.GetBySubcategories(subcategoryNames);

            return Ok(attractionDtoResponses);
        }

    }
}
