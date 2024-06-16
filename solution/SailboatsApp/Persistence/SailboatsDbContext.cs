using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence;

public class SailboatsDbContext : DbContext
{
    public SailboatsDbContext()
    {
    }

    public SailboatsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=db-mssql;Initial Catalog=s27049;Integrated Security=True;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SailboatsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}