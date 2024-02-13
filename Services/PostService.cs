using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;

namespace GoTravnikApi.Services
{
    public class PostService
        : TouristContentService<Post, PostDtoRequest, PostDtoResponse>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper) : base(postRepository, subcategoryRepository,mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<List<PostDtoResponse>> GetBySubcategory(string subcategoryName)
        {
            var postDtoResponses = _mapper.Map<List<PostDtoResponse>>(await _postRepository.GetBySubcategory(subcategoryName));
            return postDtoResponses;
        }
    }
}
