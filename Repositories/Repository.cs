using GoTravnikApi.Data;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public abstract class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {   
            _dataContext = dataContext;
        }
        public async Task<List<Entity>> GetAll()
        {
            return await _dataContext.Set<Entity>().ToListAsync();
        }

        public Task<Entity?> GetById(int id)
        {
            return _dataContext.Set<Entity>().SingleOrDefaultAsync();
        }
        public async Task<int> Add(Entity entity)
        {
            try
            {
                await _dataContext.AddAsync(entity);
                
                await Save();

                var IdProperty = entity.GetType().GetProperty("Id").GetValue(entity, null);
                return (int)IdProperty;
            }
            catch(Exception)
            {
                throw new InternalServerErrorException("Error while adding an entity in the database");
            }
        }

        public async Task Delete(Entity entity)
        {
            try
            {
                _dataContext.Remove(entity);
                
                await Save();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Error while deleting an entity in the database");
            }
        }

        public async Task<int> Update(Entity entity)
        {
            try
            {
                _dataContext.Update(entity);

                await Save();

                var IdProperty = entity.GetType().GetProperty("Id").GetValue(entity, null);
                return (int)IdProperty;
            }
            catch(Exception)
            {
                throw new InternalServerErrorException("Error while updating an entity in the database");
            }
        }
        public async Task Save()
        {
            var saved  = await _dataContext.SaveChangesAsync();
            if (saved <= 0)
                throw new Exception("Changes to the database have not been saved");
        }
    }
}
