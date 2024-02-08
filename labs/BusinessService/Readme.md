In this lab, we will create some sample data and specify and implement our business service.

| | |
| --------- | --------------------------- |
| Exercise Folder | Business Service
| Builds On | EF |
| Time to complete | 30 minutes

### PayrollServiceDbTest
1. Create a new class named *PayrollServiceDbTest* in your test project
2. Create an instance variable to hold the context
3. In the constructor, create a context, delete and create the database
4. Add some sample data and save the context
5. Implement **IDisposable** and dispose the context
 

### The Service Class

1. Create a new class named *PayrollService* that implements the *IPayrollService* interface
2. Use the quick fix to generate all the methods in the interface
3. Define a constructor that accepts a PayrollDbContext as an argument - save it to an instance variable (or use a primary constructor)

### Just the Facts 
1. Create simple facts in the test class to check the results of each service method.  Don't get too detailed, just make simple checks. 
2. All tests should fail since all of the methods in the service class throw exceptions.



*The facts*
```c#
[Fact]
public void TestGetCompanies()
{
    //Act
    var companies = sut.GetCompanies();
    //Assert
    Assert.Equal(3, companies.Count());
}
[Fact]
public void TestGetCompany()
{
    var comp = sut.GetCompany(1);
    Assert.Equal("Acme", comp.Name);
}
[Fact]
public void TestSaveCompany()
{
    var comp = sut.GetCompany(1);
    comp.Name = "Acme, Inc.";
    sut.SaveCompany(1, "Acme, Inc.", comp.Address, comp.TaxId);
    var comp2 = sut.GetCompany(1);
    Assert.Equal("Acme, Inc.", comp2.Name);
}
[Fact]
public void TestGetEmployees()
{
    var emps = sut.GetEmployees();
    Assert.Equal(6, emps.Count());
}
[Fact]
public void TestGetEmployee()
{
    var emp = sut.GetEmployee(1);
    Assert.Equal("Tim", emp.FirstName);
}
[Fact] void TestGetCompanyEmployees()
{
    var emps = sut.GetEmployees(1);
    Assert.Equal(2, emps.Count());
}
[Fact] void TestDeleteEmployee()
{
    sut.DeleteEmployee(1);
    var emps = sut.GetEmployees();
    Assert.Equal(5, emps.Count());
}
[Fact] void TestGetNonEmployees()
{
    var emps = sut.GetNonEmployees(1);
    Assert.Equal(4, emps.Count());
}
[Fact] void TestHire()
{
    sut.Hire(1, 6);
    var emps = sut.GetEmployees(1);
    Assert.Equal(3, emps.Count());
}
[Fact] void TestTerminate()
{
    var comp = ctx.Companies.First();
    var emp = comp.Payables.First();
    var count = comp.Payables.Count();
    sut.Terminate(comp.Id, emp.Id);
    var emps = sut.GetEmployees(comp.Id);
    Assert.Equal(count - 1, emps.Count());
}

[Fact] void TestSaveEmployee()
{
    var emp = sut.GetEmployee(1);
    emp.FirstName = "Robert";
    sut.SaveEmployee(1, emp.FirstName, emp.LastName, emp.Salary, emp.HireDate, emp.Phone);
    var emp2 = sut.GetEmployee(1);
    Assert.Equal("Robert", emp2.FirstName);
}
```


### Service Class Implementation
Using the context and Linq, implement each of the service methods.  Verify with success test runs.

