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

        public override async Task<List<Entity>> GetAll()
        {
            try
            {
                return await GetEntitiesWithApprovedRatings(_dataContext.Set<Entity>().AsQueryable());
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException(ex.Message);
            }
        }

        public override async Task<Entity?> GetById(int id)
        {
            try
            {
                return (await GetEntitiesWithApprovedRatings(_dataContext.Set<Entity>().AsQueryable()))
                    .SingleOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        public override async Task<List<Entity>> FilterBySubcategories(List<string> subcategoryNames)
        {
            try
            {
                var query = _dataContext.Set<Entity>()
                    .Include(x => x.Subcategories)
                    .AsQueryable();
                foreach (var subcategory in subcategoryNames)
                    query = query.Where(x => x.Subcategories.Any(sub => sub.Name == subcategory) == true);

                return await GetEntitiesWithApprovedRatings(query); 
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        public override async Task<List<Entity>> GetByName(string name)
        {
            try
            {
                var query = _dataContext.Set<Entity>()
                    .Where(a => a.Name.ToLower().Contains(name.ToLower())).AsQueryable();

                return await GetEntitiesWithApprovedRatings(query);
                    
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        public override async Task<List<Entity>> SortByName(string sortOrder)
        {
            try
            {
                var query = _dataContext.Set<Entity>().AsQueryable();

                if (sortOrder == "asc" || sortOrder == "")
                    query = query.OrderBy(x => x.Name);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(x => x.Name);

                return await GetEntitiesWithApprovedRatings(query);
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        public async Task<List<Entity>> SortByAverageRating(string sortOrder)
        {
            try
            {
                var query = _dataContext.Set<Entity>()
                    .Include(x => x.Ratings.Where(r => r.Approved).ToList())
                    .AsQueryable();

                if (sortOrder == "asc" || sortOrder == "")
                    query = query.OrderBy(x => x.Ratings.Average(r => r.Value));
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(x => x.Ratings.Average(r => r.Value));

                return await GetEntitiesWithApprovedRatings(query);
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        private async Task<List<Entity>> GetEntitiesWithApprovedRatings(IQueryable<Entity> notFilteredRatingEntities)
        {
            return await notFilteredRatingEntities
            .Include(x => x.Location)
            .Include(x => x.Subcategories)
            .Select(x => new
            {
                Entity = x,
                ApprovedRatings = x.Ratings.Where(r => r.Approved).ToList()
            })
            .ToListAsync()
            .ContinueWith(task =>
            {
                var entitiesWithFilteredRatings = task.Result.Select(x =>
                {
                    x.Entity.Ratings = x.ApprovedRatings;
                    return x.Entity;
                }).ToList();
                return entitiesWithFilteredRatings;
            });
        }
    }
}
