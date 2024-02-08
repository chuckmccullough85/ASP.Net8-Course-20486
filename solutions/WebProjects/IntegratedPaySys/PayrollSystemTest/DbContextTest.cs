
using PayrollSystemLib;

namespace PayrollSystemTest;

public class DbContextTest : IDisposable
{
    private PayrollDbContext ctx;
    public DbContextTest()
    { 
        ctx = new PayrollDbContext();
    }

    public void Dispose()
    {
        ctx.Dispose();
    }

    [Fact(Skip = "This test is for manual use only")]
    public void TestSeedDatabase()
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        var c1 = new Company("Acme", "1234567", "123 Main St");
        var c2 = new Company("Widgets Inc", "7654321", "456 Main St");
        var c3 = new Company("SynerTech", "1112233", "789 Main St");

        var e1 = new Employee("Bob", 50000, new DateTime(2010, 1, 1));
        var e2 = new Employee("Sue", 60000, new DateTime(2011, 2, 2));
        var e3 = new Employee("Tom", 70000, new DateTime(2012, 3, 3));
        var e4 = new Employee("Ann", 80000, new DateTime(2013, 4, 4));

        c1.Hire(e1);
        c1.Hire(e2);
        c2.Hire(e3);
        c2.Hire(e4);

        ctx.Companies.AddRange(c1, c2, c3);

        ctx.SaveChanges();
    }
}