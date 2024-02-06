## Overview 

| | |
| --------- | --------------------------- |
| Exercise Folder | Deconstruction |
| Builds On | Records |
| Time to complete | 15 minutes

---

### Part 1

Continue with the same project.
1. In main, declare individual variables to hold the deconstructed tuple/record.
1. Try different combinations of declared and new variables
1. Try a placeholder to discard an unneeded value
---
### Part 2
1. Create a new class named Employee
1. Add this code to the class
```C#
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
    public int Tenure
    {
        get
        {
            var years = DateTime.Today.Year - Hiredate.Year;
            if (DateTime.Today.DayOfYear < Hiredate.DayOfYear) years--;
            return years;
        }
    }
}
```

1. Define 2 overloaded deconstructors 
    - (id, name, salary, tenure)
    - (name, tenure)
1. Update Program.cs to test 

---

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/Deconstruction) 

---
<br/>
<br/>
<br/>
<br/>

*Want More?*

<iframe width="560" height="315" src="https://www.youtube.com/embed/_T7utEXlxy4?si=dXP6TvbNTeP8JM9v" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>