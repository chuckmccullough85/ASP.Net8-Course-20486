using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;
using PayrollSystemWeb.Models;

namespace PayrollSystemWeb.Controllers;

public class EmployeeController(IPayrollService svc) : Controller
{
 public IActionResult Delete(int id)
    {
        svc.DeleteEmployee(id);
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

    public IActionResult Pay(int id)
    {
        svc.Pay(id);
        return RedirectToAction("EditDetail", new { id = id });
    }

    public IActionResult Save(EmployeeDetailModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("EditDetail", model);
        }
        svc.SaveEmployee(model.Id, model.FirstName, model.LastName, model.Salary, model.HireDate, model.HomePhone);
        return RedirectToAction("Index");
    }
}