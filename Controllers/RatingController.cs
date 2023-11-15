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
        [ProducesResponseType(200, Type = typeof(List<RatingDto>))]
        public async Task<ActionResult<List<RatingDto>>> GetRatings() 
        {
            var ratingDtos = _mapper.Map<List<RatingDto>>(await _ratingRepository.GetRatings());

            foreach(var ratingDto in ratingDtos)
            {
                var touristContent = await _touristContentRepository.GetTouristContent(ratingDto.Id);
                if (touristContent is Accommodation)
                    ratingDto.TouristContent = _mapper.Map<AccommodationDto>(touristContent);
                else if (touristContent is FoodAndDrink)
                    ratingDto.TouristContent = _mapper.Map<FoodAndDrinkDto>(touristContent);
                else if (touristContent is Activity)
                    ratingDto.TouristContent = _mapper.Map<ActivityDto>(touristContent);
                else
                    continue;
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 
            
            return Ok(ratingDtos);  
        }

    }
}
