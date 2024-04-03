using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models.Marketing_Promotion_Module
{
    public class CampaignCustomerSegmentMappingModel : ICampaignCustomerSegmentMapping
    {
        private readonly ApplicationDbContext context;

        public CampaignCustomerSegmentMappingModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDTO> AddCampaignCustomerSegment(CampaignCustomerSegmentMappingDTO campaignCustomerSegmentMappingDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var CampaignCustomerSegmentMapping = new CampaignCustomerSegmentMapping()
                {
                    FKCampaignID = campaignCustomerSegmentMappingDTO.FKCampaignID,
                    FKSegmentID = campaignCustomerSegmentMappingDTO.FKSegmentID

                };
                await context.CampaignCustomerSegmentMappings.AddAsync(CampaignCustomerSegmentMapping);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "CampaignCustomerSegmentMapping Inserted Successfully";
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> DeleteCampaignCustomerSegment(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.CampaignCustomerSegmentMappings.Where(x => x.MappingCustomerSegmentID == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    context.CampaignCustomerSegmentMappings.Remove(data);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "CampaignCustomerSegmentMappings Deleted";
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

        public async Task<ResponseDTO> GetCampaignCustomerSegment()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await context.CampaignCustomerSegmentMappings.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetCampaignCustomerSegmentById(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.CampaignCustomerSegmentMappings.Where(x => x.MappingCustomerSegmentID == Id).FirstOrDefaultAsync();
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

        public async Task<ResponseDTO> UpdateCampaignCustomerSegment(CampaignCustomerSegmentMappingDTO campaignCustomerSegmentMappingDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {

                var CampaignCustomerSegmentMapping = new CampaignCustomerSegmentMapping()
                {
                    MappingCustomerSegmentID = campaignCustomerSegmentMappingDTO.MappingCustomerSegmentID,
                    FKCampaignID = campaignCustomerSegmentMappingDTO.FKCampaignID,
                    FKSegmentID = campaignCustomerSegmentMappingDTO.FKSegmentID
                   
                };
                context.CampaignCustomerSegmentMappings.Update(CampaignCustomerSegmentMapping);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "CampaignCustomerSegmentMapping Updated";

            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
