using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Config;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}