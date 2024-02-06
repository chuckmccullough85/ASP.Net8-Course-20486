## Overview

In this exercise, we will create data in the controller method and update the view pages to display the dynamic information.

| | |
| --------- | --------------------------- |
| Exercise Folder | DynamicPages |
| Builds On | Previous |
| Time to complete | 45 minutes  

---

### Business Layer

1. Create a new class in **PayrollSystem**_**Library**_ named _IPayrollService_
1. Change the class to **public interface.**  Leave this type empty for now.
1. Add a **record** in the same file     
```c#
public record IdName(int Id, string Name);
```
---
### CompanyController

1. In _Index_, create a collection of _IdName_ objects
1. Add elements containing id numbers and company names
1. Assign the collection to either a **ViewBag** or **ViewData** element 
1. Modify _Index.cshtml_ to generate the list of company links from the model.

---

### Challenge
Create an isolated stylesheet for *Company/Index* and use it to style the horizontal rule or any other element on the page.


[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/WebProjects/DynamicViews)