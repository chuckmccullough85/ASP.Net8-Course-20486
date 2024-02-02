using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;

namespace PayrollSystemWeb.Controllers;

public class CompanyController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Companies = new[]
        {
            new IdName(1, "Stricland Propane"),
            new IdName(2, "Dales Deadbug"),
            new IdName(3, "Boggle International")
        };
        return View();
    }
    public IActionResult EditDetail()
    {
        return View();
    }
    public IActionResult ManageResources()
    {
        return View();
    }
}
