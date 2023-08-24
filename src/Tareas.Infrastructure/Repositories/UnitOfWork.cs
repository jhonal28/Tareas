using Tareas.Domain.Entities;
using Tareas.Domain.Interfaces;
using Tareas.Infrastructure.SqlServer;

namespace Tareas.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDbContext _context;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IWorkRepository _workRepository;

        public UnitOfWork(SqlDbContext context)
        {
            _context = context;
        }

        public IRepository<Category> CategoryRepository => _categoryRepository ?? new BaseRepository<Category>(_context);

        public IWorkRepository WorkRepository => _workRepository ?? new WorkRepository(_context);        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
