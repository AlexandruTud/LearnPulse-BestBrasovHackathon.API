using Hackathon_Best_API.Infrastructure;
using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Repositories;
using Hackathon_Best_API.Services;

namespace Hackathon_Best_API
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<IRegisterService, RegisterService>();
            return services;
        }

    }
}
