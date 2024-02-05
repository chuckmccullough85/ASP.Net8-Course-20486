using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;

namespace PayrollSystemWeb.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<IdName>()
             {
                 new IdName(1, "Slate Industries"),
                 new IdName(2, "Strickland Propane"),
                 new IdName(3, "Spacely Space Sprockets")
             };
            ViewBag.model = model;
            return View();
        }

        [HttpGet]
        public IActionResult EditDetail()
        {
            ViewBag.Id = 2;
            ViewBag.TaxId = "12.3456789";
            ViewBag.Name = "Slate Enterprises";
            ViewBag.Address = "123 Boulder Way";
            return View();
        }

        [HttpPost]
        public IActionResult SaveDetail(int id, string taxid, string name, string address)
        {
            Console.WriteLine($"{id} {taxid} {name} {address}");
            return RedirectToAction("Index");
        }
        public IActionResult ManageResources()
        {
            return View();
        }
        public IActionResult Hire()
        {
            return View("ManageResources");
        }
        public IActionResult Terminate()
        {
            return View("ManageResources");
        }
    }
}
