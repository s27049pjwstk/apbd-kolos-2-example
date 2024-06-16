using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations;

public class ClientCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ClientCategory>
{
    public void Configure(EntityTypeBuilder<ClientCategory> builder)
    {
        builder.HasKey(e => e.IdCategory);
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(e => e.Clients)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.IdClientCategory);
    }
}