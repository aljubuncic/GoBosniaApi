using GoTravnikApi.Dto;
using AutoMapper;

using GoTravnikApi.Interfaces;
using GoTravnikApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PostDto>))]
        public async Task<ActionResult<List<PostDto>>> GetPosts()
        {
            var postDtos = _mapper.Map<List<PostDto>>(await _postRepository.GetPosts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(postDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(AccommodationDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            if (!await _postRepository.PostExists(id))
                return NotFound(ModelState);
            var postDto = _mapper.Map<PostDto>(await _postRepository.GetPost(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(postDto);
        }

        [HttpGet("{subcategoryName}")]
        [ProducesResponseType(200, Type = typeof(List<PostDto>))]
        public async Task<ActionResult<List<PostDto>>> GetPosts(string subcategoryName)
        {
            var postDtos = _mapper.Map<List<PostDto>>(await _postRepository.GetPosts(subcategoryName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(postDtos);
        }

    }
}
