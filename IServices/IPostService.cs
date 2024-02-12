using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IPostService : ITouristContentService<Post, PostDtoRequest, PostDtoResponse>   
    {
        public Task<List<PostDtoResponse>> GetBySubcategory(string subcategoryName);
    }
}
