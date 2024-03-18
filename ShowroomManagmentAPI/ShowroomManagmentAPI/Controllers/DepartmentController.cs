using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositorys;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment service;
        public DepartmentController(IDepartment service)
        {
            this.service = service;
        }
        [HttpGet("GetDepartments")]
        public async Task<string> GetDepartments()
        {
            return JsonConvert.SerializeObject(await service.GetDepartments());
        }
        [HttpPost("AddDepartment")]
        public async Task<string> AddDepartment(DepartmentDTO departmentDTO)
        {
            return JsonConvert.SerializeObject(await service.AddDepartment(departmentDTO));
        }
        [HttpGet("DeleteDepartment/{id}")]
        public async Task<string> DeleteDepartment(int Id)
        {
            return JsonConvert.SerializeObject(await service.DeleteDepartment(Id));
        }
        [HttpGet("GetDepartmentById/{id}")]
        public async Task<string> GetEmployeeById(int Id)
        {
            return JsonConvert.SerializeObject(await service.GetDepartmentById(Id));
        }
        [HttpPost("UpdateDepartment")]
        public async Task<string> UpdateDepartment(DepartmentDTO departmentDTO)
        {
           return JsonConvert.SerializeObject(await service.UpdateDepartment(departmentDTO));
        }



    }
}
