using PayrollSystemLib;

namespace PayrollSystemTest;

public class PayrollServiceDbTests : IDisposable
{
    private readonly  PayrollService sut;
    private readonly PayrollDbContext ctx;
    public PayrollServiceDbTests()
    {
        ctx = new PayrollDbContext();
        sut = new PayrollService(ctx);
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

    [Fact]
    public void TestGetCompanies()
    {
        //Act
        var companies = sut.GetAllCompanies();
        //Assert
        Assert.Equal(3, companies.Count());
    }
    [Fact]
    public void TestGetCompany()
    {
        var comp = sut.GetCompanyDetail(1);
        Assert.Equal("Acme", comp.Name);
    }
    [Fact]
    public void TestSaveCompany()
    {
        var comp = sut.GetCompanyDetail(1);
        comp.Name = "Acme, Inc.";
        sut.SaveCompany(1, "Acme, Inc.", comp.Taxid, comp.Address);
        var comp2 = sut.GetCompanyDetail(1);
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
    [Fact]
    void TestGetCompanyEmployees()
    {
        var emps = sut.GetEmployees(1);
        Assert.Equal(2, emps.Count());
    }
    [Fact]
    void TestDeleteEmployee()
    {
        sut.DeleteEmployee(1);
        var emps = sut.GetEmployees();
        Assert.Equal(5, emps.Count());
    }
    [Fact]
    void TestGetNonEmployees()
    {
        var emps = sut.GetNonEmployees(1);
        Assert.Equal(4, emps.Count());
    }
    [Fact]
    void TestHire()
    {
        sut.Hire(1, 6);
        var emps = sut.GetEmployees(1);
        Assert.Equal(3, emps.Count());
    }
    [Fact]
    void TestTerminate()
    {
        var comp = ctx.Companies.First();
        var emp = comp.Payables.First();
        var count = comp.Payables.Count();
        sut.Terminate(comp.Id, emp.Id);
        var emps = sut.GetEmployees(comp.Id);
        Assert.Equal(count - 1, emps.Count());
    }

    [Fact]
    void TestSaveEmployee()
    {
        var emp = sut.GetEmployee(1);
        emp.FirstName = "Robert";
        sut.SaveEmployee(1, emp.FirstName, emp.LastName, emp.Salary, emp.HireDate, emp.Phone!);
        var emp2 = sut.GetEmployee(1);
        Assert.Equal("Robert", emp2.FirstName);
    }
}