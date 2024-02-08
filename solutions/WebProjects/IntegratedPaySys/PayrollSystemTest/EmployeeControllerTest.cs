using Microsoft.AspNetCore.Mvc;
using Moq;
using PayrollSystemLib;
using PayrollSystemWeb.Controllers;
using PayrollSystemWeb.Models;

namespace PayrollSystemTest;

public class EmployeeControllerTest
{
    EmployeeController sut;
    public EmployeeControllerTest()
    {
        sut = new EmployeeController(Mock.Of<IPayrollService>());
    }

    [Fact]
    public void TestIndex()
    {
        var result = sut.Index();
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsAssignableFrom<IEnumerable<IdName>>(viewResult.Model);
    }
    [Fact] public void TestEditDetail() 
    {
        var result = sut.EditDetail(1);
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsAssignableFrom<EmployeeDetailModel>(viewResult.Model);
    }
    [Fact]
    public void TestSave()
    {
        var result = sut.Save(new EmployeeDetailModel(1, "Hank", "Hill", 200, DateTime.Today, "123-456-7890"));
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
    }

    [Fact]
    public void TestSaveWithValidationError()
    {
        sut.ModelState.AddModelError("Name", "Name is required");
        var result = sut.Save(new EmployeeDetailModel(1, "Hank", "Hill", 200, DateTime.Today, "123-456-7890"));
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal("EditDetail", viewResult.ViewName);
    }

    [Fact] void TestPay()
    {
        var result = sut.Pay(1);
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("EditDetail", redirectResult.ActionName);
    }
    [Fact] void TestDelete()
    {
        var result = sut.Delete(1);
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
    }
}
