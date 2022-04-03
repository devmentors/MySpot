using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Infrastructure.DAL.Configurations;

internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new ReservationId(x));
        builder.Property(x => x.Capacity)
            .IsRequired()
            .HasConversion(x => x.Value, x => new(x));
        builder.Property(x => x.Date)
            .IsRequired()
            .HasConversion(x => x.Value, x => new Date(x));

        builder
            .HasDiscriminator<string>("Type")
            .HasValue<CleaningReservation>(nameof(CleaningReservation))
            .HasValue<VehicleReservation>(nameof(VehicleReservation));
    }
}