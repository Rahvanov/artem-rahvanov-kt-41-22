using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rahvanov.Database.Helpers;
using Rahvanov.Models;

namespace Rahvanov.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "sws_academic_degrees";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(a => a.AcademicDegreeId)
                   .HasName("pk_academic_degrees");

            // Настройка свойств
            builder.Property(a => a.AcademicDegreeId)
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                   .HasColumnType(ColumnType.String)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasComment("Наименование учёной степени");

            // Индексы
            builder.HasIndex(a => a.Name)
                   .HasName($"idx_academic_degrees_name");
        }
    }
}
