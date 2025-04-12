using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Infra.Data.Mappings
{
    public class MotorcycleMap : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("motorcycles");

            builder.HasKey(m => m.Guid);

            builder.HasIndex(m => m.LicensePlate)
                .IsUnique();

            builder.Property(m => m.LicensePlate)
                .IsRequired();

            builder.Property(m => m.LicensePlate)
                .HasMaxLength(10);

            builder.Property(m => m.Model)
                .IsRequired();

            builder.Property(m => m.Year)
                .IsRequired();
        }
    }
}
