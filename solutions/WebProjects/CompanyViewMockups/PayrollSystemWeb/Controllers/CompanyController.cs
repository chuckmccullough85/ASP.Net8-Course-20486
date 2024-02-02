using Microsoft.AspNetCore.Mvc;

namespace PayrollSystemWeb.Controllers;

public class CompanyController : Controller
{
    public IActionResult Index()
    {
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
