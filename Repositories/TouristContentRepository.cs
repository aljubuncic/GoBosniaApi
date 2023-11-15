using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class TouristContentRepository : ITouristContentRepository
    {
        private readonly DataContext _dataContext;

        public TouristContentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<TouristContent> GetTouristContent(int ratingId)
        {
            var accommodation = await _dataContext.Accommodation
                .Where(accommodation => accommodation.Ratings.Any(r => r.Value == ratingId)).FirstOrDefaultAsync();
            if (accommodation != null)
                return accommodation;

            var foodAndDrink = await _dataContext.FoodAndDrink
                .Where(foodAndDrink => foodAndDrink.Ratings.Any(r => r.Value == ratingId)).FirstOrDefaultAsync();
            if (foodAndDrink != null)
                return foodAndDrink;

            var activity = await _dataContext.Activity
                .Where(activity => activity.Ratings.Any(r => r.Value == ratingId)).FirstOrDefaultAsync();
            if (activity != null) 
                return activity;

            return null;
        }
    }
}

