## Overview

In this lab, we will define input parameters for our action methods that handle forms.  Specifically, the save detail action.

| | |
| --------- | --------------------------- |
| Exercise Folder | Forms |
| Builds On | Previous |
| Time to complete | 30 minutes  

---

#### Steps

In _EditDetail.cshtml_, the names of the input fields are _TaxId, Name, Address_.  The form is being **post**ed to the server.

1. Modify *CompanyController.SaveDetail* (add it to *CompanyController* if you don't have it already) to accept 4 parameters, `int id, string taxid, string name`, and `string address`.  Make sure to spell the parameters the same as the ``` <input name>```.  Case does not matter.
1. The form is not submitting an id.  Add a hidden form field to contain the id of the company being edited. 

1. Update the _CompanyController.EditDetail_ method to create model data in _ViewBag_ or _ViewData_ to hold the initial company details, including id.  Modify the cshtml to populate the data from the model.
1. Upon submitting the form, verify that the parameters are being passed in correctly.

> Note - SaveDetail does not create a model for "Index."  Change to _RedirectToAction._

---
