using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rahvanov.Models;
namespace Rahvanov.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");
            builder.HasKey(d => d.DepartmentId);

            builder.Property(d => d.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(d => d.FoundationYear)
                   .IsRequired();

            // Один-к-одному: заведующий кафедрой
            builder.HasOne(d => d.HeadTeacher)
                   .WithOne()
                   .HasForeignKey<Department>(d => d.HeadTeacherId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
