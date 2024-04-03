using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
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

        [HttpPost("AddCustomer")]
        public async Task<string> AddCustomer(CustomerDTO CustomerDTO)
        {
            return JsonConvert.SerializeObject(await this.Service.AddCustomer(CustomerDTO));
        }

        [HttpGet("GetCustomerById/{id}")]
        public async Task<string> GetCustomerById(int Id)
        {
            return JsonConvert.SerializeObject(await this.Service.GetCustomerById(Id));
        }

        [HttpGet("DeleteCustomer/{id}")]
        public async Task<string> DeleteCustomer(int Id)
        {
            return JsonConvert.SerializeObject(await this.Service.DeleteCustomer(Id));
        }

        [HttpPost("UpdateCustomer")]
        public async Task<string> UpdateCustomer(CustomerDTO CustomerDTO)
        {
            return JsonConvert.SerializeObject(await this.Service.UpdateCustomer(CustomerDTO));
        }
    }
}
