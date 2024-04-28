using System.Reflection;
using EDA.Consumer.Demo.Application.Common.Interfaces;
using EDA.Consumer.Demo.Domain.Checks;
using Microsoft.EntityFrameworkCore;

namespace EDA.Consumer.Demo.Infrastructure.Common.Persistence;

public class EdaDemoDbContext : DbContext, IUnitOfWork
{
    public DbSet<Check> Checks { get; set; } = null!;

    public EdaDemoDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
    
    public async Task CommitTransactionAsync()
    {
        await SaveChangesAsync();
    }
    
    public async Task RevertTransactionAsync()
    {
        await Database.RollbackTransactionAsync();
    } 
}