using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IRatingService : IService<Rating, RatingDtoRequest, RatingDtoResponse>
    {
        public Task ApproveRating(int id);
    }
}
