using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Runtime.CompilerServices;

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

        public async Task<List<Rating>> GetRatings()
        {
            return await _dataContext.Rating.ToListAsync();
        }
        public async Task<bool> UpdateRating(Rating rating)
        {
            _dataContext.Rating.Update(rating);
            return await Save();
        }

        public async Task<Rating> GetRating(int id)
        {
            return await _dataContext.Rating.FirstAsync(r => r.Id == id);
        }
        public async Task<bool> RatingExists(int id)
        {
            return await _dataContext.Rating.AnyAsync(r => r.Id == id); 
        }
        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
