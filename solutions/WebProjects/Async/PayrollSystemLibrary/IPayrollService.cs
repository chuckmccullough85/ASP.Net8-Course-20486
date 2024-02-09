
namespace PayrollSystemLib;

using CompanyDetail = (int Id, string Name, string Taxid, string Address); 
using EmployeeDetail = (int Id, string FirstName, string LastName, double Salary, DateTime HireDate, string? Phone, double YtdPay);
public record IdName(int Id, string Name);
public interface IPayrollService
{
    Task<CompanyDetail> AddCompany(string name, string address, string taxId);
    Task<EmployeeDetail> AddEmployee(string firstName, string lastName, double salary, DateTime hireDate, string homePhone);
    
    Task DeleteEmployee(int id);
    IEnumerable<IdName> GetAllCompanies();
    CompanyDetail GetCompanyDetail(int id);
     
    EmployeeDetail GetEmployee(int id);
    IEnumerable<IdName> GetEmployees(int id);
    IEnumerable<IdName> GetEmployees();
    IEnumerable<IdName> GetNonEmployees(int id);
    Task Hire(int companyId, int? selectedNonEmployeeId);
    Task Pay(int id);
    Task<double> PayAll(int compId);
    Task SaveCompany(int id, string name, string address, string taxId);
    Task SaveEmployee(int id, string firstName, string lastName, double salary, DateTime hireDate, string homePhone);
    Task Terminate(int companyId, int? selectedEmployeeId);
}