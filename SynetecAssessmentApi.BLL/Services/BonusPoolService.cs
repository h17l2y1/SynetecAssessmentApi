using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SynetecAssessmentApi.BLL.Constants;
using SynetecAssessmentApi.BLL.Dtos;
using SynetecAssessmentApi.BLL.Services.Interfaces;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;

namespace SynetecAssessmentApi.BLL.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public BonusPoolService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
        }
        
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAll();

            List<EmployeeDto> result = new List<EmployeeDto>();
        
            foreach (var employee in employees)
            {
                result.Add(new EmployeeDto
                    {
                        Fullname = employee.Fullname,
                        JobTitle = employee.JobTitle,
                        Salary = employee.Salary,
                        Department = new DepartmentDto
                        {
                            Title = employee.Department.Title,
                            Description = employee.Department.Description
                        }
                    });
            }
        
            return result;
        }
        
        public async Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId)
        {
            Employee employee = await _employeeRepository.GetById(selectedEmployeeId);

            if (employee == null)
            {
                throw new ApplicationException(ExceptionsConstants.ApplicationExceptions.Employee.NotFound);
            }

            //get the total salary budget for the company
            int totalSalary = await _employeeRepository.GetSalarySum();
            
            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employee.Salary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);
            
            return new BonusPoolCalculatorResultDto
            {
                Employee = new EmployeeDto
                {
                    Fullname = employee.Fullname,
                    JobTitle = employee.JobTitle,
                    Salary = employee.Salary,
                    Department = new DepartmentDto
                    {
                        Title = employee.Department.Title,
                        Description = employee.Department.Description
                    }
                },
            
                Amount = bonusAllocation
            };
        }
    }
}