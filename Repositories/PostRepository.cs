using GoTravnikApi.Data;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class PostRepository : TouristContentRepository<Post>, IPostRepository
    {
        private readonly DataContext _dataContext;
        public PostRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetBySubcategory(string subcategoryName)
        {
            var posts = await _dataContext.Post.Where(x => x.Subcategories.Any(s => s.Name == subcategoryName)).ToListAsync();
            return posts;
        }
    }

}
