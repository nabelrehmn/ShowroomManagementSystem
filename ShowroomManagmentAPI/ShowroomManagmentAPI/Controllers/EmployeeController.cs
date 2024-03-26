using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositorys;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee service;
        public EmployeeController(IEmployee employee)
        {
            this.service = employee;
        }

        [HttpGet("GetEmployee")]
        public async Task<string> GetEmployee()
        {
            return JsonConvert.SerializeObject(await this.service.GetEmployee());
        }
        [HttpPost("AddEmployee")]
        public async Task<string> AddEmployee([FromForm]EmployeeDTO employeeDTO)
        {
            return JsonConvert.SerializeObject(await this.service.AddEmployee(employeeDTO));
        }
        [HttpGet("GetEmployeeById/{id}")]
        public async Task<string> GetEmployeeById(int id)
        {
            return JsonConvert.SerializeObject(await this.service.GetEmployeeById(id));
        }
        [HttpGet("DeleteEmployee/{id}")]
        public async Task<string> DeleteEmployee(int id)
        {
            return JsonConvert.SerializeObject(await this.service.DeleteEmployee(id));
        }
        [HttpPost("UpdateEmployee")]
        public async Task<string> UpdateEmployee([FromForm]EmployeeDTO employeeDTO)
        {
            return JsonConvert.SerializeObject(await this.service.UpdateEmployee(employeeDTO));
        }
    }
}
