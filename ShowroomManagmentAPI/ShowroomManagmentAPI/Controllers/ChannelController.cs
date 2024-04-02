using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannel service;
        public ChannelController(IChannel service)
        {
            this.service = service;

        }
        [HttpGet("GetChannel")]
        public async Task<string> GetChannel()
        {
            return JsonConvert.SerializeObject(await service.GetChannel());
        }
        [HttpPost("AddChannel")]
        public async Task<string> AddChannel(ChannelDTO channelDTO)
        {
            return JsonConvert.SerializeObject(await service.AddChannel(channelDTO));
        }

        [HttpGet("DeleteChannel/{id}")]
        public async Task<string> DeleteChannel(int Id)
        {
            return JsonConvert.SerializeObject(await service.DeleteChannel(Id));
        }

        [HttpGet("GetChannelById/{id}")]
        public async Task<string> GetChannelById(int Id)
        {
            return JsonConvert.SerializeObject(await service.GetChannelById(Id));
        }

        [HttpPost("UpdateChannel")]
        public async Task<string> UpdateChannel(ChannelDTO channelDTO)
        {
            return JsonConvert.SerializeObject(await service.UpdateChannel(channelDTO));
        }
    }
}
