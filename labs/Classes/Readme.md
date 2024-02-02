## Overview

| | |
| --------- | --------------------------- |
| Exercise Folder | Classes |
| Builds On | NullOperator |
| Time to complete | 30 minutes

---
Continue with Null Operator exercise 

1. Create a new console application or continue with the previous lab
    - note replace Program & Employee with the code below so that you have the same starting point
2.  Revisit the Employee class 
3. Refactor **Name** to **FirstName**
4. Add a **LastName** property
5. Add a FullName property (read-only) as an expression property
6. Override inherited methods - Equals, GetHashCode, & ToString
7. Evaluate what properties should be nullable
8. Use expression methods/properties where possible

---

*Program.cs*
```c#
using Classes;

Employee hank = new Employee(3, "Hank Hill", 300, DateTime.Parse("1/10/1995"));
Employee hank2 = new Employee(3, "Hank Hill", 300, DateTime.Parse("1/10/1995"));
Employee peggy = new Employee(4, "Peggy Hill", 350, DateTime.Parse("1/10/1995"));

if (hank == hank2) Console.WriteLine("hank == hank2");
if (hank.Equals(hank2)) Console.WriteLine("hank.Equals(hank2)");

Console.WriteLine(hank.ToString());
Console.WriteLine(peggy);

Console.WriteLine(hank.GetHashCode());
Console.WriteLine(hank2.GetHashCode());
```



*Employee.cs*
```c#
namespace Classes
{
    public class Employee
    {
        public Employee(int id, string name, double salary, DateTime hiredate)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Hiredate = hiredate;
        }
        public int Id { get; init; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime Hiredate { get; init; }
        public string HomePhone { get; set; }
        public int Tenure
        {
            get
            {
                var years = DateTime.Today.Year - Hiredate.Year;
                if (DateTime.Today.DayOfYear < Hiredate.DayOfYear) years--;
                return years;
            }
        }

        public void Deconstruct(out int id, out string name, out double salary, out int tenure)
        {
            id = Id; name = Name; salary = Salary; tenure = Tenure;
        }
        public void Deconstruct(out string name, out int tenure)
        {
            (_, name, _, tenure) = this;
        }

    }
}
```

