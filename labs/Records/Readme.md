## Overview

| | |
| --------- | --------------------------- |
| Exercise Folder | Records |
| Builds On | Tuples |
| Time to complete | 15 minutes

---
Continue with Tuples project

1. Define a new record (in EmployeeService.cs) to hold the old tuple data named EmployeeInfo
1. Modify *GetEmployeeInfo* to return a record of type *EmployeeInfo*
1. Update top-level code  

:::spoiler
*EmployeeService.cs*
```c#
namespace RecordsLab;

internal record EmployeeInfo (int Id, string Name, float YtdEarnings);
internal class EmployeeService
{
    public EmployeeInfo GetEmployeeInfo(int id)
    {
        // Get employee info from database
        return new EmployeeInfo(id, "John Doe", 10000.00f);
    }
}
```

*Program.cs*
```c#
var svc = new EmployeeService();
var employee = svc.GetEmployeeInfo(1);
Console.WriteLine(employee);
```
:::

--- 
<br/>
<br/>
<br/>

#### Want More? 

<iframe width="560" height="315" src="https://www.youtube.com/embed/PZpKv8wfIZ4?si=vOq9ZigUm0odahSC" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>