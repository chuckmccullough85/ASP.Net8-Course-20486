
//--- deconstruction lab

using Classes;

Employee hank = new Employee(3, "Hank Hill", 300, DateTime.Parse("1/10/1995"));

hank.Name = "";
// generates warning:
//hank.Name = null;

var (_, n, sal, t) = hank;
Console.WriteLine($"{n} makes {sal:c} and has worked here {t} years");
Employee peg = new Employee(3, "Peggy Hill", 310, DateTime.Parse("12/1/2005"));

(n, t) = peg;
Console.WriteLine($"{n} has worked here {t} years");


//- null operators lab
//if (peg.HomePhone != null)
    Console.WriteLine(peg.HomePhone?.Substring(0, 3) ?? "no home phone");