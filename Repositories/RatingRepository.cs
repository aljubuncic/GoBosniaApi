using GoTravnikApi.Data;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        private readonly DataContext _dataContext;
        public RatingRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Rating>> GetUnapproved()
        {
            try
            {
                return await _dataContext.Rating
                    .Where(x => !x.Approved)
                    .Include(x => x.RatedTouristContent)
                    .ToListAsync();
            }
            catch(Exception)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }
    }
}
