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
        public string? HomePhone { get; set; }
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
