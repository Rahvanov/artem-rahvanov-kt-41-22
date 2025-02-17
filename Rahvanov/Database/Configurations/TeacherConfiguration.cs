using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rahvanov.Database.Helpers;
using Rahvanov.Models;

namespace Rahvanov.Database.Configurations
{
    public class TeachersConfiguration : IEntityTypeConfiguration<Teachers>
    {
        private const string TableName = "sws_teachers";

        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(t => t.TeacherId)
                   .HasName("pk_teachers");

            // Настройка свойств
            builder.Property(t => t.TeacherId)
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.FullName)
                   .HasColumnType(ColumnType.String)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasComment("ФИО преподавателя");

            // Связи с каскадным удалением и автозагрузкой
            builder.HasOne(t => t.AcademicDegree)  // Связь с таблицей AcademicDegree
                   .WithMany(a => a.Teachers)
                   .HasForeignKey(t => t.AcademicDegreeId)
                   .HasConstraintName("fk_teacher_academic_degree")
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();  // Автозагрузка этой связи

            builder.HasOne(t => t.Position)  // Связь с таблицей Position
                   .WithMany(p => p.Teachers)
                   .HasForeignKey(t => t.PositionId)
                   .HasConstraintName("fk_teacher_position")
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();  // Автозагрузка этой связи

            builder.HasOne(t => t.Department)  // Связь с таблицей Department
                   .WithMany(d => d.Teachers)
                   .HasForeignKey(t => t.DepartmentId)
                   .HasConstraintName("fk_teacher_department")
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();  // Автозагрузка этой связи


            // Индексы для внешних ключей
            builder.HasIndex(t => t.AcademicDegreeId)
                   .HasName($"idx_teachers_fk_f_academicdegree");

            builder.HasIndex(t => t.PositionId)
                   .HasName($"idx_teachers_fk_f_position");

            builder.HasIndex(t => t.DepartmentId)
                   .HasName($"idx_teachers_fk_f_department");


        }
    }
}
