using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomer Service;

        public CustomerController(ICustomer _Service)
        {
            this.Service = _Service;
        }

        [HttpGet("GetCustomers")]
        public async Task<string> GetCustomers()
        {
            return JsonConvert.SerializeObject(await this.Service.GetCustomers());
        }
    }
}
