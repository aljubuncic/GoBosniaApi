using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GoTravnikApi.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext _dataContext;
        public RatingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddRating(Rating rating)
        {
            _dataContext.Rating.Add(rating);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
