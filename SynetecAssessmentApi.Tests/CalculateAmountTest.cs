using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;
using Moq;
using Xunit;
using SynetecAssessmentApi.BLL.Services;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Tests
{
	public class CalculateAmountTest
	{
		private readonly Mock<IEmployeeRepository> _employeeRepository;
		private readonly Mock<IDepartmentRepository> _departmentRepository;

		public CalculateAmountTest()
		{
			_employeeRepository = new Mock<IEmployeeRepository>();
			_departmentRepository = new Mock<IDepartmentRepository>();
		}

		[Fact]
		public async Task Should_Calculate_Async()
		{
			//Arrange
			_employeeRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
								.ReturnsAsync(GetTestEmployee());

			_employeeRepository.Setup(repo => repo.GetSalarySum())
								.ReturnsAsync(654750);

			var service = new BonusPoolService(_departmentRepository.Object, _employeeRepository.Object);

			int bonusAmount = 100;

			//Act
			var res = await service.CalculateAsync(bonusAmount, 1);

			//Assert
			Assert.NotNull(res);
			Assert.Equal(9, res.Amount);
		}

		private Employee GetTestEmployee()
		{
			return new Employee(1, "John Smith", "Accountant (Senior)", 60000, 1);
		}
	}
}
