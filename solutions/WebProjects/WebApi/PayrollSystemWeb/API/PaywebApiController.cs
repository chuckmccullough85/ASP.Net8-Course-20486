
using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;
using PayrollSystemWeb.Models;

namespace PayrollSystemWeb.API;

[Route("api/[controller]")]
[ApiController]
public class PaywebApiController : ControllerBase
{
    [HttpGet]
    public string SayHello()
    {
        return "Hello from PaywebApiController";
    }
    [HttpGet, Route("companies")]
    public IEnumerable<IdName> GetCompanies(IPayrollService svc)
    {
        return svc.GetAllCompanies();
    }

    [Route("payall/{id}")]
    [HttpPost]
    public double PayAll(int id, IPayrollService svc)
    {
        return svc.PayAll(id);
    }

    [HttpPost, Route("company")]
    public IActionResult AddCompany(string name, string taxid, string address, IPayrollService svc)
    {
        // tuples don't serialize well, so we'll create a model to return
        var c = svc.AddCompany(name, address, taxid);
        var comp = new CompanyDetailModel(c.Id, c.Name, c.Taxid, c.Address);
        return Ok(comp);
    }

    [HttpPost, Route("employee")]
    public IActionResult AddEmployee(string firstName, string lastName, double salary, DateTime hireDate, string homePhone, IPayrollService svc)
    {
        var result = svc.AddEmployee(firstName, lastName, salary, hireDate, homePhone);
        var emp = new EmployeeDetailModel(result.Id, result.FirstName, result.LastName, result.Salary, result.HireDate, result.Phone, result.YtdPay);
        return Ok(emp);
    }

}