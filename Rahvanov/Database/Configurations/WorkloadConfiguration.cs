using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rahvanov.Database.Helpers;
using Rahvanov.Models;

namespace Rahvanov.Database.Configurations
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        private const string TableName = "sws_workloads";

        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(w => w.WorkloadId)
                   .HasName("pk_workloads");
            builder.Property(w => w.WorkloadId)
                   .ValueGeneratedOnAdd();

            // Связь с дисциплиной
            builder.HasOne(w => w.Discipline)
                   .WithMany(d => d.Workloads)
                   .HasForeignKey(w => w.DisciplineId)
                   .HasConstraintName("fk_workload_discipline")
                   .OnDelete(DeleteBehavior.Cascade);

            // Связь с преподавателем
            builder.HasOne(w => w.Teacher)
                   .WithMany(t => t.Workloads)
                   .HasForeignKey(w => w.TeacherId)
                   .HasConstraintName("fk_workload_teacher")
                   .OnDelete(DeleteBehavior.Cascade);

            // Настройка свойств
            builder.Property(w => w.Hours)
                   .HasColumnType(ColumnType.Int)
                   .IsRequired();

            // Индексы для внешних ключей
            builder.HasIndex(w => w.TeacherId)
                   .HasName($"idx_workloads_fk_f_teacher");

            builder.HasIndex(w => w.DisciplineId)
                   .HasName($"idx_workloads_fk_f_discipline");
        }
    }
}
