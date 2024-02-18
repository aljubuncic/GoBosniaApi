using GoTravnikApi.Data;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public abstract class TouristContentRepository<Entity> : Repository<Entity>, ITouristContentRepository<Entity> where Entity : TouristContent
    {
        private readonly DataContext _dataContext;
        public TouristContentRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Entity>> FilterBySubcategories(List<string> subcategoryNames)
        {
            try
            {
                var query = _dataContext.Set<Entity>().AsQueryable();
                foreach (var subcategory in subcategoryNames)
                    query = query.Where(a => a.Subcategories.Any(sub => sub.Name == subcategory) == true);
                return await query
                    .Include(x => x.Location)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        public async Task<List<Entity>> GetByName(string name)
        {
            try
            {
                return await _dataContext.Set<Entity>()
                    .Where(a => a.Name.ToLower().Contains(name.ToLower()))
                    .Include(x => x.Location)
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        public async Task<List<Entity>> Sort(string sortOption)
        {
            try
            {
                var query = _dataContext.Set<Entity>().AsQueryable();

                if (sortOption == "alphabetical")
                    query = query.OrderBy(a => a.Name);

                return await query
                    .Include(a => a.Location)
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }
    }
}

