using Microsoft.Extensions.DependencyInjection;
using Rahvanov.Interfaces;  
using Rahvanov.Interfaces.TeacherInterface;
namespace Rahvanov.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }
    }
}