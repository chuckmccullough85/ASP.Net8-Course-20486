
namespace PayrollSystemLib;

using CompanyDetail = (int Id, string Name, string Taxid, string Address); 
using EmployeeDetail = (int Id, string FirstName, string LastName, double Salary, DateTime HireDate, string? Phone);
public record IdName(int Id, string Name);
public interface IPayrollService
{
    void DeleteEmployee(int id);
    IEnumerable<IdName> GetAllCompanies();
    CompanyDetail GetCompanyDetail(int id);
     
    EmployeeDetail GetEmployee(int id);
    IEnumerable<IdName> GetEmployees(int id);
    IEnumerable<IdName> GetEmployees();
    IEnumerable<IdName> GetNonEmployees(int id);
    void Hire(int companyId, int? selectedNonEmployeeId);
    void Pay(int id);
    void SaveCompany(int id, string name, string address, string taxId);
    void SaveEmployee(int id, string firstName, string lastName, double salary, DateTime hireDate, string homePhone);
    void Terminate(int companyId, int? selectedEmployeeId);
}