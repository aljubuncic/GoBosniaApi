using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class PostRepository : TouristContentRepository<Post>, IPostRepository
    {
        private readonly DataContext dataContext;
        public PostRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<Post>> GetBySubcategory(string subcategoryName)
        {
            var posts = await dataContext.Post.Where(x => x.Subcategories.Any(s => s.Name == subcategoryName)).ToListAsync();
            return posts;
        }
    }

}
