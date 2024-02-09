## Overview

In this lab, we will unhook the fake service and install our real service.

| | |
| --------- | --------------------------- |
| Exercise Folder | Business Service
| Builds On | EF |
| Time to complete | 30 minutes

### Configuration
1. in the web application, add the connection string to *appsettings.json*
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "ConnectionStrings": {
    "paysys": "insert connection string here"
  }
}
```

2. In *Program.cs* configure the db context and change *FakeService* to "PayService*

```c#
var cs = builder.Configuration.GetConnectionString("paysys");
builder.Services.AddDbContext<PayrollDbContext>(options =>
{
    options.UseSqlite(cs);
});

builder.Services.AddScoped<IPayrollService, PayrollService>();
```

Now, you can run your web application with a real database!  
Test your application to see that all features work!

### Bugs
* *EditDetail.cshtml* - The manage resources button (`<a>`) is not passing the company id to the *ManageResources* action. 
```html
<a class="btn btn-primary" asp-action="ManageResources" asp-route-id="@Model.Id">Resources</a>
```

* *ManageResources.cshtml* is not capturing the company id, so it is not being passed to the Hire/Terminate actions.  Add a hidden form field to capture the company id.
```html
<input type="hidden" asp-for="CompanyId" />
```


### To do's
* Display the YTD pay for the employee on the employee detail page.  Now verify that the YTD pay is being updated when you run pay the employee.
* Add a pay button on the company index page after each company to pay all the employees in the company.


---

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/WebProjects/IntegratedPaySys)
