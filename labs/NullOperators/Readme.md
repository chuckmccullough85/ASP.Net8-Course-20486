## Overview

| | |
| --------- | --------------------------- |
| Exercise Folder | NullOperator |
| Builds On | Deconstruction |
| Time to complete | 15 minutes

---
Continue with Deconstruction exercise. 

Reference types can be null, of course.  The question is should a reference be null.  For instance, an employee name shouldn't be null.  What about home phone number?
Add a string property to the Employee class named HomePhone.  Notice the warning on the constructor.  What does that mean?  How to correct it?

In program, assuming you have an employee variable named joe, add this line of code:

```C#
Console.WriteLine(joe.HomePhone.Substring(0, 3));
```
What if joe is null?  What if HomePhone is null?

Change the expression to provide an alternative value if phone is null.

For example:
```c#
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
public string? HomePhone { get; set; }  // HomePhone allowed to be null

override public string ToString()
{
		// shouldn't need to worry about name being null, but homephone could be!
    return $"Employee {Id} is {Name.ToUpper()} with salary {Salary} phone: {HomePhone?.Trim()}";
}

```

---

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/NullOperators)