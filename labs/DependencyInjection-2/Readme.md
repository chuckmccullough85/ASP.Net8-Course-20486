## Overview

We can create and train a Mock to use in as a service placeholder, but it's also easy to just define a class.  In this lab, we will create a dummy service class and register it with DI.

| | |
| --------- | --------------------------- |
| Exercise Folder | DI part 2 |
| Builds On | DI part 1
| Time to complete | 30 minutes 

---

#### Steps

1. In  *PayrollSystemLib*, create a new class named *FakePayrollService* that implements *IPayrollService*
2. Use quick refactorings to implement the interface
3. Add dummy data to the methods that return something
4. In the web project's *Program.cs*, register the service.  The *AddScoped* method has an overload where you specify the iterface type and the implementation type
```builder.Services.AddScoped<IPayrollService, FakePayrollService>();```

Now, the website should run and you can navigate to all pages.  Check that the fake data returned by the fake service is being used by the website.  **Congratulations** you have successfully utilized **Dependency Injection**

::: spoiler
*FakePayrollService*
```c#

namespace PayrollSystemLib;

public class FakePayrollService : IPayrollService
{
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

    public (int Id, string Name, string Address, string Taxid) GetCompanyDetail(int id)
    {
        return (id, "Company " + id, "Address " + id, "TaxId " + id);
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

    public void SaveCompany(int id, string name, string address, string taxId)
    {
        
    }

    public void Terminate(int companyId, int? selectedEmployeeId)
    {
        
    }
}

```

*Program.cs - first few lines*
```c#
using PayrollSystemLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPayrollService, FakePayrollService>();

var app = builder.Build();

```
:::

---


[CompletedSolutionToThisPoint.zip](/api/user/File/1376)