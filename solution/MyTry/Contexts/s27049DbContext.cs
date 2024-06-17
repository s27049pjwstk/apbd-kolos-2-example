using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyTry.Models;

namespace MyTry.Contexts;

public class S27049DbContext : DbContext {
    protected S27049DbContext() {
    }

    public S27049DbContext(DbContextOptions options) : base(options) {
    }

    public DbSet<Client?> Clients { get; set; }
    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<Reservation?> Reservations { get; set; }
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(
            "Data Source=db-mssql;Initial Catalog=s27049;Integrated Security=True;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Client>(ent => {
            ent.HasKey(e => e.IdClient);
            ent.Property(e => e.Name).HasMaxLength(100);
            ent.Property(e => e.LastName).HasMaxLength(100);
            ent.Property(e => e.Pesel).HasMaxLength(100);
            ent.Property(e => e.Email).HasMaxLength(100);
        });

        modelBuilder.Entity<ClientCategory>(ent => {
            ent.HasKey(e => e.IdClientCategory);
            ent.Property(e => e.Name).HasMaxLength(100);
            ent.HasMany(e => e.Clients).WithOne(e => e.ClientCategory).HasForeignKey(e => e.IdClientCategory);
        });

        modelBuilder.Entity<Reservation>(ent => {
            ent.HasKey(e => e.IdReservation);
            ent.Property(e => e.CancelReason).HasMaxLength(200);
            ent.HasOne(e => e.Client).WithMany(e => e.Reservations).HasForeignKey(e => e.IdClient)
                .OnDelete(DeleteBehavior.NoAction);
            ent.HasMany(e => e.Sailboats).WithMany(e => e.Reservations);
            
        });

        modelBuilder.Entity<BoatStandard>(ent => {
            ent.HasKey(e => e.IdBoatStandard);
            ent.Property(e => e.Name).HasMaxLength(100);
            ent.HasMany(e => e.Reservations).WithOne(e => e.BoatStandard).HasForeignKey(e => e.IdBoatStandard);
        });

        modelBuilder.Entity<Sailboat>(ent => {
            ent.HasKey(e => e.IdSailboat);
            ent.Property(e => e.Name).HasMaxLength(100);
            ent.Property(e => e.Description).HasMaxLength(100);
            ent.HasOne(e => e.BoatStandard).WithMany(e => e.Sailboats).HasForeignKey(e => e.IdBoatStandard);
            ent.HasMany(e => e.Reservations).WithMany(e => e.Sailboats);
        });
    }
}