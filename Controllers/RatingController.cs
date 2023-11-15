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
        private readonly IMapper _mapper;

        public RatingController(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RatingDto>))]
        public async Task<ActionResult<List<RatingDto>>> GetRatings() 
        {
            var ratingDtos = _mapper.Map<List<RatingDto>>(await _ratingRepository.GetRatings());

            if(!ModelState.IsValid)
                return BadRequest(ModelState); 
            
            return Ok(ratingDtos);  
        }

    }
}
