using System.Threading.Tasks;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Persistence.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<int> GetSalarySum();
    }
}