
using CourseProviderInfrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProviderInfrastructure.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CourseEntity> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CourseEntity>().ToContainer("Courses").HasPartitionKey(x => x.PartitionKey);
        modelBuilder.Entity<CourseEntity>().OwnsMany(p => p.LearningObjectives);
        modelBuilder.Entity<CourseEntity>().OwnsMany(p => p.CourseSteps);
        modelBuilder.Entity<CourseEntity>().OwnsOne(p => p.Category);
    }
}
