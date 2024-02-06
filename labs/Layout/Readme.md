## Overview

We begin by customizing the web application main template.  Note, rather than run/stop/code/run/stop, you can right click on a view (Home/Index) and choose _View in Browser_.  Leave the browser open and make changes then build.  The browser will refresh when the build is complete.

| | |
| --------- | --------------------------- |
| Exercise Folder | Layout |
| Builds On | Previous |
| Time to complete | 15 minutes    
 
---

1. Open _ViewsShared/\_Layout.cshtml_ 
1. Locate the application name (defaults to the project name) and update to your project name.  This appears in the title bar, the top left of the page and in the footer.
1. Change the copyright date from the hardcoded year to @DateTime.Today.Year
1. Locate the menu bar <UL> and add 2 menu options between **Home** and **Privacy** (shown below)

  
```html
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
</li>
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Company" asp-action="Index">Companies</a>
</li>
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Employee" asp-action="Index">Employees</a>
</li>
```
---


![img](https://www.trainmyprogrammers.com/api/User/Image/11)

---

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/WebProjects/Layout/PayrollSystemWeb)