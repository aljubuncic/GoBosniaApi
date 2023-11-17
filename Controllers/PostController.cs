using GoTravnikApi.Dto;
using AutoMapper;

using GoTravnikApi.Interfaces;
using GoTravnikApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoTravnikApi.Models;

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
        [ProducesResponseType(200, Type = typeof(PostDto))]
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
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddPost([FromBody] PostDto postDto)
        {
            if (postDto == null)
                return BadRequest(ModelState);

            if(postDto.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(postDto.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in postDto.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }

            Post post = _mapper.Map<Post>(postDto);
            post.Subcategories = subcategories;
            post.PostDate = DateTime.Now;

            if (!await _postRepository.AddPost(post))
            {
                ModelState.AddModelError("error", "Database saving error");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully added");

        }
    }
}

