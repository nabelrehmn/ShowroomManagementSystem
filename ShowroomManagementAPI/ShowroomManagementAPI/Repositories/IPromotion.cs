using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface IPromotion
    {
        public Task<ResponseDTO> GetPromotion();
        public Task<ResponseDTO> AddPromotion(PromotionDTO promotionDTO);
        public Task<ResponseDTO> DeletePromotion(int Id);
        public Task<ResponseDTO> GetPromotionById(int Id);
        public Task<ResponseDTO> UpdatePromotion(PromotionDTO promotionDTO);
    }
}
