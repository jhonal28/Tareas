using Microsoft.EntityFrameworkCore;
using Tareas.Domain.Entities;
using Tareas.Domain.Interfaces;
using Tareas.Infrastructure.SqlServer;

namespace Tareas.Infrastructure.Repositories
{
    public class WorkRepository : BaseRepository<Work>, IWorkRepository
    {
        public WorkRepository(SqlDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Work>> GetByCategory(int idCategory)
        {
            return await _entity.Where(x => x.IdCategory == idCategory).ToListAsync();
        }
    }
}
