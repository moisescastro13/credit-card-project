using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace CreditCardApi.Infrastructure.Persistence;

public class ApplicationDbContext: DbContext
{
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<CreditCardDetails> CreditCardDetails { get; set; }
    public DbSet<CreditCardTransaction> CreditCardTransactions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseSqlServer();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.AddConfiguration();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        var entries = base.ChangeTracker.Entries()
            .Where(CheckEntityState()).ToList();

        entries.ForEach(entry => CheckEntityStatus(entry, entry.Entity));

        return base.SaveChangesAsync();
    }

    private static void CheckEntityStatus(EntityEntry entry, object entity)
    {
        var entityType = entity.GetType();
        if (entry.State == EntityState.Added)
        {
            var createdAtProperty = entityType.GetProperty("CreatedAt");
            createdAtProperty?.SetValue(entity, DateTime.UtcNow);
        }
        if (entry.State == EntityState.Modified)
        {
            var updatedAtProperty = entityType.GetProperty("UpdateAt");
            updatedAtProperty?.SetValue(entity, DateTime.UtcNow);
        }
    }

    private static Func<EntityEntry, bool> CheckEntityState()
    {
        return e => e.State is EntityState.Added
                    || e.State is EntityState.Modified;
    }
    
}
