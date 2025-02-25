using Rahvanov.Models;
using Rahvanov.Filters.TeacherFilters;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rahvanov.Database;

namespace Rahvanov.Interfaces.TeacherInterface
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teachers>> GetTeachersByDepartmentAsync(DepartmentFilter filter, CancellationToken cancellationToken);
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
    }

}
