namespace GoTravnikApi.IRepositories
{
    public interface IRepository<Entity> where Entity : class
    {
        public Task<List<Entity>> GetAll();
        public Task<Entity?> GetById(int id);
        public Task<bool> Add(Entity entity);
        public Task<bool> Update(Entity entity);
        public Task<bool> Delete(Entity entity);
        public Task<bool> Save();
    }
}
