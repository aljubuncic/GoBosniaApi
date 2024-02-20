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
    public abstract class RatedTouristContentController<RatedTouristContentType, RatedTouristContentRequestDtoType, RatedTouristContentResponseDtoType>
        : TouristContentController<RatedTouristContentType, RatedTouristContentRequestDtoType, RatedTouristContentResponseDtoType>
        where RatedTouristContentType : RatedTouristContent
        where RatedTouristContentRequestDtoType : RatedTouristContentDtoRequest
        where RatedTouristContentResponseDtoType : RatedTouristContentDtoResponse
    {
        private readonly IRatedTouristContentService<RatedTouristContentType, RatedTouristContentRequestDtoType, RatedTouristContentResponseDtoType> _ratedTouristContentService;
        public RatedTouristContentController(IRatedTouristContentService<RatedTouristContentType, RatedTouristContentRequestDtoType, RatedTouristContentResponseDtoType> ratedTouristContentService, ISubcategoryService subcategoryService, IRatingService ratingService, string controllerRouteName) 
            : base(ratedTouristContentService, subcategoryService, ratingService, controllerRouteName)
        {
            _ratedTouristContentService = ratedTouristContentService;
        }

        [HttpGet("sort/average_rating/{sort_order}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<RatedTouristContentDtoResponse>>> GetSortedByAverageRating(string sort_order)
        {
            if(sort_order != null && !sort_order.Equals("asc") && !sort_order.Equals("desc"))
            {
                return BadRequest("Sort order can only be \'asc\', \'desc\' or it can be ommited - (asc is default)");
            }
            try
            {
                var ratedTouristContentResponseDtos = await _ratedTouristContentService.SortByAverageRating(sort_order);

                return Ok(ratedTouristContentResponseDtos);
            }
            catch(InternalServerErrorException ex)
            {
                return Problem
                    (statusCode: (int)ex.HttpStatusCode,
                    title: "Internal Server Error",
                    detail: ex.Message);
            }
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
