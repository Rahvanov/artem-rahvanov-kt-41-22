using Microsoft.Extensions.DependencyInjection;
using Rahvanov.Interfaces;  // Пространство имён, где находится IDepartmentService
using Rahvanov.Interfaces.TeacherInterface;
using Rahvanov.Services;    // Пространство имён, где находится DepartmentService

namespace Rahvanov.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, DepartmentService>();
        }
    }
}
