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
    public class MotorcycleNotificationMap : IEntityTypeConfiguration<MotorcycleNotification>
    {
        public void Configure(EntityTypeBuilder<MotorcycleNotification> builder)
        {
            builder.ToTable("motorcycle_notifications");

            builder.HasKey(n => n.Guid);

            builder.Property(n => n.MotorcycleGuid)
                .IsRequired();

            builder.Property(n => n.Model)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(n => n.Year)
                .IsRequired();

            builder.Property(n => n.Date)
                .IsRequired();
        }
    }
}
