using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rahvanov.Database.Helpers;
using Rahvanov.Models;

namespace Rahvanov.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "sws_disciplines";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(d => d.DisciplineId)
                   .HasName("pk_disciplines");

            // Настройка свойств
            builder.Property(d => d.DisciplineId)
                   .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                   .HasColumnType(ColumnType.String)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasComment("Наименование дисциплины");

            // Индексы
            builder.HasIndex(d => d.Name)
                   .HasName($"idx_disciplines_name");
        }
    }
}
