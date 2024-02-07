## Overview

In this lab, we will use Moq for testing companies

| | |
| --------- | --------------------------- |
| Exercise Folder | Moq |
| Builds On | Previous |
| Time to complete | 45 minutes  

* * *

#### Install Moq

1. Right-click on _PayrollSystem**Test**_ project and choose _Manage Nuget Packages_  
1. Click on _Browse_ tab and search for **Moq**.  
1. Select **Moq** and choose _Install_.

---

#### New class - *Company*

We start by designing our new class.  See the test code below:
Company will hire and pay *IPayable* type objects.

4. Run the tests to verify they fail
5. Implement the *Company* class to satisfy the tests

*CompanyTest*
```c#
using Moq;
using PayrollSystemLib;

namespace PayrollSystemTest;

public class CompanyTests
{

    [Fact]
    void TestCreateCompany()
    {
        var comp = new Company("Test Company", "12-1234567", "123 Easy");

        Assert.Multiple(
            () => Assert.Equal("Test Company", comp.Name),
            () => Assert.Equal("12-1234567", comp.TaxId),
            () => Assert.Equal("123 Easy", comp.Address));
    }

    [Fact] void TestCompanyHireEmployee()
    {
        var comp = new Company("Test Company", "12-1234567", "123 Easy");
        comp.Hire(Mock.Of<IPayable>());
        comp.Hire(Mock.Of<IPayable>());
        Assert.Equal(2, comp.Payables.Count());
    }
    [Fact] void TestCompanyPayAllEmployees()
    {
        var comp = new Company("Test Company", "12-1234567", "123 Easy");
        var e1 = new Mock<IPayable>();
        var e2 = new Mock<IPayable>();
        e1.Setup(e => e.Pay()).Returns(100);
        e2.Setup(e => e.Pay()).Returns(200);
        comp.Hire(e1.Object);
        comp.Hire(e2.Object);
        double total = comp.Pay();
        Assert.Equal(300, total, .001);
    }
}
```

*Company skeleton*
```c#
namespace PayrollSystemLib;

public interface IPayable
{
    public string FullName { get; }
    public double Pay();
}

public class Company
{
    public Company(string name, string taxId, string address)
    {
    }

    public string Name { get; set; }
    public string TaxId { get; set; }
    public string Address { get; set; }
    public IEnumerable<IPayable> Payables {get;set;}

    public void Hire(IPayable payable)
    {
    }

    public double Pay()
    {return 0;
    }
}
```

--- 

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/Moq)


---

<iframe width="560" height="315" src="https://www.youtube.com/embed/fIyucuUhiSA?si=wDtYRrx0tcjrPoBS" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>