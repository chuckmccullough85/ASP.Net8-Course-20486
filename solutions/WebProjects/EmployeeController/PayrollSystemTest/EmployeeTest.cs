using PayrollSystemLib;

namespace PayrollSystemTest;

public class EmployeeTests
{
    [Fact]
    public void TestEmployeeTenureCorrect1Year()
    {
        var emp = new Employee(1, "Hank", 100000, DateTime.Today.AddDays(-400));
        Assert.Equal(1, emp.Tenure);
    }
    [Fact]
    public void TestEmployeeTenureCorrect0Year()
    {
        var emp = new Employee(1, "Hank", 100000, DateTime.Today.AddDays(-364));
        Assert.Equal(0, emp.Tenure);
    }

    [Fact]
    public void TestEmployeePay()
    {
        var emp = new Employee(1, "Hank", 1000, DateTime.Today.AddDays(-400));
        double net = emp.Pay();
        Assert.True (net > 0);
        Assert.True (net <= 1000);
    }

    [Fact]
    public void TestEmployeeYTDEarnings()
    {
        var emp = new Employee(1, "Hank", 1000, DateTime.Today.AddDays(-400));
        emp.Pay();
        emp.Pay();
        double ytd = emp.YTDEarnings;
        Assert.Equal(2000, ytd);
    }
}