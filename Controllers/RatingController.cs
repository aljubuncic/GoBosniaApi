using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Exceptions;

using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("approve/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> ApproveRating(int id)
        {
            try
            {
                await _ratingService.ApproveRating(id);
                return Ok("Succesfully approved");
            }
            catch(NotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
            catch(InternalServerErrorException ex)
            {
                return Problem
                    (statusCode: (int)ex.HttpStatusCode,
                    title: "Internal Server Error",
                    detail: ex.Message);
            }

        }

        /*
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
        */

    }
}
