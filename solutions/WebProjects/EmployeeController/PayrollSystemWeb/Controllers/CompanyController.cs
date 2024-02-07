using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;
using PayrollSystemWeb.Models;

namespace PayrollSystemWeb.Controllers;

public class CompanyController : Controller
{
    public IActionResult Index()
    {
        ViewBag.model = new[]
        {
            new IdName(1, "Stricland Propane"),
            new IdName(2, "Dales Deadbug"),
            new IdName(3, "Boggle International")
        }; 
        return View();
    }
    [HttpGet]
    public IActionResult EditDetail(int id)
    {
        return View(new CompanyDetailModel(id,"12-1234567", "Dales Deadbug", "123 Easy St."));
    }
    [HttpPost]
    public IActionResult SaveDetail(CompanyDetailModel model)
    {
        if (!ModelState.IsValid) return View("EditDetail", model);
        Console.WriteLine($"{model.Id} {model.TaxId} {model.Name} {model.Address}");
        return RedirectToAction("Index");
    }

    public IActionResult ManageResources(int id)
    {
        var ne = new[]
        {
            new IdName(1, "Hank Hill"),
            new IdName(2, "Dale Gribble"),
            new IdName(3, "Bill Dauterive"),
            new IdName(4, "Jeff Boomhauer")
        };
        var e = new[]
        {
            new IdName(1, "Peggy Hill"),
            new IdName(2, "Bobby Hill"),
            new IdName(3, "Luanne Platter"),
            new IdName(4, "John Redcorn")
        };

        var model = new ManageResourcesModel(1, ne, e);
        return View(model);
    }

    public IActionResult Hire()
    {
        return RedirectToAction("ManageResources");
    }
    public IActionResult Terminate()
    {
        return RedirectToAction("ManageResources");
    }
}
