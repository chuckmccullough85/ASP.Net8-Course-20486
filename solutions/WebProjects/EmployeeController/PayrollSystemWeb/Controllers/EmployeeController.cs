using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;
using PayrollSystemWeb.Models;

namespace PayrollSystemWeb.Controllers;

public class EmployeeController : Controller
{
    public IActionResult Delete(int id)
    {
        return RedirectToAction("Index");
    }

    public IActionResult EditDetail(int id)
    {
        return View(new EmployeeDetailModel(1, "Hank", "Hill", 200, DateTime.Today, "123-456-7890"));
    }

    public IActionResult Index()
    {
        return View(new List<IdName>() {
            new IdName(1, "Hank Hill"),
            new IdName(2, "Peggy Hill") });
    }

    public IActionResult Pay(int id)
    {
        return RedirectToAction("EditDetail", new { id = id });
    }

    public IActionResult Save(EmployeeDetailModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("EditDetail", model);
        }
        return RedirectToAction("Index");
    }
}