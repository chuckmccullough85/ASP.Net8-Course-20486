## Overview

In this lab, we will design the business service to support our controllers.  We will have the object injected into the controllers via DI

| | |
| --------- | --------------------------- |
| Exercise Folder | DependencyInjection-1 |
| Builds On | Employee Controller 
| Time to complete | 45 minutes  

---

### Goal
The business service object will be used by our controllers to interact with the business layer.  The design of the API is driven by the caller (the controller actions).  We want to avoid exposing business objects (*Company* & *Employee*).  The service class(es) are traditional *facade* patterns.  We have already created an initial interface for the service named *IPayrollService*.  

Let's start with *CompanyController*.  
1. Add a constructor that accepts an *IPayrollService* parameter and save the object to an instance variable to use in the actions
    * or use the new *Primary Constructor* syntax
2. Index - we need a list of companies.   Add a method to the interface `IEnumerable<IdName> GetAllCompanies()` and call it from index 
3. EditDetail - we need to retrieve the details of a specific company.  Add a method to the interface ```(int Id, string Name, string TaxId, string Address) GetCompanyDetail(int id)```  and call it to get the company detail.  Transfer the data to your model.
4. SaveDetail - we need a method to update the company.  Add a method ```void SaveCompany(int id, string name, string taxId, string Address)``` and call it to save the company
5. ManageResources - we will need methods to get a list of employees for a given company and a method to get a list of other employees not employed by the company.  Let's add 2 methods

```c#
IEnumerable<IdName> GetEmployees(int companyId);
IEnumerable<IdName> GetNonEmployees(int companyId);
```
6. Finally, we need methods to hire and fire employees.  Add the methods '''void Hire(int companyId, int employeeId);``` and ```void Terminate(int companyId, int employeeId);```
7. Following this theme, repeat for *EmployeeController*

* You should be able to *build* the application, but you will not be able to run it yet.  We will add the service implementation in the next lab.

---

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/WebProjects/DI-1)

---