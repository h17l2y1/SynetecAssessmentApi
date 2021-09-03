using System.Collections.Generic;
using System.Threading.Tasks;
using SynetecAssessmentApi.BLL.Dtos;

namespace SynetecAssessmentApi.BLL.Services.Interfaces
{
    public interface IBonusPoolService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();

        Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId);
    }
}