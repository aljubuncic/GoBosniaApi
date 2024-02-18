using GoTravnikApi.Data;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class SubcategoryRepository : Repository<Subcategory>,ISubcategoryRepository
    {
        private readonly DataContext _dataContext;

        public SubcategoryRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Subcategory?> GetSubcategory(string name)
        {
            try
            {
                var subcategory = await _dataContext.Subcategory.Where(x => x.Name == name).SingleOrDefaultAsync();
                return subcategory;
            }
            catch(Exception ex) 
            {
                throw new InternalServerErrorException("Internal server error exception");    
            }
        }

        public async Task<bool> SubcategoriesExist(List<string> subcategoryNames)
        {
            try
            {
                foreach(var subcategoryName in subcategoryNames)
                    if(! await _dataContext.Subcategory.AnyAsync(s => s.Name.Equals(subcategoryName)))
                        return false;
                return true;
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }
    }
}
