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
                return await _dataContext.Set<Entity>()
                    .Include(x => x.Ratings.Where(r => r.Approved).ToList())
                    .Include(x => x.Location)
                    .Include(x => x.Subcategories)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        public override async Task<Entity?> GetById(int id)
        {
            try
            {
                return await _dataContext.Set<Entity>()
                    .Include(x => x.Ratings.Where(r => r.Approved).ToList())
                    .Include(x => x.Location)
                    .Include(x => x.Subcategories)
                    .SingleOrDefaultAsync();
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
                return await query
                    .Include(x => x.Ratings.Where(r => r.Approved).ToList())
                    .Include(x => x.Location)
                    .ToListAsync();
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
                return await _dataContext.Set<Entity>()
                    .Where(a => a.Name.ToLower().Contains(name.ToLower()))
                    .Include(x => x.Ratings.Where(r => r.Approved).ToList())
                    .Include(x => x.Location)
                    .Include(x => x.Subcategories)
                    .ToListAsync();
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

                return await query
                    .Include(x => x.Ratings.Where(r => r.Approved).ToList())
                    .Include(x => x.Location)
                    .Include(x => x.Subcategories)
                    .ToListAsync();
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

                return await query
                    .Include(x => x.Location)
                    .Include(x => x.Subcategories)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }
    }
}
