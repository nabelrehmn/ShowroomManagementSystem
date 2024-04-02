using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaign service;
        public CampaignController(ICampaign service)
        {
            this.service = service;
            
        }

        [HttpGet("GetCampaign")]
        public async Task<string> GetCampaign()
        {
            return JsonConvert.SerializeObject(await service.GetCampaign());
        }

        [HttpPost("AddCampaign")]
        public async Task<string> AddCampaign(CampaignDTO campaignDTO)
        {
            return JsonConvert.SerializeObject(await service.AddCampaign(campaignDTO));
        }

        [HttpGet("DeleteCampaign/{id}")]
        public async Task<string> DeleteCampaign(int Id)
        {
            return JsonConvert.SerializeObject(await service.DeleteCampaign(Id));
        }

        [HttpGet("GetCampaignById/{id}")]
        public async Task<string> GetCampaignById(int Id)
        {
            return JsonConvert.SerializeObject(await service.GetCampaignById(Id));
        }

        [HttpPost("UpdateCampaign")]
        public async Task<string> UpdateCampaign(CampaignDTO campaignDTO)
        {
            return JsonConvert.SerializeObject(await service.UpdateCampaign(campaignDTO));
        }
    }
}
