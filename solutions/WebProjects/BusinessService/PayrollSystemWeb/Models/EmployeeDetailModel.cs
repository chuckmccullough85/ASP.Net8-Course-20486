namespace PayrollSystemWeb.Models;

public record EmployeeDetailModel(
    int Id,
    string FirstName,
    string LastName,
    double Salary,
    DateTime HireDate,
    string HomePhone
    );
