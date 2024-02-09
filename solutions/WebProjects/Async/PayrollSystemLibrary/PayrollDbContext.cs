using Microsoft.EntityFrameworkCore;

namespace PayrollSystemLib;

public class PayrollDbContext : DbContext
{
    public PayrollDbContext()
    { }
    public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options)
    { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite("Data Source=../payroll.db");
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Ignore(e => e.FullName)
            .Ignore(e => e.Tenure);
        base.OnModelCreating(modelBuilder);
    }
}
