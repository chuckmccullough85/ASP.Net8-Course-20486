using System.ComponentModel.DataAnnotations;

namespace PayrollSystemWeb.Models;

public record EmployeeDetailModel(
    int Id,
    [RegularExpression(@"^[A-Z][a-z '-]{2,30}$")]
    string FirstName,
    [RegularExpression(@"^[A-Z][a-z '-]{2,30}$")]
    string LastName,
    [Range(50, 999)]
    double Salary,
    DateTime HireDate,
    [Phone]
    string HomePhone,
    double? YtdPay
    );
