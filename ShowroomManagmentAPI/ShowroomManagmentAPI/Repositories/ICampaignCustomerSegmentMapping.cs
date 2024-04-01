using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface ICampaignCustomerSegmentMapping
    {
        public Task<ResponseDTO> GetCampaignCustomerSegment();
        public Task<ResponseDTO> AddCampaignCustomerSegment(CampaignCustomerSegmentMappingDTO campaignCustomerSegmentMappingDTO);
        public Task<ResponseDTO> GetCampaignCustomerSegmentById(int Id);
        public Task<ResponseDTO> UpdateCampaignCustomerSegment(CampaignCustomerSegmentMappingDTO campaignCustomerSegmentMappingDTO);
        public Task<ResponseDTO> DeleteCampaignCustomerSegment(int Id);
    }
}
