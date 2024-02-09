namespace GoTravnikApi.IRepositories
{
    public interface IRepository<Entity> where Entity : class
    {
        public Task<List<Entity>> GetAll();
        public Task<Entity?> GetById(int id);
        public Task<int> Add(Entity entity);
        public Task<int> Update(Entity entity);
        public Task Delete(Entity entity);
        public Task Save();
    }
}
