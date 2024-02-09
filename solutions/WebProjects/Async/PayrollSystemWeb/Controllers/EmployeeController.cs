using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;
using PayrollSystemWeb.Models;

namespace PayrollSystemWeb.Controllers;

public class EmployeeController(IPayrollService svc) : Controller
{
    public async Task<IActionResult> Delete(int id)
    {
        await svc.DeleteEmployee(id);
        return RedirectToAction("Index");
    }

    public IActionResult EditDetail(int id)
    {
        var emp = svc.GetEmployee(id);
        return View(new EmployeeDetailModel(
            emp.Id,
            emp.FirstName,
            emp.LastName,
            emp.Salary,
            emp.HireDate,
            emp.Phone ?? string.Empty,
            emp.YtdPay));
    }

    public IActionResult Index()
    {
        return View(svc.GetEmployees());
    }

    public async Task<IActionResult> Pay(int id)
    {
        await svc.Pay(id);
        return RedirectToAction("EditDetail", new { id = id });
    }

    public async Task<IActionResult> Save(EmployeeDetailModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("EditDetail", model);
        }
        await svc.SaveEmployee(model.Id, model.FirstName, model.LastName, model.Salary, model.HireDate, model.HomePhone);
        return RedirectToAction("Index");
    }
}