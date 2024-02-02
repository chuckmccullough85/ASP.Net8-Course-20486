Create the projects for our web application.  These projects can be part of a new solution, or you can create them in the existing solution.

| | |
| --------- | --------------------------- |
| Exercise Folder | PayrollSys |
| Builds On | None |
| Time to complete | 15 minutes

* * *

### Steps

1.  Create a C# library project name _**PayrollSystemLibrary**_
2.  Create a C# XUnit project named _**PayrollSystemTest**_
3.  Create a C# ASP.Net Core Web App (Model View Controller) named _**PayrollSystemWeb**_
4.  Right click on _PayrollSystemTest_ and choose _Add Project Reference._
5.  Add both web and library projects as dependencies.
6.  Add _**PayrollSystemLibrary**_ as a dependency of _**PayrollSystemWeb**_  
    
7.  Make _**PayrollSystemWeb**_ the startup project.  
    
8.  Run the application


### VS Code
Create a new folder to hold the 3 projects.  Open a terminal window in the folder.  Run the following commands to create the projects.

`new mvc -o PayrollSystemWeb`
`dotnet new classlib  -o PayrollSystemLibrary`
`dotnet new xunit -o PayrollSystemTest`

* Use these commands to set up the project dependencies

`dotnet add PayrollSystemWeb\PayrollSystemWeb.csproj reference PayrollSystemLibrary`
`dotnet add PayrollSystemTest\PayrollSystemTest.csproj reference PayrollSystemLibrary`
`dotnet add PayrollSystemTest\PayrollSystemTest.csproj reference PayrollSystemWeb`