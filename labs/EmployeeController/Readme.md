## Overview

In this lab, we will use design and spec the EmployeeController

| | |
| --------- | --------------------------- |
| Exercise Folder | EmployeeController |
| Builds On | Previous |
| Time to complete | 45 minutes  

* * *

#### EmployeeControllerTest
The goal if this part of the exercise is to determine the employee screens, actions, and flow.

Screens:
- Index - display an alphabetical list of all employees as hyperlinks
- EmployeeDetail - display a form where basic employee information can be edited
	- Save - update the employee detail and go back to the Index
	- Pay - pay the employee and update the screen with the new YTD earnings (stay on the detail page)
	- Delete - remove the employee from the system and return to the index page
	- Cancel - return to the index with no changes

The *EmployeeController* will need these actions:
- Index
- EditDetail
- Save
- Pay
- Delete

#### Steps
1. Create a new class in the *Test* project named *EmployeeControllerTest*.  We will use this class, initially to specify the flow of the employee controller, models and parameters
2. Add an instance variable and constructor to the test to create the test subject

```c#
EmployeeController sut;
public EmployeeControllerTest()
{
    sut = new EmployeeController();
}
```

3. Add *TestIndex* to the test.  We expect a view result from index as well as a model of *IEnumerable<IdName>* - the list of employees.

```c#
[Fact]
public void TestIndex()
{
    var result = sut.Index();
    var viewResult = Assert.IsType<ViewResult>(result);
    Assert.IsAssignableFrom<IEnumerable<IdName>>(viewResult.Model); 
}
```
4. Use the quick actions to generate the *Index* method.  Make required changes to the interface (returns *IActionResult*)
5. Add the rest of the tests as shown below and generate the appropriate methods in the *EmployeeController* and generate the needed model types
6. Verify that all tests fail
7. Implement the controller methods using hard-coded data
8. Generate the views

```c#
[Fact] public void TestEditDetail() 
{
    var result = sut.EditDetail(1);
    var viewResult = Assert.IsType<ViewResult>(result);
    Assert.IsAssignableFrom<EmployeeDetailModel>(viewResult.Model);
}
[Fact]
public void TestSave()
{
    var result = sut.Save(new EmployeeDetailModel(1, "Hank", "Hill", 200, DateTime.Today, "123-456-7890"));
    var redirectResult = Assert.IsType<RedirectToActionResult>(result);
    Assert.Equal("Index", redirectResult.ActionName);
}

[Fact]
public void TestSaveWithValidationError()
{
    sut.ModelState.AddModelError("Name", "Name is required");
    var result = sut.Save(new EmployeeDetailModel(1, "Hank", "Hill", 200, DateTime.Today, "123-456-7890"));
    var viewResult = Assert.IsType<ViewResult>(result);
    Assert.Equal("EditDetail", viewResult.ViewName);
}

[Fact] void TestPay()
{
    var result = sut.Pay(1);
    var redirectResult = Assert.IsType<RedirectToActionResult>(result);
    Assert.Equal("EditDetail", redirectResult.ActionName);
}
[Fact] void TestDelete()
{
    var result = sut.Delete(1);
    var redirectResult = Assert.IsType<RedirectToActionResult>(result);
    Assert.Equal("Index", redirectResult.ActionName);
}

```	

---

*EmployeeController Skeleton*
```c#

public class EmployeeController : Controller
{
    public EmployeeController()
    {
    }

    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IActionResult EditDetail(int id)
    {
        throw new NotImplementedException();
    }

    public IActionResult Index()
    {
        throw new NotImplementedException();
    }

    public IActionResult Pay(int id)
    {
        throw new NotImplementedException();
    }

    public IActionResult Save(EmployeeDetailModel model)
    {
        throw new NotImplementedException();
    }
}	
```
---
Solutions:
