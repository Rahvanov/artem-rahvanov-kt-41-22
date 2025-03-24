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
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<IWorkloadService, WorkloadService>();


            return services;
        }
    }
}