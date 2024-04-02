using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models.Marketing_Promotion_Module
{
    public class CampaignChannelMappingModel : ICampaignChannelMapping
    {
        private readonly ApplicationDbContext context;

        public CampaignChannelMappingModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDTO> AddCampaignChannel(CampaignChannelMappingDTO campaignChannelMappingDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var campaignchannelMapping = new CampaignChannelMapping()
                {
                    FKCampaignID = campaignChannelMappingDTO.FKCampaignID,
                    FKChannelID = campaignChannelMappingDTO.FKChannelID

                };
                await context.CampaignChannelMappings.AddAsync(campaignchannelMapping);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "CampaignChannelMappings Inserted Successfully";
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> DeleteCampaignChannel(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.CampaignChannelMappings.Where(x => x.MappingID == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    context.CampaignChannelMappings.Remove(data);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "CampaignChannelMappings Deleted";
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

        public async Task<ResponseDTO> GetCampaignChannel()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await context.CampaignChannelMappings.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetCampaignChannelById(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.CampaignChannelMappings.Where(x => x.MappingID == Id).FirstOrDefaultAsync();
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

        public async Task<ResponseDTO> UpdateCampaignChannel(CampaignChannelMappingDTO campaignChannelMappingDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {

                var campaignchannelMapping = new CampaignChannelMapping()
                {
                    MappingID = campaignChannelMappingDTO.MappingID,
                    FKCampaignID = campaignChannelMappingDTO.FKCampaignID,
                    FKChannelID = campaignChannelMappingDTO.FKChannelID

                };
                context.CampaignChannelMappings.Update(campaignchannelMapping);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "campaignchannelMapping Updated";

            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
