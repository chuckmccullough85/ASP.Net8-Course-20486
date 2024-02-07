## Overview

In this lab, we will resurrect the old *Employee* class from earlier in the course.  We will define xUnit tests to specify new behaviors for the class.

| | |
| --------- | --------------------------- |
| Exercise Folder | xUnit | 
| Builds On | Website |
| Time to complete | 30 minutes  
   
1. Create a new class *Employee* in the *PayrollSystemLibrary* project
2. Paste the code below so that we have a common starting point
3. Create a new class in *PayrollSystemTest* project named *EmployeeTests*
4. Create a **[Fact]** to verify that the *Tenure* property is working correctly
5. Create a **[Fact]** to specify a new method *Pay()* that pays the employee
6. Create a **[Fact]** to specify a new property *YtdEarnings*
7. Verify that the new tests fail
8. Implement the required code in *Employee*

---

```c#
public class Employee
{
    public Employee(int id, string name, double salary, DateTime hiredate)
    {
        Id = id;
        FirstName = name;
        LastName = "";
        Salary = salary;
        Hiredate = hiredate;
    }
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public double Salary { get; set; }
    public DateTime Hiredate { get; init; }
    public string? HomePhone { get; set; }
    public int Tenure
    {
        get
        {
            var years = DateTime.Today.Year - Hiredate.Year;
            if (DateTime.Today.DayOfYear < Hiredate.DayOfYear) years--;
            return years;
        }
    }

    public void Deconstruct(out int id, out string name, out double salary, out int tenure)
    {
        id = Id; name = FirstName; salary = Salary; tenure = Tenure;
    }
    public void Deconstruct(out string name, out int tenure) => (_, name, _, tenure) = this;

    public override string ToString()
        => $"{FullName} has worked here {Tenure} years";

    public override bool Equals(object? obj) => obj is Employee employee &&
               Id == employee.Id &&
               FirstName == employee.FirstName &&
               LastName == employee.LastName;

    public override int GetHashCode()
        => HashCode.Combine(Id, FirstName, LastName);
}

```

---


*EmployeeTests*
```c#

using PayrollSystemLib;

namespace PayrollSystemTest;

public class EmployeeTests
{
    [Fact]
    public void TestEmployeeTenureCorrect1Year()
    {
        var emp = new Employee(1, "Hank", 100000, DateTime.Today.AddDays(-400));
        Assert.Equal(1, emp.Tenure);
    }
    [Fact]
    public void TestEmployeeTenureCorrect0Year()
    {
        var emp = new Employee(1, "Hank", 100000, DateTime.Today.AddDays(-364));
        Assert.Equal(0, emp.Tenure);
    }

    [Fact]
    public void TestEmployeePay()
    {
        var emp = new Employee(1, "Hank", 1000, DateTime.Today.AddDays(-400));
        double net = emp.Pay();
        Assert.True (net > 0);
        Assert.True (net <= 1000);
    }

    [Fact]
    public void TestEmployeeYTDEarnings()
    {
        var emp = new Employee(1, "Hank", 1000, DateTime.Today.AddDays(-400));
        emp.Pay();
        emp.Pay();
        double ytd = emp.YTDEarnings;
        Assert.Equal(2000, ytd);
    }
}
```



[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/XUnit/PayrollSystemLibrary)