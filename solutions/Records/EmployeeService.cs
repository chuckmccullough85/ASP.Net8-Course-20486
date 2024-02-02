
namespace RecordsLab;

internal record EmployeeInfo (int Id, string Name, float YtdEarnings);
internal class EmployeeService
{
    public EmployeeInfo GetEmployeeInfo(int id)
    {
        // Get employee info from database
        return new EmployeeInfo(id, "John Doe", 10000.00f);
    }
}
