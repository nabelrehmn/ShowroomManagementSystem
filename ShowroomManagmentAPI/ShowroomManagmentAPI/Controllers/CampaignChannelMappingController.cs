using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignChannelMappingController : ControllerBase
    {
        private readonly ICampaignChannelMapping service;
        public CampaignChannelMappingController(ICampaignChannelMapping service)
        {
            this.service = service;

        }

        [HttpGet("GetCampaignChannel")]
        public async Task<string> GetCampaignChannel()
        {
            return JsonConvert.SerializeObject(await service.GetCampaignChannel());
        }

        [HttpPost("AddCampaignChannel")]
        public async Task<string> AddCampaignChannel(CampaignChannelMappingDTO campaignChannelMappingDTO)
        {
            return JsonConvert.SerializeObject(await service.AddCampaignChannel(campaignChannelMappingDTO));
        }

        [HttpGet("DeleteCampaignChannel/{id}")]
        public async Task<string> DeleteCampaignChannel(int Id)
        {
            return JsonConvert.SerializeObject(await service.DeleteCampaignChannel(Id));
        }

        [HttpGet("GetCampaignChannelById/{id}")]
        public async Task<string> GetCampaignChannelById(int Id)
        {
            return JsonConvert.SerializeObject(await service.GetCampaignChannelById(Id));
        }

        [HttpPost("UpdateCampaignChannel")]
        public async Task<string> UpdateCampaignChannel(CampaignChannelMappingDTO campaignChannelMappingDTO)
        {
            return JsonConvert.SerializeObject(await service.UpdateCampaignChannel(campaignChannelMappingDTO));
        }

    }
}
