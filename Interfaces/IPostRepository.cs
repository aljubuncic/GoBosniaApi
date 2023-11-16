using GoTravnikApi.Models;

namespace GoTravnikApi.Interfaces
{
    public interface IPostRepository
    {
        public Task<List<Post>> GetPosts();
        public Task<Post> GetPost(int postId);
        public Task<bool> PostExists(int postId);
        public Task<List<Post>> GetPosts(string subcategoryName);
        public Task<bool> AddPost(Post post);
    }
}
