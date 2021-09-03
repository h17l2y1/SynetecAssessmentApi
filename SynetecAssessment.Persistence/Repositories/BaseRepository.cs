using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain.Interfaces;
using SynetecAssessmentApi.Persistence.Config;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private AppDbContext _context { get; set; }

        protected DbSet<TEntity> _dbSet { get; set; }

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        
    }
}