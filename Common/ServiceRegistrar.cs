using Common.Interfaces;
using Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class ServiceRegistrar
    {
        public static IServiceCollection RegisterCommonServices(this IServiceCollection services)
        {
            services.AddTransient<IPasswordService, PasswordService>();

            return services;
        }
    }
}
