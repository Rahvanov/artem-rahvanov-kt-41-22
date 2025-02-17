using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rahvanov.Database.Helpers;
using Rahvanov.Models;

namespace Rahvanov.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "sws_positions";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(p => p.PositionId)
                   .HasName("pk_positions");

            // Настройка свойств
            builder.Property(p => p.PositionId)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasColumnType(ColumnType.String)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasComment("Наименование должности");

            // Индексы
            builder.HasIndex(p => p.Name)
                   .HasName($"idx_positions_name");
        }
    }
}
