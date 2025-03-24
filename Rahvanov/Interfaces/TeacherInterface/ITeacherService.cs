using Rahvanov.Models;
using Rahvanov.Filters.TeacherFilters;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rahvanov.Database;
using Microsoft.EntityFrameworkCore;


namespace Rahvanov.Interfaces.TeacherInterface
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teachers>> GetTeachersByDepartmentAsync(DepartmentFilter filter, CancellationToken cancellationToken);
        Task<IEnumerable<Teachers>> GetTeachersByFilterAsync(TeacherFilter filter, CancellationToken cancellationToken);


    }


    public class TeacherService : ITeacherService
    {
        private readonly Teachers_DbContext _dbContext;

        public TeacherService(Teachers_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Teachers>> GetTeachersByDepartmentAsync(DepartmentFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbContext.Teachers.Include(t => t.Department).AsQueryable();


            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(t => t.Department.Name.Contains(filter.Name));
            }

            return await query.ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Teachers>> GetTeachersByFilterAsync(TeacherFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbContext.Teachers
                .Include(t => t.AcademicDegree)
                .Include(t => t.Position)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.AcademicDegreeName))
            {
                query = query.Where(t => t.AcademicDegree.Name.Contains(filter.AcademicDegreeName));
            }

            if (!string.IsNullOrEmpty(filter.PositionName))
            {
                query = query.Where(t => t.Position.Name.Contains(filter.PositionName));
            }

            return await query.ToListAsync(cancellationToken);
        }


    }

}
