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
    public class AccommodationController 
        : TouristContentController<Accommodation,AccommodationDtoRequest,AccommodationDtoResponse>
    {
        public IAccommodationService _accommodationService;
        public ISubcategoryService _subcategoryService;
        public IRatingService _ratingService;

        public AccommodationController(IAccommodationService accommodationService, ISubcategoryService subcategoryService, IRatingService ratingService) 
            : base(accommodationService, subcategoryService, ratingService)
        {
            _accommodationService = accommodationService;
            _subcategoryService = subcategoryService;
            _ratingService = ratingService;
        }

        [HttpGet("sort/{sortOption}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<AccommodationDtoResponse>>> GetSortedAccommodations(string sortOption)
        {
            var accommodationResponseDtos = await _accommodationService.Sort(sortOption);

            return Ok(accommodationResponseDtos);
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<AccommodationDtoResponse>>> GetFilteredAccommodations([FromQuery] List<string> subcategoryNames)
        {
            var accommodationResponseDtos = await _accommodationService.GetBySubcategories(subcategoryNames);

            return Ok(accommodationResponseDtos);
        }


    }
}
