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
    public async Task<IActionResult> SaveDetail(CompanyDetailModel model)
    {
        if (!ModelState.IsValid)
            return View("EditDetail", model);
        await svc.SaveCompany(model.Id, model.Name, model.Address, model.TaxId);

        return RedirectToAction("Index");
    }
    public IActionResult ManageResources(int id)
    {
        return View(new ManageResourcesModel(id, svc.GetNonEmployees(id), svc.GetEmployees(id)));
    }

    public async Task<IActionResult> Hire(ManageResourcesModel model)
    {
        await svc.Hire(model.CompanyId, model.SelectedNonEmployee);
        return RedirectToAction("ManageResources", new { id = model.CompanyId });
    }
    public async Task<IActionResult> Terminate(ManageResourcesModel model)
    {
        await svc.Terminate(model.CompanyId, model.SelectedEmployee);
        return RedirectToAction("ManageResources", new { id = model.CompanyId });
    }
}
