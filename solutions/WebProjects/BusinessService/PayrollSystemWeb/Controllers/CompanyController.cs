using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;
using PayrollSystemWeb.Models;

namespace PayrollSystemWeb.Controllers;

public class CompanyController(IPayrollService svc) : Controller
{

    public IActionResult Index()
    {
        ViewBag.model = svc.GetAllCompanies();
        return View();
    }
    public IActionResult EditDetail(int id)
    {
        var data = svc.GetCompanyDetail(id);
        var model = new CompanyDetailModel(id, data.Taxid, data.Name, data.Address);
        return View(model);
    }
    public IActionResult SaveDetail(CompanyDetailModel model)
    {
        if (!ModelState.IsValid)
            return View("EditDetail", model);
        svc.SaveCompany(model.Id, model.Name, model.Address, model.TaxId);

        return RedirectToAction("Index");
    }
    public IActionResult ManageResources(int id)
    {
        return View(new ManageResourcesModel(id, svc.GetNonEmployees(id), svc.GetEmployees(id)));
    }

    public IActionResult Hire(ManageResourcesModel model)
    {
        svc.Hire(model.CompanyId, model.SelectedNonEmployee);
        return RedirectToAction("ManageResources", new { id = model.CompanyId });
    }
    public IActionResult Terminate(ManageResourcesModel model)
    {
        svc.Terminate(model.CompanyId, model.SelectedEmployee);
        return RedirectToAction("ManageResources", new { id = model.CompanyId });
    }
}
