## Overview

Convert controllers and business service to async/await

| | |
| --------- | --------------------------- |
| Exercise Folder | WebAsync |
| Builds On | WebApi |
| Time to complete | 30 minutes     
  

### Async interface
Interfaces cannot use the **async** keyword.  Instead, the interface should return a **Task**.  The **Task** can be a **Task** or **Task<T>**.  The **Task** is a promise to return a value at some point in the future.  The **Task<T>** is a promise to return a value of type T at some point in the future.

Modify the *IPayrollService* interface to use **Task** and **Task<T>** on any methods that will be time consuming (all of the mutating methods)

For instance:

```csharp
Task Hire(int companyId, int? selectedNonEmployeeId);
Task Pay(int id);
Task<double> PayAll(int compId);
Task SaveCompany(int id, string name, string address, string taxId);
```csharp  

### Async implementation
Update the *PayrollService* to use **async** and **await**.  The **async** keyword is used to mark a method as an asynchronous method.  The **await** keyword is used to pause the method until the **Task** is complete.  The **await** keyword can only be used in an **async** method.

Any method calling *SaveChanges* can be changed to **await** *SaveChangesAsync*.

### Controllers
Update any controller method that calls a service method returning *Task* or *Task<T>* to use **async** and **await**.  

---



[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/WebProjects/Async)