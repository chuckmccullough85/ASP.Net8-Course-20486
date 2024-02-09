namespace PayrollSystemLib;

public class Employee : Payable
{
    public Employee()  {}

    public Employee(string name, double salary, DateTime hiredate)
    {
        FirstName = name;
        LastName = "";
        Salary = salary;
        Hiredate = hiredate;
    }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public override string FullName => $"{FirstName} {LastName}";
    public double Salary { get; set; }
    public DateTime Hiredate { get; init; }
    public string? HomePhone { get; set; }
    public int Tenure
    {
        get
        {
            var years = DateTime.Today.Year - Hiredate.Year;
            if (DateTime.Today.DayOfYear < Hiredate.DayOfYear) years--;
            return years;
        }
    }
    public double YTDEarnings { get; private set; }

    public override double Pay()
    {
        var tax = Salary * .0765f;
        YTDEarnings += Salary;
        return Salary - tax;
    }
    public void Deconstruct(out int id, out string name, out double salary, out int tenure)
    {
        id = Id; name = FirstName; salary = Salary; tenure = Tenure;
    }
    public void Deconstruct(out string name, out int tenure) => (_, name, _, tenure) = this;

    public override string ToString()
        => $"{FullName} has worked here {Tenure} years";

    public override bool Equals(object? obj) => obj is Employee employee &&
               Id == employee.Id &&
               FirstName == employee.FirstName &&
               LastName == employee.LastName;

    public override int GetHashCode()
        => HashCode.Combine(Id, FirstName, LastName);
}