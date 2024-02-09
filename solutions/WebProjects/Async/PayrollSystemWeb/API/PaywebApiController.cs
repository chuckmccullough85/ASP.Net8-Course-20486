
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
    public async Task<double> PayAll(int id, IPayrollService svc)
    {
        return await svc.PayAll(id);
    }

    [HttpPost, Route("company")]
    public async Task<IActionResult> AddCompany(CompanyDetailModel company, IPayrollService svc)
    {
        var c = await svc.AddCompany(company.Name, company.TaxId, company.Address);
        return Ok(c.Id);
    }

    [HttpPost, Route("employee")]
    public async Task<IActionResult> AddEmployee(EmployeeDetailModel employee, IPayrollService svc)
    {
        var result = await svc.AddEmployee(employee.FirstName, employee.LastName, employee.Salary, employee.HireDate, employee.HomePhone);
        return Ok(result.Id);
    }

    [HttpGet, Route("employee/{id}")]
    public IActionResult GetEmployee(int id, IPayrollService svc)
    {
        var result = svc.GetEmployee(id);
        var emp = new EmployeeDetailModel(result.Id, result.FirstName, result.LastName, 
                result.Salary, result.HireDate, result.Phone ?? string.Empty, result.YtdPay);
        return Ok(emp);
    }

}