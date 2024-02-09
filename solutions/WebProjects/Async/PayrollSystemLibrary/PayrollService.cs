using System.Runtime.CompilerServices;

namespace PayrollSystemLib;

public class PayrollService(PayrollDbContext ctx) : IPayrollService
{
    public async Task<(int Id, string Name, string Taxid, string Address)> 
        AddCompany(string name, string address, string taxId)
    {
        var c = new Company { Name = name, Address = address, TaxId = taxId };
        ctx.Companies.Add(c);
        await ctx.SaveChangesAsync();
        return (c.Id, c.Name, c.TaxId, c.Address);
    }

    public async Task<(int Id, string FirstName, string LastName, double Salary, 
        DateTime HireDate, string? Phone, double YtdPay)> 
        AddEmployee(string firstName, string lastName, double salary, DateTime hireDate, string homePhone)
    {
        var e = new Employee { FirstName = firstName, LastName = lastName, Salary = salary, Hiredate = hireDate, HomePhone = homePhone };
        ctx.Employees.Add(e);
        await ctx.SaveChangesAsync();
        return (e.Id, e.FirstName, e.LastName, e.Salary, e.Hiredate, e.HomePhone, e.YTDEarnings);
    }

    public async Task DeleteEmployee(int id)
    {
        var emp = ctx.Employees.Find(id);
        if (emp != null)
        {
            ctx.Remove(emp);
            await ctx.SaveChangesAsync();
        }
    }

    public IEnumerable<IdName> GetAllCompanies()
        => ctx.Companies.Select(c => new IdName(c.Id, c.Name)).ToList();

    public (int Id, string Name, string Taxid, string Address) GetCompanyDetail(int id)
    {
        var c = ctx.Companies.Find(id);
        if (c == null) throw new InvalidOperationException("Company not found");
        return (c.Id, c.Name, c.TaxId, c.Address);
    }


    public (int Id, string FirstName, string LastName, double Salary, DateTime HireDate, string? Phone, double YtdPay)
        GetEmployee(int id)
    {
        var e = ctx.Employees.Find(id);
        if (e == null) throw new InvalidOperationException("Employee not found");
        return (e.Id, e.FirstName, e.LastName, e.Salary, e.Hiredate, e.HomePhone, e.YTDEarnings);
    }

    public IEnumerable<IdName> GetEmployees(int companyId)
        => ctx.Companies
            .Find(companyId)?.Payables.Select(e => new IdName(e.Id, e.FullName)).ToList()
            ?? new List<IdName>();

    public IEnumerable<IdName> GetEmployees()
        => ctx.Employees.Select(e => new IdName(e.Id, e.FullName)).ToList();

    public IEnumerable<IdName> GetNonEmployees(int companyId)
    {
        var all = GetEmployees();
        var emps = GetEmployees(companyId);
        return all.Except(emps);
    }

    public async Task Hire(int compId, int? empId)
    {
        var comp = ctx.Companies.Find(compId);
        var emp = ctx.Employees.Find(empId);
        if (comp == null || emp == null) throw new InvalidOperationException("Company or Employee not found");
        comp.Hire(emp);
        await ctx.SaveChangesAsync();
    }



    public async Task Pay(int id)
    {
        ctx.Employees.Find(id)?.Pay();
        await ctx.SaveChangesAsync();
    }

    public async Task<double> PayAll(int compId)
    {
        var n = ctx.Companies.Find(compId)?.Pay();
        await ctx.SaveChangesAsync();
        return n ?? 0;
    }

    public async Task SaveCompany(int id, string name, string address, string taxId)
    {
        var comp = ctx.Companies.Find(id);
        if (comp == null) throw new InvalidOperationException("Company not found");
        comp.Name = name;
        comp.Address = address;
        comp.TaxId = taxId;
        await ctx.SaveChangesAsync();
    }

    public async Task SaveEmployee(int id, string firstName, string lastName, double salary, DateTime hireDate, string phone)
    {
        var emp = ctx.Employees.Find(id);
        if (emp == null) throw new InvalidOperationException("Employee not found");
        emp.FirstName = firstName;
        emp.LastName = lastName;
        emp.Salary = salary;
        emp.HomePhone = phone;
        await ctx.SaveChangesAsync();
    }

    public async Task Terminate(int compId, int? empId)
    {
        var comp = ctx.Companies.Find(compId);
        var emp = ctx.Employees.Find(empId);
        if (comp == null || emp == null) throw new InvalidOperationException("Company or Employee not found");
        comp.Payables.Remove(emp);
        await ctx.SaveChangesAsync();
    }

}
