using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignCustomerSegmentMappingController : ControllerBase
    {
        private readonly ICampaignCustomerSegmentMapping service;
        public CampaignCustomerSegmentMappingController(ICampaignCustomerSegmentMapping service)
        {
            this.service = service;

        }

        [HttpGet("GetCampaignCustomerSegment")]
        public async Task<string> GetCampaignCustomerSegment()
        {
            return JsonConvert.SerializeObject(await service.GetCampaignCustomerSegment());
        }

        [HttpPost("AddCampaignCustomerSegment")]
        public async Task<string> AddCampaignCustomerSegment(CampaignCustomerSegmentMappingDTO campaignCustomerSegmentMappingDTO)
        {
            return JsonConvert.SerializeObject(await service.AddCampaignCustomerSegment(campaignCustomerSegmentMappingDTO));
        }

        [HttpGet("DeleteCampaignCustomerSegment/{id}")]
        public async Task<string> DeleteCampaignCustomerSegment(int Id)
        {
            return JsonConvert.SerializeObject(await service.DeleteCampaignCustomerSegment(Id));
        }

        [HttpGet("GetCampaignCustomerSegmentById/{id}")]
        public async Task<string> GetCampaignCustomerSegmentById(int Id)
        {
            return JsonConvert.SerializeObject(await service.GetCampaignCustomerSegmentById(Id));
        }

        [HttpPost("UpdateCampaignCustomerSegment")]
        public async Task<string> UpdateCampaignCustomerSegment(CampaignCustomerSegmentMappingDTO campaignCustomerSegmentMappingDTO)
        {
            return JsonConvert.SerializeObject(await service.UpdateCampaignCustomerSegment(campaignCustomerSegmentMappingDTO));
        }

    }
}
