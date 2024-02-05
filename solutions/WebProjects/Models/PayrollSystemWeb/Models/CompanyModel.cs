using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollSystemLib;
using System.ComponentModel.DataAnnotations;
namespace PayrollSystemWeb.Models
{
    public record CompanyDetailModel(
        int Id,
        [RegularExpression(@"\d\d-\d{7}")] string TaxId,
        [RegularExpression(@"[\w\s',.$-]{2,30}")] string Name,
        [RegularExpression(@"[\w\s',.$-]{2,30}")] string Address
        );


    public record ManageResourcesModel(int compId, IEnumerable<IdName> nonEmployees,
            IEnumerable<IdName> employees)
    {
        public IEnumerable<SelectListItem>? Employees { get; init; }
            = employees.Select(e => new SelectListItem(e.Name, e.Id.ToString()));
        public IEnumerable<SelectListItem>? NonEmployees { get; init; }
            = nonEmployees.Select(e => new SelectListItem(e.Name, e.Id.ToString()));
        public int? SelectedEmployee { get; init; } = -1;
        public int? SelectedNonEmployee { get; init; } = -1;
        public int CompanyId { get; init; } = compId;
    }
}
