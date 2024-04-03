using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        public readonly IVehicle Service;
        public VehicleController(IVehicle _Service)
        {
            this.Service = _Service;
        }

        [HttpGet("GetVehicles")]
        public async Task<string> GetVehicles()
        {
            return JsonConvert.SerializeObject(await this.Service.GetVehicles());
        }

        [HttpPost("AddVehicle")]
        public async Task<string> AddVehicle([FromForm]VehicleDTO Vehicle)
        {
            return JsonConvert.SerializeObject(await this.Service.AddVehicle(Vehicle));
        }

        [HttpGet("GetVehicleById/{id}")]
        public async Task<string> GetVehicleById(int Id)
        {
            return JsonConvert.SerializeObject(await this.Service.GetVehicleById(Id));
        }

        [HttpGet("DeleteVehicle/{id}")]
        public async Task<string> DeleteVehicle(int Id)
        {
            return JsonConvert.SerializeObject(await this.Service.DeleteVehicle(Id));
        }

        [HttpPost("UpdateVehicle")]
        public async Task<string> UpdateVehicle([FromForm]VehicleDTO VehicleDTO)
        {
            return JsonConvert.SerializeObject(await this.Service.UpdateVehicle(VehicleDTO));
        } 
    }
}
