using EfClassicBugRepro.Models;
using Npgsql;
using System.Data.Entity;

namespace EfClassicBugRepro.Data;

[DbConfigurationType(typeof(PostgresConfiguration))]
public class AppDbContext : DbContext
{
    public AppDbContext()
        : base(new NpgsqlConnection(
            "Host=localhost;Port=5433;Database=BoolAddingBugRepro;Username=postgres;Password=1;Include Error Detail=true;"),
            true)
    {
    }

    public DbSet<BugRecord> BugRecords { get; set; } = null!;

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BugRecord>()
            .ToTable("BugRecords")
            .HasKey(record => record.Id);

        modelBuilder.Entity<BugRecord>()
            .Property(record => record.Value)
            .IsRequired()
            .HasMaxLength(200);

        base.OnModelCreating(modelBuilder);
    }
}
