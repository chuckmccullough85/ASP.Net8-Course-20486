using Classes;

EmployeeService svc = new();
var data = svc.GetEmployeeInfo(12345);
Console.WriteLine(data);
Console.WriteLine(data.YtdEarnings);
Console.WriteLine(data.Name);

//--- deconstruction lab

Employee hank = new Employee(3, "Hank Hill", 300, DateTime.Parse("1/10/1995"));


var (_, n, sal, t) = hank;
Console.WriteLine($"{n} makes {sal:c} and has worked here {t} years");
Employee peg = new Employee(3, "Peggy Hill", 310, DateTime.Parse("12/1/2005"));

(n, t) = peg;
Console.WriteLine($"{n} has worked here {t} years");


//- null operators lab
Console.WriteLine(peg.HomePhone?.Substring(0, 3) ?? "no home phone");