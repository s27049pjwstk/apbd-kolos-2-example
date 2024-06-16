using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations;

public class BoatStandardEntityTypeConfiguration : IEntityTypeConfiguration<BoatStandard>
{
    public void Configure(EntityTypeBuilder<BoatStandard> builder)
    {
        builder.HasKey(e => e.IdBoatStandard);
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(e => e.Reservations)
            .WithOne(e => e.Standard)
            .HasForeignKey(e => e.IdBoatStandard)
            .OnDelete(DeleteBehavior.NoAction);
    }
}