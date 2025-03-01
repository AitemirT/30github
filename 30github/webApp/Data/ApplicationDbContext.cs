using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webApp.Models;

namespace webApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    public DbSet<TheTask> TheTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Company>()
            .HasMany(c => c.CustomerProjects)
            .WithOne(c => c.CustomerCompany)
            .HasForeignKey(c => c.CustomerCompanyId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Company>()
            .HasMany(c => c.ExecutorProjects)
            .WithOne(c => c.ExecutorCompany)
            .HasForeignKey(c => c.ExecutorCompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}