using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Infra.Data.Mappings
{
    public class DeliveryDriverMap : IEntityTypeConfiguration<DeliveryDriver>
    {
        public void Configure(EntityTypeBuilder<DeliveryDriver> builder)
        {
            builder.ToTable("delivery_drivers");

            builder.HasKey(m => m.Guid);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Cnpj)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(m => m.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(m => m.DriverLicenseNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(m => m.DriverLicenseType)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(m => m.DriverLicenseImagePath)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(m => m.Cnpj)
                .IsUnique();

            builder.HasIndex(m => m.DriverLicenseNumber)
                .IsUnique();

            builder.HasIndex(m => m.UserGuid).IsUnique();

            builder.Property(m => m.UserGuid).IsRequired();

        }
    }
}
