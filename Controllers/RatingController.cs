using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ITouristContentRepository _touristContentRepository;
        private readonly IMapper _mapper;

        public RatingController(IRatingRepository ratingRepository, ITouristContentRepository touristContentRepository,IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _touristContentRepository = touristContentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RatingDtoResponse>))]
        public async Task<ActionResult<List<RatingDtoResponse>>> GetRatings() 
        {
            var ratingDtos = _mapper.Map<List<RatingDtoResponse>>(await _ratingRepository.GetRatings());

            foreach(var ratingDto in ratingDtos)
            {
                var touristContent = await _touristContentRepository.GetTouristContent(ratingDto.Id);
                if (touristContent is Accommodation)
                    ratingDto.TouristContent = _mapper.Map<AccommodationDtoResponse>(touristContent);
                else if (touristContent is FoodAndDrink)
                    ratingDto.TouristContent = _mapper.Map<FoodAndDrinkDtoResponse>(touristContent);
                else if (touristContent is Activity)
                    ratingDto.TouristContent = _mapper.Map<ActivityDtoResponse>(touristContent);
                else
                    continue;
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 
            
            return Ok(ratingDtos);  
        }

        [HttpPost("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> ApproveRating(int id)
        {
            if (!await _ratingRepository.RatingExists(id))
            {
                ModelState.AddModelError("error", "Rating does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rating = await _ratingRepository.GetRating(id);
            rating.Approved = true;

            if (!await _ratingRepository.UpdateRating(rating))
            {
                ModelState.AddModelError("error", "Database updating errror");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully approved");

        }

    }
}
