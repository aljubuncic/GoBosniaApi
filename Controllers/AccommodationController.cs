using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/accommodations")]
    [ApiController]
    public class AccommodationController 
        : RatedTouristContentController<Accommodation,AccommodationDtoRequest,AccommodationDtoResponse>
    {
        public IAccommodationService _accommodationService;
        public ISubcategoryService _subcategoryService;
        public IRatingService _ratingService;

        public AccommodationController(IAccommodationService accommodationService, ISubcategoryService subcategoryService, IRatingService ratingService) 
            : base(accommodationService, subcategoryService, ratingService,"accommodations")
        {
            _accommodationService = accommodationService;
            _subcategoryService = subcategoryService;
            _ratingService = ratingService;
        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<AccommodationDtoResponse>>> GetFilteredAccommodations([FromQuery] List<string> subcategory_names)
        {
            var accommodationResponseDtos = await _accommodationService.GetBySubcategories(subcategory_names);

            return Ok(accommodationResponseDtos);
        }


    }
}
