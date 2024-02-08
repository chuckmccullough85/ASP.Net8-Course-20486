## Overview

In this lab, we will create a DbContext and make the changes needed to treat Employee & Company as entities.

| | |
| --------- | --------------------------- |
| Exercise Folder | EntityFramework|
| Builds On | DI2 |
| Time to complete | 30 minutes


First, use NuGet to add the following components to the _Solution  (all_ 3 projects)_

*   Microsoft.EntityFrameworkCore
*   Microsoft.EntityFrameworkCore.Proxies
*   Microsoft.EntityFrameworkCore.Sqlite

We need to make some minor changes to our classes to make them EF compatible.

### Payable
EF does not map 1:m relationships to interfaces very well.  We will need to change *IPayable* to an abstract class
- Use the refactor tools to rename *IPayable* to *Payable*
- Change from **interface** to  **abstract class**
- Change *FullName* to abstract
- Change *Pay* to abstract
- Add an auto property *Id*


### Employee
- Change Employee to inherit from *Payable*
-  Add a zero argument constructor
- Remove the *Id* property (also from the constructor)
- Update all the code that we broke with ^
- add **override** to *FullName* and *Pay*
- FullName & Tenure should not be mapped - more on that later


### Company
- add an auto property ``` int Id {get;set;}```
- Modify *Company* so that it depends on *Payable* rather than *IPayable*
- Remove *_payables*
- Add a zero argument constructor
- Change *Payables* to ``` public virtual ICollection<Payable> Payables { get;set; }  = new List<Payable>();```
- Update *Hire* and *Pay()*



### PayrollDbContext
- Create a new public class named PayrollDbContext that inherits from **DbContext**
- Add a zero arrgument constructor
- Add ```public PayrollDbContext(DbContextOptions opt) : base(opt) { } ```
- Add DbSets for Employee and Company
- Override **OnConfiguring** as shown below.  Note - we will fill in the connection string later

```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // the connection string is for testing only.  We will change it later
    if (!optionsBuilder.IsConfigured)
        optionsBuilder.UseSqlite("Data Source=payroll.db"); 
    optionsBuilder.UseLazyLoadingProxies();
    base.OnConfiguring(optionsBuilder);
}
```

- Override **OnModelCreating**
- Configure EF to igonre FullName and Tenure in Employee

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Employee>()
        .Ignore(e => e.FullName)
        .Ignore(e=>e.Tenure);
    base.OnModelCreating(modelBuilder);
}
```

**Make sure the entire solution builds**

### Seed the database
We can simply create a console application or even easier, a test that will reset the database.

*DbContextTest.cs*
```c#

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

    [Fact]
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

```
 
---


[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/WebProjects/EntityFramwork)