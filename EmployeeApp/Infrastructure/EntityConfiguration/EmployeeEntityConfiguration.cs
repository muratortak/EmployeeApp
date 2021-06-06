using EmployeeApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.EntityConfiguration
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees")
                .HasOne(e => e.Position)
                .WithMany(e => e.Employee)
                .HasForeignKey(e => e.PositionID);

            builder.HasKey(e => e.ID);

            builder.Property(ci => ci.ID)
               .UseIdentityColumn(1)
               .IsRequired();

            builder.Property(cb => cb.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(cb => cb.LastName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
