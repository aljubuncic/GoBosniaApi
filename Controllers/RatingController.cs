using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Dto.ResponseDto;
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

        [HttpGet("unapproved")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<RatingWithTouristContentDtoResponse>>> GetUnapproved()
        {
            try
            {
                var ratingWithTouristContentDtoResponses = await _ratingService.GetUnapproved();

                return Ok(ratingWithTouristContentDtoResponses);
            }
            catch (InternalServerErrorException ex)
            {
                return Problem
                    (statusCode: (int)ex.HttpStatusCode,
                    title: "Internal Server Error",
                    detail: ex.Message);
            }
        }


        [HttpPost("approve/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
    }
}
