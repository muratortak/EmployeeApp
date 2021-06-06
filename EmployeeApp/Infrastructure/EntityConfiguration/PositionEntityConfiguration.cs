using EmployeeApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.EntityConfiguration
{
    public class PositionEntityConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");

            builder.HasKey(ci => ci.ID);

            builder.Property(ci => ci.ID)
                .IsRequired();

            builder.Property(cb => cb.PositionName)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
