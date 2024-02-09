## Overview

This exercise demonstrates WebApi server capabilities using Swagger

| | |
| --------- | --------------------------- |
| Exercise Folder | WebApi |
| Builds On | PaySys |
| Time to complete | 30 minutes     
  

add  these Nuget packages:
* Microsoft.ASPNetCore.OpenApi & 
* Swashbuckle.AspNetCore 

Modify Program.cs as follows:

```c#
builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen();  
```
and further down...
```c#
if (app.Environment.IsDevelopment())  
{  
    app.UseSwagger();  
    app.UseSwaggerUI();  
}
```
and further down...

```c#
app.MapControllers();   // after UseAuthorization
```
  

* Create a folder in the project named _api_
* Add an empty API controller to the folder
* Add a simple get method
* Run the website and browse to .../swagger

* * *

#### Part 2
  

1. Define a method in _IPayrollService_ 

```  Task<double> PayAll(int companyid); ```

2. Implement the method in PayService - call the company's pay method and return the net pay.
3. Add a \[HttpPost\] Pay method to the service that calls the company's pay method.

---  

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/WebProjects/WebApi)