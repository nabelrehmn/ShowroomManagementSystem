using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models.Marketing_Promotion_Module
{
    public class PromotionModel : IPromotion
    {
        private readonly ApplicationDbContext context;

        public PromotionModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDTO> AddPromotion(PromotionDTO promotionDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var promotion = new Promotion()
                {
                    Name = promotionDTO.Name,
                    Description = promotionDTO.Description,
                    StartDate = promotionDTO.StartDate,
                    EndDate = promotionDTO.EndDate,
                    IsActive = promotionDTO.IsActive,
                };
                await context.Promotions.AddAsync(promotion);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Promotion Inserted Successfully";
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> DeletePromotion(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.Promotions.Where(x => x.PromotionID == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    context.Promotions.Remove(data);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "Promotion Deleted";
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetPromotion()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await context.Promotions.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetPromotionById(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.Promotions.Where(x => x.PromotionID == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    ResponseDTO.Response = data;
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> UpdatePromotion(PromotionDTO promotionDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {

                var promotion = new Promotion()
                {
                    PromotionID = promotionDTO.PromotionID,
                    Name = promotionDTO.Name,
                    Description = promotionDTO.Description,
                    StartDate = promotionDTO.StartDate,
                    EndDate = promotionDTO.EndDate,
                    IsActive = promotionDTO.IsActive
                };
                context.Promotions.Update(promotion);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Promotion Updated";

            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
