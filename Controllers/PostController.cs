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
        [ProducesResponseType(200, Type = typeof(List<PostDtoResponse>))]
        public async Task<ActionResult<List<PostDtoResponse>>> GetPosts()
        {
            var postDtos = _mapper.Map<List<PostDtoResponse>>(await _postRepository.GetPosts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(postDtos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(PostDtoResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PostDtoResponse>> GetPost(int id)
        {
            if (!await _postRepository.PostExists(id))
                return NotFound(ModelState);
            var postDto = _mapper.Map<PostDtoResponse>(await _postRepository.GetPost(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(postDto);
        }

        [HttpGet("{subcategoryName}")]
        [ProducesResponseType(200, Type = typeof(List<PostDtoResponse>))]
        public async Task<ActionResult<List<PostDtoResponse>>> GetPosts(string subcategoryName)
        {
            var postDtos = _mapper.Map<List<PostDtoResponse>>(await _postRepository.GetPosts(subcategoryName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(postDtos);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddPost([FromBody] PostDtoRequest postDtoRequest)
        {
            if (postDtoRequest == null)
                return BadRequest(ModelState);

            if(postDtoRequest.Location == null)
                return BadRequest(ModelState);

            if (!await _subcategoryRepository.SubcategoriesExist(postDtoRequest.Subcategories.Select(x => x.Name).ToList()))
            {
                ModelState.AddModelError("error", "Subcategory does not exist in the database");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (var subcategoryDto in postDtoRequest.Subcategories)
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(subcategoryDto.Name);
                subcategories.Add(subcategory);
            }

            Post post = _mapper.Map<Post>(postDtoRequest);
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

