using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Infrastructure.Common.Persistence;

public class AutomatedLearningSystemDbContext : DbContext
{
    public AutomatedLearningSystemDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}