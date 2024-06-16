using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations;

public class SailboatEntityTypeConfiguration : IEntityTypeConfiguration<Sailboat>
{
    public void Configure(EntityTypeBuilder<Sailboat> builder)
    {
        builder.HasKey(e => e.IdSailboat);
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(e => e.BoatStandard)
            .WithMany(e => e.Sailboats)
            .HasForeignKey(e => e.IdBoatStandard);
    }
}