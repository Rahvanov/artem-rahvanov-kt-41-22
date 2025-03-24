using Microsoft.AspNetCore.Mvc;
using Rahvanov.Interfaces.TeacherInterface;
using Rahvanov.Filters.TeacherFilters;
using System.Threading;
using System.Threading.Tasks;
using Rahvanov.Interfaces;

namespace Rahvanov.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentGetController : ControllerBase
    {
        private readonly ILogger<DepartmentGetController> _logger;
        private readonly ITeacherService _teacherService;
        private readonly IDepartmentService _departmentService;

        public DepartmentGetController(
     ILogger<DepartmentGetController> logger,
     ITeacherService teacherService,
     IDepartmentService departmentService)
        {
            _logger = logger;
            _teacherService = teacherService;
            _departmentService = departmentService;
        }



        [HttpPost(Name = "GetTeachersByDepartments")]
        public async Task<IActionResult> GetTeachersByDepartmentAsync(DepartmentFilter filter, CancellationToken cancellationToken)
        {
            var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter, cancellationToken);
            return Ok(teachers);
        }
        [HttpPost("filter-by-degree-position", Name = "GetTeachersByDegreeAndPosition")]
        public async Task<IActionResult> GetTeachersByFilterAsync(TeacherFilter filter, CancellationToken cancellationToken)
        {
            var teachers = await _teacherService.GetTeachersByFilterAsync(filter, cancellationToken);
            return Ok(teachers);
        }
        [HttpPost("filter-departments")]
        public async Task<IActionResult> GetDepartmentsWithFiltersAsync([FromBody] DepartmentFullFilter filter, CancellationToken cancellationToken)
        {
            var departments = await _departmentService.GetDepartmentsWithFiltersAsync(filter, cancellationToken);
            return Ok(departments);
        }


    }
}
