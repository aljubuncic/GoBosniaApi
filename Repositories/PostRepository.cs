using GoTravnikApi.Data;
using GoTravnikApi.Interfaces;
using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dataContext;


        public PostRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        

        public async Task<bool> AddPost(Post post)
        {
            await _dataContext.Location.AddAsync(post.Location);

            await _dataContext.Post.AddAsync(post);

            return await Save();
        }

        public async Task<bool> PostExists(int id)
        {
            return await _dataContext.Post.AnyAsync(fad => fad.Id == id);
        }

        public async Task<Post> GetPost(int id)
        {
            return await _dataContext.Post.Where(fad => fad.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _dataContext.Post.ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }

        public Task<List<Post>> GetPosts(string subcategoryName)
        {
            return _dataContext.Post
                .Where(x =>  x.Subcategories.Any(s => s.Name == subcategoryName) == true)
                .ToListAsync();
        }
    }

}
