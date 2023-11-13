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
        public async Task<bool> SubcategoriesExist(List<Subcategory> subcategories)
        {
            foreach(var subcategory in subcategories)
                if(! await _dataContext.Subcategory.AnyAsync(s => s.Id == subcategory.Id))
                    return false;
            return true;
        }
    }
}
