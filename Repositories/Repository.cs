using GoTravnikApi.Data;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using Microsoft.Data.SqlClient;
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
            try
            {
                return await _dataContext.Set<Entity>().ToListAsync();
            }
            catch(Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }

        public Task<Entity?> GetById(int id)
        {
            try
            {
                return _dataContext.Set<Entity>().SingleOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
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
            catch(DbUpdateException)
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
            catch (DbUpdateException)
            {
                throw new InternalServerErrorException("Error while deleting an entity in the database");
            }
            catch(Exception ex)
            {
                throw new InternalServerErrorException(ex.Message);
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
            catch(DbUpdateException)
            {
                throw new InternalServerErrorException("Error while updating an entity in the database");
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException("Internal server error occured");
            }
        }
        public async Task Save()
        {
            var saved  = await _dataContext.SaveChangesAsync();
            if (saved <= 0)
                throw new DbUpdateException("Changes to the database have not been saved");
        }
    }
}
