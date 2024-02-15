using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class TouristContentController<TouristContentType, TouristContentRequestDtoType, TouristContentResponseDtoType> : Controller
        where TouristContentType : TouristContent
        where TouristContentRequestDtoType : TouristContentDtoRequest
        where TouristContentResponseDtoType : TouristContentDtoResponse
    {
        private readonly ITouristContentService<TouristContentType, TouristContentRequestDtoType, TouristContentResponseDtoType> _touristContentService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IRatingService _ratingService;
        private readonly string touristContentTypeCamelCase;
        public TouristContentController(ITouristContentService<TouristContentType, TouristContentRequestDtoType, TouristContentResponseDtoType> touristContentService, ISubcategoryService subcategoryService, IRatingService ratingService)
        {
            _touristContentService = touristContentService;
            _subcategoryService = subcategoryService;
            _ratingService = ratingService;
            touristContentTypeCamelCase = $"{char.ToLower(nameof(TouristContentType)[0])}{nameof(TouristContentType)[1..]}";
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<TouristContentResponseDtoType>>> GetAll()
        {
            var touristContentResponseDtos = await _touristContentService.GetAll();

            return Ok(touristContentResponseDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TouristContentResponseDtoType>> GetById(int id)
        {
            try
            {
                var touristContentResponseDto = await _touristContentService.GetById(id);

                return Ok(touristContentResponseDto);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<TouristContentResponseDtoType>>> GetByName(string name)
        { 
            var touristContentResponseDtos = await _touristContentService.GetByName(name);

            return Ok(touristContentResponseDtos);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Add([FromBody] TouristContentRequestDtoType touristContentRequestDto)
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var touristContentId = await _touristContentService.Add(touristContentRequestDto);
                return Created($"{touristContentTypeCamelCase}/{touristContentId}", "Successfully added entity");
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
                var ratingId = await _touristContentService.AddRating(id, ratingDtoRequest);

                return Created($"rating/{ratingId}","Successfully added rating");
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
