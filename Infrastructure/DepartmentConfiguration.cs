using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infrastructure
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToCollection("department");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasElementName("Department_Name");

            builder.Property(e => e.Description)
                .IsRequired().HasMaxLength(200)
                .HasElementName("Department_Description");
        }
    }
}
