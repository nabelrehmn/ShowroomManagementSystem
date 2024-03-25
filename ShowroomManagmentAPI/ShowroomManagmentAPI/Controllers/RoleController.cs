using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositorys;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole service;
        public RoleController(IRole role)
        {
            this.service = role;
        }

        [HttpGet("GetRoles")]
        public async Task<string> GetRoles()
        {
            return JsonConvert.SerializeObject(await service.GetRoles());
        }
        [HttpPost("AddRole")]
        public async Task<string> AddRole(RoleDTO roleDTO)
        {
            return JsonConvert.SerializeObject(await service.AddRole(roleDTO));
        }
        [HttpGet("GetRoleById/{id}")]
        public async Task<string> GetRoleById(int id)
        {
            return JsonConvert.SerializeObject(await service.GetRoleById(id));
        }
        [HttpGet("DeleteRole/{id}")]
        public async Task<string> DeleteRole(int id)
        {
            return JsonConvert.SerializeObject(await service.DeleteRole(id));
        }
        [HttpPost("UpdateRole")]
        public async Task<string> UpdateRole(RoleDTO roleDTO)
        {
            return JsonConvert.SerializeObject(await service.UpdateRole(roleDTO));
        }
    }
}
