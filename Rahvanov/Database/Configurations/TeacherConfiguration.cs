using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rahvanov.Models;
namespace Rahvanov.Database.Configurations
{
        public class TeachersConfiguration : IEntityTypeConfiguration<Teachers>
        {
            public void Configure(EntityTypeBuilder<Teachers> builder)
            {
                builder.ToTable("teachers");
                builder.HasKey(t => t.TeacherId);

                builder.Property(t => t.FullName)
                       .HasMaxLength(200)
                       .IsRequired();

                // Связи
                builder.HasOne(t => t.AcademicDegree)
                       .WithMany(a => a.Teachers)
                       .HasForeignKey(t => t.AcademicDegreeId);

                builder.HasOne(t => t.Position)
                       .WithMany(p => p.Teachers)
                       .HasForeignKey(t => t.PositionId);

                builder.HasOne(t => t.Department)
                       .WithMany(d => d.Teachers)
                       .HasForeignKey(t => t.DepartmentId);
            }
        }
    }
