using GoTravnikApi.Dto;
using AutoMapper;



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoTravnikApi.Models;
using GoTravnikApi.IServices;

namespace GoTravnikApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController 
        : TouristContentController<Post, PostDtoRequest,  PostDtoResponse>
    {
        private readonly IPostService _postService;
        private readonly ISubcategoryService _subcategoryService;

        public PostController(IPostService postService, ISubcategoryService subcategoryService, IRatingService ratingService) 
            : base(postService, subcategoryService, ratingService, "posts")
        {
            _postService = postService;
            _subcategoryService = subcategoryService;
        }
    }
}

