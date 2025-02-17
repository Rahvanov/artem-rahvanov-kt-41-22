using Microsoft.EntityFrameworkCore;
using Rahvanov.Models;
using Rahvanov.Database.Configurations;

namespace Rahvanov.Database
{
    public class Teachers_DbContext: DbContext
    {
        // DbSet для каждой сущности
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Workload> Workloads { get; set; }

        // Метод конфигурации моделей
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Применяем конфигурацию для каждой модели (таблицы)
            modelBuilder.ApplyConfiguration(new TeachersConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());

            base.OnModelCreating(modelBuilder); // Важно вызвать базовый метод
        }
        // Конструктор, который принимает параметры для конфигурации подключения
        public Teachers_DbContext(DbContextOptions<Teachers_DbContext> options)
            : base(options)  // Передаем параметры в базовый класс DbContext
        {
        }
    }
}
