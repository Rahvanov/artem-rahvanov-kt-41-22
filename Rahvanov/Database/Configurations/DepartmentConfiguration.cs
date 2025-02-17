using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rahvanov.Database.Helpers;
using Rahvanov.Models;

namespace Rahvanov.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "sws_departments";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(d => d.DepartmentId)
                   .HasName("pk_departments");

            // Настройка свойств
            builder.Property(d => d.DepartmentId)
                   .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                   .HasColumnType(ColumnType.String)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasComment("Наименование кафедры");

            builder.Property(d => d.FoundationYear)
                   .HasColumnType(ColumnType.Date)
                   .IsRequired()
                   .HasComment("Год основания кафедры");

            // Уникальность для HeadTeacherId (обязательно перед Foreign Key!)
            builder.HasIndex(d => d.HeadTeacherId)
                   .IsUnique()
                   .HasDatabaseName("unique_head_teacher_id");  // Индекс уникальности

            // Связь с заведующим кафедрой
            builder.HasOne(d => d.HeadTeacher)
                   .WithOne()
                   .HasForeignKey<Department>(d => d.HeadTeacherId)
                   .HasConstraintName("fk_department_head_teacher")
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();



            builder.HasIndex(d => d.Name)
                   .HasName($"idx_departments_name");
        }
    }
}
