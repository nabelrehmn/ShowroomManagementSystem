using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotion service;
        public PromotionController(IPromotion service)
        {
            this.service = service;

        }

        [HttpGet("GetPromotion")]
        public async Task<string> GetPromotion()
        {
            return JsonConvert.SerializeObject(await service.GetPromotion());
        }

        [HttpPost("AddPromotion")]
        public async Task<string> AddPromotion(PromotionDTO promotionDTO)
        {
            return JsonConvert.SerializeObject(await service.AddPromotion(promotionDTO));
        }

        [HttpGet("DeletePromotion/{id}")]
        public async Task<string> DeletePromotion(int Id)
        {
            return JsonConvert.SerializeObject(await service.DeletePromotion(Id));
        }

        [HttpGet("GetPromotionById/{id}")]
        public async Task<string> GetPromotionById(int Id)
        {
            return JsonConvert.SerializeObject(await service.GetPromotionById(Id));
        }

        [HttpPost("UpdatePromotion")]
        public async Task<string> UpdatePromotion(PromotionDTO promotionDTO)
        {
            return JsonConvert.SerializeObject(await service.UpdatePromotion(promotionDTO));
        }
    }
}
