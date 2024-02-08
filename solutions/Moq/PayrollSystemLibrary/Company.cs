namespace PayrollSystemLib;

public interface IPayable
{
    public string FullName { get; }
    public double Pay();
}

public class Company
{
    private List<IPayable> _payables;
    public Company(string name, string taxId, string address)
    {
        Name = name;
        TaxId = taxId;
        Address = address;
        _payables = new List<IPayable>();
    }

    public string Name { get; set; }
    public string TaxId { get; set; }
    public string Address { get; set; }
    public IEnumerable<IPayable> Payables => _payables;

    public void Hire(IPayable payable) => _payables.Add(payable);

    public double Pay() => _payables.Sum(p => p.Pay());
}