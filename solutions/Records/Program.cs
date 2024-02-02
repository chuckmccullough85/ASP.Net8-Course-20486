using RecordsLab;


var svc = new EmployeeService();
var employee = svc.GetEmployeeInfo(1);
Console.WriteLine(employee);