using GoTravnikApi.Data;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class RatedTouristContentRepository<Entity>
        : TouristContentRepository<Entity>, IRatedTouristContentRepository<Entity>
        where Entity : RatedTouristContent
    {
        private readonly DataContext _dataContext;
        public RatedTouristContentRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Entity>> SortByAverageRating(string sortOrder)
        {
            try
            {
                var query = _dataContext.Set<Entity>().AsQueryable();

                if (sortOrder == "asc" || sortOrder == "")
                    query = query.OrderBy(x => x.Ratings.Average(r => r.Value));
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(x => x.Ratings.Average(r => r.Value));

                return await query
                    .Include(x => x.Location)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }
    }
}
