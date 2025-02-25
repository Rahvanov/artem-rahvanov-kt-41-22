using Microsoft.AspNetCore.Mvc;
using Rahvanov.Interfaces.TeacherInterface;
using Rahvanov.Filters.TeacherFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Rahvanov.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentGetController : ControllerBase
    {
        private readonly ILogger<DepartmentGetController> _logger;
        private readonly ITeacherService _teacherService;

        public DepartmentGetController(ILogger<DepartmentGetController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost(Name = "GetTeachersByDepartments")]
        public async Task<IActionResult> GetTeachersByDepartmentAsync(DepartmentFilter filter, CancellationToken cancellationToken)
        {
            var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter, cancellationToken);
            return Ok(teachers);
        }
    }
}
