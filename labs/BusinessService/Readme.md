In this lab, we will create some sample data and specify and implement our business service.

| | |
| --------- | --------------------------- |
| Exercise Folder | Business Service
| Builds On | EF |
| Time to complete | 30 minutes

### PayrollServiceDbTest
1. Create a new class named *PayrollServiceDbTest* in your test project
2. Create an instance variable to hold the context
3. In the constructor, create a context, delete and create the database
4. Add some sample data and save the context
5. Implement **IDisposable** and dispose the context
6. Create a do-nothing fact and run it - examine your database.

Note - we need to remove *Id* from the *Employee* class constructor - the db will assign the Id.

::: spoiler
*PayrollSystemDbTests*
```c#

using PayrollSystemLib;

namespace PayrollSystemTest;

public class PayrollServiceDbTests : IDisposable
{
    private readonly PayrollDbContext ctx;
    public PayrollServiceDbTests()
    {
        ctx = new PayrollDbContext();
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        var c1 = new Company("Acme", "12-4567890", "123 Main St");
        var c2 = new Company("Widgets", "98-6543210", "456 Main St");
        var c3 = new Company("SynerTech", "11-1234567", "789 Main St");
        var e1 = new Employee("Bob", 100, new DateTime(2010, 1, 1));
        var e2 = new Employee("Sue", 200, new DateTime(2015, 1, 1));
        var e3 = new Employee("Tom", 300, new DateTime(2020, 1, 1));
        var e4 = new Employee("Ann", 150, new DateTime(2021, 1, 1));
        var e5 = new Employee("Joe", 250, new DateTime(2021, 1, 1));
        var e6 = new Employee("Tim", 350, new DateTime(2021, 1, 1));   
        c1.Hire(e1);
        c1.Hire(e2);
        c2.Hire(e3);
        c2.Hire(e4);
        c3.Hire(e5);

        ctx.Companies.AddRange(c1, c2, c3);
        ctx.Employees.Add(e6);
        ctx.SaveChanges();
    }

    public void Dispose()
    {
        ctx.Dispose();
    }

    [Fact]
    public void Test_Companies()
    {
    }
}
```
:::

### The Service Class

1. Create a new class named *PayrollService* that implements the *IPayrollService* interface
2. Use the quick fix to generate all the methods in the interface
3. Define a constructor that accepts a PayrollDbContext as an argument - save it to an instance variable

### Just the Facts 
1. Create simple facts in the test class to check the results of each service method.  Don't get too detailed, just make simple checks. 
2. All tests should fail since all of the methods in the service class throw exceptions.

::: spoiler
*The facts*
```c#
[Fact]
public void TestGetCompanies()
{
    //Act
    var companies = sut.GetCompanies();
    //Assert
    Assert.Equal(3, companies.Count());
}
[Fact]
public void TestGetCompany()
{
    var comp = sut.GetCompany(1);
    Assert.Equal("Acme", comp.Name);
}
[Fact]
public void TestSaveCompany()
{
    var comp = sut.GetCompany(1);
    comp.Name = "Acme, Inc.";
    sut.SaveCompany(1, "Acme, Inc.", comp.Address, comp.TaxId);
    var comp2 = sut.GetCompany(1);
    Assert.Equal("Acme, Inc.", comp2.Name);
}
[Fact]
public void TestGetEmployees()
{
    var emps = sut.GetEmployees();
    Assert.Equal(6, emps.Count());
}
[Fact]
public void TestGetEmployee()
{
    var emp = sut.GetEmployee(1);
    Assert.Equal("Tim", emp.FirstName);
}
[Fact] void TestGetCompanyEmployees()
{
    var emps = sut.GetEmployees(1);
    Assert.Equal(2, emps.Count());
}
[Fact] void TestDeleteEmployee()
{
    sut.DeleteEmployee(1);
    var emps = sut.GetEmployees();
    Assert.Equal(5, emps.Count());
}
[Fact] void TestGetNonEmployees()
{
    var emps = sut.GetNonEmployees(1);
    Assert.Equal(4, emps.Count());
}
[Fact] void TestHire()
{
    sut.Hire(1, 6);
    var emps = sut.GetEmployees(1);
    Assert.Equal(3, emps.Count());
}
[Fact] void TestTerminate()
{
    var comp = ctx.Companies.First();
    var emp = comp.Payables.First();
    var count = comp.Payables.Count();
    sut.Terminate(comp.Id, emp.Id);
    var emps = sut.GetEmployees(comp.Id);
    Assert.Equal(count - 1, emps.Count());
}

[Fact] void TestSaveEmployee()
{
    var emp = sut.GetEmployee(1);
    emp.FirstName = "Robert";
    sut.SaveEmployee(1, emp.FirstName, emp.LastName, emp.Salary, emp.HireDate, emp.Phone);
    var emp2 = sut.GetEmployee(1);
    Assert.Equal("Robert", emp2.FirstName);
}
```
:::


