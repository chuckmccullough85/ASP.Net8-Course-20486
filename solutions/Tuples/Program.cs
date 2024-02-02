using TuplesLab;


var svc = new EmployeeService();

Console.WriteLine(svc.ToString());

var employee = svc.GetEmployeeInfo(1);

Console.WriteLine($"{employee.id} {employee.name} {employee.ytdEarnings}");
Console.WriteLine(employee.ToString());