using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Core.Entities;

namespace MySpot.Infrastructure.DAL.Configurations;

internal sealed class CleaningReservationConfiguration : IEntityTypeConfiguration<CleaningReservation>
{
    public void Configure(EntityTypeBuilder<CleaningReservation> builder)
    {
    }
}