### Service Class Implementation
Using the context and Linq, implement each of the service methods.  Verify with success test runs.

::: spoiler
```c#

namespace PayrollSystemLib;

public class PayrollService : IPayrollService
{
    private readonly PayrollDbContext ctx;
    public PayrollService(PayrollDbContext ctx)
    {
        this.ctx = ctx;
    }

    public void DeleteEmployee(int id)
    {
        var emp = ctx.Employees.Find(id);
        if (emp != null) 
        {
            ctx.Remove(emp);
            ctx.SaveChanges();
        }
    }

    public IEnumerable<IdName> GetCompanies() 
        => ctx.Companies.Select(c => new IdName(c.Id, c.Name)).ToList();

    public (int Id, string Name, string TaxId, string Address) GetCompany(int id)
    {
        var c = ctx.Companies.Find(id);
        if (c == null) throw new InvalidOperationException("Company not found");
        return (c.Id, c.Name, c.TaxId, c.Address);
    }

    public (int Id, string FirstName, string LastName, double Salary, DateTime HireDate, string? Phone) 
        GetEmployee(int id)
    {
        var e = ctx.Employees.Find(id);
        if (e == null) throw new InvalidOperationException("Employee not found");
        return (e.Id, e.FirstName, e.LastName, e.Salary, e.Hiredate, e.HomePhone);
    }

    public IEnumerable<IdName> GetEmployees(int companyId) 
        => ctx.Companies
            .Find(companyId)?.Payables.Select(e => new IdName(e.Id, e.FullName)).ToList()
            ?? new List<IdName>();

    public IEnumerable<IdName> GetEmployees() 
        => ctx.Employees.Select(e => new IdName(e.Id, e.FullName)).ToList();

    public IEnumerable<IdName> GetNonEmployees(int companyId)
    {
        var all = GetEmployees();
        var emps = GetEmployees(companyId);
        return all.Except(emps);
    }

    public void Hire(int compId, int empId)
    {
        var comp = ctx.Companies.Find(compId);
        var emp = ctx.Employees.Find(empId);
        if (comp == null || emp == null) throw new InvalidOperationException("Company or Employee not found");
        comp.Hire(emp);
        ctx.SaveChanges();
    }

    public void Pay(int id)
    {
        throw new NotImplementedException();
    }

    public void SaveCompany(int id, string name, string address, string taxId)
    {
        var comp = ctx.Companies.Find(id);
        if (comp == null) throw new InvalidOperationException("Company not found");
        comp.Name = name;
        comp.Address = address;
        comp.TaxId = taxId;
        ctx.SaveChanges();
    }

    public void SaveEmployee(int id, string firstName, string lastName, double salary, DateTime hireDate, string phone)
    {
        var emp = ctx.Employees.Find(id);
        if (emp == null) throw new InvalidOperationException("Employee not found");
        emp.FirstName = firstName;
        emp.LastName = lastName;
        emp.Salary = salary;
        emp.HomePhone = phone;
        ctx.SaveChanges();
    }

    public void Terminate(int compId, int empId)
    {
        var comp = ctx.Companies.Find(compId);
        var emp = ctx.Employees.Find(empId);
        if (comp == null || emp == null) throw new InvalidOperationException("Company or Employee not found");
        comp.Payables.Remove(emp);
        ctx.SaveChanges();
    }
}

```
:::
