using EmployeeDetail = (int id, string name, float ytdEarnings);
namespace TuplesLab;

internal class EmployeeService
{
    public EmployeeDetail GetEmployeeInfo(int id)
    {
        // Get employee info from database
        return (id, "John Doe", 10000.00f);
    }
}
