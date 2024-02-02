using Classes;
using RecordsLab;


var svc = new EmployeeService();
var employee = svc.GetEmployeeInfo(1);
Console.WriteLine(employee);

var (id, n, y) = employee;

Console.WriteLine($"Employee {id} {n} has {y} years of service");

//--- deconstruction lab

Employee hank = new Employee(3, "Hank Hill", 300, DateTime.Parse("1/10/1995"));

var (_, nm, sal, t) = hank;
Console.WriteLine($"{nm} makes {sal:c} and has worked here {t} years");
Employee peg = new Employee(3, "Peggy Hill", 310, DateTime.Parse("12/1/2005"));

(n, t) = peg;
Console.WriteLine($"{n} has worked here {t} years");