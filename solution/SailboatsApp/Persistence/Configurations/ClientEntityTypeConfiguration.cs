using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations;

public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.IdClient);
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Pesel)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Email)
            .HasMaxLength(100)
            .IsRequired();

        // builder.HasOne(e => e.ClientCategory)
        //     .WithMany(e => e.Clients)
        //     .HasForeignKey(e => e.ClientCategory);
    }
}