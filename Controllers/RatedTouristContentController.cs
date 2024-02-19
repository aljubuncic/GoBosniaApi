using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class RatedTouristContentController<TouristContentType, TouristContentRequestDtoType, TouristContentResponseDtoType>
        : TouristContentController<TouristContentType, TouristContentRequestDtoType, TouristContentResponseDtoType>
        where TouristContentType : RatedTouristContent
        where TouristContentRequestDtoType : RatedTouristContentDtoRequest
        where TouristContentResponseDtoType : RatedTouristContentDtoResponse
    {
        private readonly IRatedTouristContentService<TouristContentType, TouristContentRequestDtoType, TouristContentResponseDtoType> _ratedTouristContentService;
        public RatedTouristContentController(IRatedTouristContentService<TouristContentType, TouristContentRequestDtoType, TouristContentResponseDtoType> ratedTouristContentService, ISubcategoryService subcategoryService, IRatingService ratingService, string controllerRouteName) 
            : base(ratedTouristContentService, subcategoryService, ratingService, controllerRouteName)
        {
            _ratedTouristContentService = ratedTouristContentService;
        }

        [HttpPost("rating/{id:int}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> AddRating(int id, [FromBody] RatingDtoRequest ratingDtoRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var ratingId = await _ratedTouristContentService.AddRating(id, ratingDtoRequest);

                return Created($"rating/{ratingId}", "Successfully added rating");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return Problem
                    (statusCode: (int)ex.HttpStatusCode,
                    title: "Internal Server Error",
                    detail: ex.Message);
            }
        }
    }
}
