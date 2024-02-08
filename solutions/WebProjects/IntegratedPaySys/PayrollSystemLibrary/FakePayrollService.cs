
namespace PayrollSystemLib;

public class FakePayrollService : IPayrollService
{
    public void DeleteEmployee(int id)
    {
        
    }

    public IEnumerable<IdName> GetAllCompanies()
    {
        return new IdName[]
        {
            new IdName(1, "Company 1"),
            new IdName(2, "Company 2"),
            new IdName(3, "Company 3"),
            new IdName(4, "Company 4"),
        };
    }

    public (int Id, string Name, string Taxid, string Address) GetCompanyDetail(int id)
    {
        return (id, "Company " + id, "12-1234567", "123 Main St.");
    }

    public (int Id, string FirstName, string LastName, double Salary, DateTime HireDate, string Phone)
     GetEmployee(int id)
    {
        return (id, "Hank", "Hill", 1000, DateTime.Now, "123-456-7890");
    }

    public IEnumerable<IdName> GetEmployees(int id)
    {
        return new IdName[]
        {
            new IdName(1, "Employee 1"),
            new IdName(2, "Employee 2"),
            new IdName(3, "Employee 3"),
            new IdName(4, "Employee 4"),
        };
    }

    public IEnumerable<IdName> GetEmployees()
    {
        return new IdName[]
        {
            new IdName(1, "Hank Hill"),
            new IdName(2, "Peggy Hill"),
            new IdName(3, "Bobby Hill"),
            new IdName(4, "Dale Gribble"),
            new IdName(5, "Bill Dauterive")
        };
    }

    public IEnumerable<IdName> GetNonEmployees(int id)
    {
        return new IdName[]
{
            new IdName(5, "Employee 5"),
            new IdName(6, "Employee 6"),
            new IdName(7, "Employee 7"),
            new IdName(8, "Employee 8"),
};
    }

    public void Hire(int companyId, int? selectedNonEmployeeId)
    {
        
    }

    public void Pay(int id)
    {
        
    }

    public void SaveCompany(int id, string name, string address, string taxId)
    {
        
    }

    public void SaveEmployee(int id, string firstName, string lastName, double salary, DateTime hireDate, string homePhone)
    {
        
    }

    public void Terminate(int companyId, int? selectedEmployeeId)
    {
        
    }
}
