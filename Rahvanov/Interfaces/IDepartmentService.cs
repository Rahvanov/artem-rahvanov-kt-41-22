using Rahvanov.Database;
using Rahvanov.Filters.TeacherFilters;
using Rahvanov.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rahvanov.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<object>> GetDepartmentsWithFiltersAsync(DepartmentFullFilter filter, CancellationToken cancellationToken);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly Teachers_DbContext _dbContext;

        public DepartmentService(Teachers_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<object>> GetDepartmentsWithFiltersAsync(DepartmentFullFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbContext.Departments
                .Include(d => d.HeadTeacher)
                .Include(d => d.Teachers)
                .AsQueryable();

            if (filter.FoundedAfter.HasValue)
            {
                query = query.Where(d => d.FoundationYear >= filter.FoundedAfter.Value);
            }

            if (filter.FoundedBefore.HasValue)
            {
                query = query.Where(d => d.FoundationYear <= filter.FoundedBefore.Value);
            }

            if (filter.MinTeachersCount.HasValue)
            {
                query = query.Where(d => d.Teachers.Count() >= filter.MinTeachersCount.Value);
            }

            if (filter.MaxTeachersCount.HasValue)
            {
                query = query.Where(d => d.Teachers.Count() <= filter.MaxTeachersCount.Value);
            }

            var result = await query.Select(d => new
            {
                d.DepartmentId,
                d.Name,
                d.FoundationYear,
                TeachersCount = d.Teachers.Count,
                Head = new
                {
                    d.HeadTeacher.TeacherId,
                    d.HeadTeacher.FullName
                }
            }).ToListAsync(cancellationToken);

            return result;
        }
    }

}
