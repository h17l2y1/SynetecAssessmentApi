using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Persistence.Repositories;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;

namespace SynetecAssessmentApi.Persistence.Config
{
    public static class ConfigurateDataBase
    {
        public static void InjectDataAccessDependency(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services);
            AddDependencies(services);
            Initialize(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "HrDb"));
        }
		
        private static void Initialize(IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
			DbContextGenerator.Initialize(serviceProvider);
		}

        private static void AddDependencies(IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        }
    }
}