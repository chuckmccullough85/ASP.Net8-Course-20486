namespace PayrollSystemLib;

public abstract class Payable
{
    public int Id { get; set; }
    public abstract string FullName { get; }
    public abstract double Pay();
}

public class Company
{
    public Company()  { }
    public Company(string name, string taxId, string address)
    {
        Name = name;
        TaxId = taxId;
        Address = address;
        Payables = new List<Payable>();
    }
    public int Id { get; set; }
    public string Name { get; set; } ="";
    public string TaxId { get; set; } = "";
    public string Address { get; set; } = "";
    public virtual ICollection<Payable> Payables {get;set;} = new List<Payable>();

    public void Hire(Payable payable)
    {
        Payables.Add(payable);
    }

    public double Pay()
    {
        return Payables.Sum(p => p.Pay());
    }
}