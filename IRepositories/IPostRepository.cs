using GoTravnikApi.Models;

namespace GoTravnikApi.IRepositories
{
    public interface IPostRepository : ITouristContentRepository<Post>
    {
        public Task<List<Post>> GetBySubcategory(string subcategoryName);
    }
}
