using Microsoft.Extensions.Configuration;
using SynetecAssessmentApi.BLL.Services;
using SynetecAssessmentApi.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Persistence.Config;

namespace SynetecAssessmentApi.BLL.Config
{
    public static class ConfigureBusinessLogic
    {
        public static void InjectBusinessLogicDependency(this IServiceCollection services, IConfiguration configuration)
        {
            AddDependencies(services);
            services.InjectDataAccessDependency(configuration);
        }

        private static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IBonusPoolService, BonusPoolService>();
        }
    }
    

}