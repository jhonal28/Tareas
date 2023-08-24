using Microsoft.EntityFrameworkCore;
using Tareas.Domain.Entities;
using Tareas.Domain.Interfaces;
using Tareas.Infrastructure.SqlServer;

namespace Tareas.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _entity;

        public BaseRepository(SqlDbContext context)
        {
            _entity = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsNoTracking().AsEnumerable();
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entity.Remove(entity);
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }
    }
}
