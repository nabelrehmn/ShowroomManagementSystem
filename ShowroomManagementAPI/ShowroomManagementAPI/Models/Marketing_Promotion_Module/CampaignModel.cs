using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models.Marketing_Promotion_Module
{
    public class CampaignModel : ICampaign
    {
        private readonly ApplicationDbContext context;

        public CampaignModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ResponseDTO> AddCampaign(CampaignDTO campaignDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Campaign = new Campaign()
                {
                    Name = campaignDTO.Name,
                    Description = campaignDTO.Description,
                    StartDate = campaignDTO.StartDate,
                    EndDate = campaignDTO.EndDate

                };
                await context.Campaign.AddAsync(Campaign);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Campaign Inserted Successfully";
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> DeleteCampaign(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.Campaign.Where(x => x.CampaignID == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    context.Campaign.Remove(data);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "Campaign Deleted";
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

        public async Task<ResponseDTO> GetCampaign()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await context.Campaign.ToListAsync() ;
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetCampaignById(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.Campaign.Where(x => x.CampaignID == Id).FirstOrDefaultAsync();
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

        public async Task<ResponseDTO> UpdateCampaign(CampaignDTO campaignDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try { 
            
                var campaign = new Campaign()
                {
                    CampaignID = campaignDTO.CampaignID,
                    Name = campaignDTO.Name,
                    Description = campaignDTO.Description,
                    StartDate = campaignDTO.StartDate,
                    EndDate = campaignDTO.EndDate,
                };
                context.Campaign.Update(campaign);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Campaign Updated";

            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
