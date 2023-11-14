using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly DataContext _dataContext;
        public SubcategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }
        public async Task<bool> SubcategoriesExist(List<string> subcategoryNames)
        {
            foreach(var subcategoryName in subcategoryNames)
                if(! await _dataContext.Subcategory.AnyAsync(s => s.Name.Equals(subcategoryName)))
                    return false;
            return true;
        }

       public async Task<bool> AddSubcategory(Subcategory subcategory)
       {
            await _dataContext.AddAsync(subcategory);
            return await Save();
       }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<Subcategory> GetSubcategory(string name)
        {
            return await _dataContext.Subcategory.Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
