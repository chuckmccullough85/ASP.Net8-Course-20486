## Overview

We can create and train a Mock to use in as a service placeholder, but it's also easy to just define a class.  In this lab, we will create a dummy service class and register it with DI.

| | |
| --------- | --------------------------- |
| Exercise Folder | DI part 2 |
| Builds On | DI part 1
| Time to complete | 30 minutes 

---

#### Steps

1. In  *PayrollSystemLib*, create a new class named *FakePayrollService* that implements *IPayrollService*
2. Use quick refactorings to implement the interface
3. Add dummy data to the methods that return something
4. In the web project's *Program.cs*, register the service.  The *AddScoped* method has an overload where you specify the iterface type and the implementation type
```builder.Services.AddScoped<IPayrollService, FakePayrollService>();```

Now, the website should run and you can navigate to all pages.  Check that the fake data returned by the fake service is being used by the website.  **Congratulations** you have successfully utilized **Dependency Injection**

---

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/WebProjects/DI-2)