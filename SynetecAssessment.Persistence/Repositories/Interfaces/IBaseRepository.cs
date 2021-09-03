using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetAll();
        
    }
}