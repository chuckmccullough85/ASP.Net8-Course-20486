## Overview

In this lab, we create pages to display companies, add, and delete companies. Aso, editing company details as well as hiring and terminating employees.

| | |
| --------- | --------------------------- |
| Exercise Folder | CompanyViewMockups |
| Builds On | Previous |
| Time to complete | 45 minutes   

**Company/Index**

*   List all companies as hyperlinks.  The hyperlink should go to ~/Company/EditDetail/# where # is the company id

ie
```html
<a href="~/company/editdetail/2">Dale's Deadbug</a>
```

**Company/EditDetail**

*   Display a form with the company detail
	*   tax id
	*   name
	*   street address
*   The Save button should go to ~/Company/SaveDetail
*   The Resources button should go to ~/Company/Resources

ie
```html
<form action="/company/savedata" method="post">
    <label for="taxid">Tax Id</label>    
    <input type="text" name="taxid" />
```

**Company Resources**   

*   Display 2 lists - one with employees that don't work at the company and a list of employees that do.
*   Display 2 buttons, hire and terminate.  They should link to Hire and Terminate actions.

ie
```html
Available
<select size="10">
    <option>Luann Platter</option>
```

Define CompanyController actions to provide the navigation

ie
```c#
public IActionResult EditDetail()
{
    return View();
}
```

---

