using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations;

public class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(e => e.IdReservation);
        builder.Property(e => e.IdReservation)
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        builder.Property(e => e.CancelReason)
            .HasMaxLength(200);

        builder.HasOne(e => e.Client)
            .WithMany(e => e.Reservations)
            .HasForeignKey(e => e.IdClient);

        builder.HasMany(e => e.AssignedSailboats)
            .WithMany(e => e.Reservations);
    }
}