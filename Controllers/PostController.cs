using GoTravnikApi.Dto;
using AutoMapper;



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoTravnikApi.Models;
using GoTravnikApi.IServices;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController 
        : TouristContentController<Post, PostDtoRequest,  PostDtoResponse>
    {
        private readonly IPostService _postService;
        private readonly ISubcategoryService _subcategoryService;

        public PostController(IPostService postService, ISubcategoryService subcategoryService, IRatingService ratingService) : base(postService, subcategoryService, ratingService)
        {
            _postService = postService;
            _subcategoryService = subcategoryService;
        }
    }
}

