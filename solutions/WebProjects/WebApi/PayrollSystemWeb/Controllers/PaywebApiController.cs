
using Microsoft.AspNetCore.Mvc;
using PayrollSystemLib;

namespace PayrollSystemWeb.API;

[Route("api/[controller]")]
[ApiController]
public class PaywebApiController : ControllerBase
{
    [HttpGet]
    public string SayHello()
    {
        return "Hello from PaywebApiController";
    }

    [Route("payall/{id}")]
    [HttpPost]
    public double PayAll(int id, IPayrollService svc)
    {
        return svc.PayAll(id);
    }
}