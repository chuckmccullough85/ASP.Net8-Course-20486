## Overview

In this lab, we will update our client libraries and add bootstrap classes to our web pages!

| | |
| --------- | --------------------------- |
| Exercise Folder | Bootstrap |
| Builds On | None |
| Time to complete | 30 minutes  

1. Use _Client Side Library_ manager to get the latest bootstrap and jquery libraries.
> Note - the directory structure of the libraries in the project template is a little different from the cdn structure.  To make sure you are using the newer version, delete the folders under **wwwroot/lib** and let libman fetch the newer libraries.  Update the references in **_Layout.cshtml** to reflect the correct file location.  You will probably want the **min** versions.

2. Use bootstrap styles to make the mockups prettier! 

---

### VS Code
Install the libman tool by running the following command in the terminal:
```shell
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```
Use --help to see the options for installing libraries.

Use `restore` to install the libraries in the libman.json file.



