
using Moq;
using PayrollSystemLib;

namespace PayrollSystemTest;

public class CompanyTests
{

    [Fact]
    void TestCreateCompany()
    {
        var comp = new Company("Test Company", "12-1234567", "123 Easy");

        Assert.Multiple(
            () => Assert.Equal("Test Company", comp.Name),
            () => Assert.Equal("12-1234567", comp.TaxId),
            () => Assert.Equal("123 Easy", comp.Address));
    }

    [Fact] void TestCompanyHireEmployee()
    {
        var comp = new Company("Test Company", "12-1234567", "123 Easy");
        comp.Hire(Mock.Of<IPayable>());
        comp.Hire(Mock.Of<IPayable>());
        Assert.Equal(2, comp.Payables.Count());
    }
    [Fact] void TestCompanyPayAllEmployees()
    {
        var comp = new Company("Test Company", "12-1234567", "123 Easy");
        var e1 = new Mock<IPayable>();
        var e2 = new Mock<IPayable>();
        e1.Setup(e => e.Pay()).Returns(100);
        e2.Setup(e => e.Pay()).Returns(200);
        comp.Hire(e1.Object);
        comp.Hire(e2.Object);
        double total = comp.Pay();
        Assert.Equal(300, total, .001);
    }
}
