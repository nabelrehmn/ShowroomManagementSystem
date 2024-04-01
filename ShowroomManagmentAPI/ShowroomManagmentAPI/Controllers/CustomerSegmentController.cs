using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSegmentController : ControllerBase
    {
        private readonly ICustomer_segment service;
        public CustomerSegmentController(ICustomer_segment service)
        {
            this.service = service;

        }
        [HttpGet("GetSegment")]
        public async Task<string> GetSegment()
        {
            return JsonConvert.SerializeObject(await service.GetSegment());
        }
        [HttpPost("AddSegment")]
        public async Task<string> AddSegment(CustomerSegmentDTO customerSegmentDTO)
        {
            return JsonConvert.SerializeObject(await service.AddSegment(customerSegmentDTO));
        }

        [HttpGet("DeleteSegment/{id}")]
        public async Task<string> DeleteSegment(int Id)
        {
            return JsonConvert.SerializeObject(await service.DeleteSegment(Id));
        }

        [HttpGet("GetSegmentById/{id}")]
        public async Task<string> GetSegmentById(int Id)
        {
            return JsonConvert.SerializeObject(await service.GetSegmentById(Id));
        }

        [HttpPost("UpdateSegment")]
        public async Task<string> UpdateSegment(CustomerSegmentDTO customerSegmentDTO)
        {
            return JsonConvert.SerializeObject(await service.UpdateSegment(customerSegmentDTO));
        }
    }
}
