using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Infra.Data.Mappings
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("rentals");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(r => r.StartDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(r => r.ExpectedEndDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(r => r.ActualEndDate)
                .HasColumnType("date");

            builder.Property(r => r.PlanDays)
                .IsRequired();

            builder.Property(r => r.DailyRate)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(r => r.TotalAmount)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(r => r.DeliveryDriver)
                .WithMany(d => d.Rentals)
                .HasForeignKey(r => r.DeliveryDriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Motorcycle)
                .WithMany(m => m.Rentals)
                .HasForeignKey(r => r.MotorcycleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
