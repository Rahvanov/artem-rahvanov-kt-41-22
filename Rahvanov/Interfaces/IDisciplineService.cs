using Rahvanov.Filters;
using Rahvanov.Models;
using Microsoft.EntityFrameworkCore;
using Rahvanov.Database;
using Rahvanov.Interfaces;

namespace Rahvanov.Interfaces
{
    public interface IDisciplineService
    {
        Task<IEnumerable<object>> GetDisciplinesWithFilterAsync(DisciplineFilter filter, CancellationToken cancellationToken);
    }

public class DisciplineService : IDisciplineService
{
    private readonly Teachers_DbContext _dbContext;

    public DisciplineService(Teachers_DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<object>> GetDisciplinesWithFilterAsync(DisciplineFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.Workloads
            .Include(w => w.Discipline)
            .Include(w => w.Teacher)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.TeacherName))
        {
            query = query.Where(w => w.Teacher.FullName.Contains(filter.TeacherName));
        }

        if (filter.MinHours.HasValue)
        {
            query = query.Where(w => w.Hours >= filter.MinHours.Value);
        }

        if (filter.MaxHours.HasValue)
        {
            query = query.Where(w => w.Hours <= filter.MaxHours.Value);
        }

        return await query.Select(w => w.Discipline).Distinct().ToListAsync(cancellationToken);
    }
}
}