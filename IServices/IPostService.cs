using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IPostService : ITouristContentService<Post, PostDtoRequest, PostDtoResponse>   
    {
        public Task<List<PostDtoResponse>> GetBySubcategory(string subcategoryName);
    }
}
