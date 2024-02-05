## Overview

In this lab, we will create strongly typed model types to use with the **Detail** and **ManageResources** pages.

| | |
| --------- | --------------------------- |
| Exercise Folder | Models |
| Builds On | Previous |
| Time to complete | 40 minutes  
  

1. Create a new file in the **Models** folder named _CompanyModel.cs_ 
1. Define a record with the properties of _Id, TaxId, Name, Address_
1. Annotate the properties with validation attributes (define your own requirements)
1. Update _EditDetail_.cshtml to declare the **@model** type and use **asp-for** binding attributes
1. Add ```<span>```s to display the error messages
2. Update *SaveDetail* to accept a *CompanyModel* argument
3. Update the _SaveDetail_ controller method to check for validation errors
4. Add jquery validation scripts to *_layout.cshtml* to support client-side validation

#### ManageResources
	
To support models in the _ManageResources_ view, the model needs to support a property of ```IEnumerable<SelectListItem>```.  _SelectListItem_ is a .Net class of name/id pairs to support list boxes.  The attribute **asp-items** binds the list items.

### Design and implement a model for _ManageResources_.

1. In the *CompanyModels.cs* filee, add a new **record** named *ManageResourcesModel*
    * define a primary constructor that accepts the company id, and lists of employees and non-employees.
1. Add a property to the *ManageResourcesModel* named *Employees* of type ```IEnumerable<SelectListItem>``` and initialize from the employees list.
1. Add a property to the *ManageResourcesModel* named *NonEmployees* of type ```IEnumerable<SelectListItem>``` and initialize from the non-employees list.
1. Add properties to hold the selected employee and non-employee ids. These need to be optional.
1. Add a property to hold the company id. Initialize this from the constructor.
