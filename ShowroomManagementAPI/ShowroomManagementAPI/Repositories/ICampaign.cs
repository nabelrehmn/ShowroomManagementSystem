using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface ICampaign
    {
        public Task<ResponseDTO> GetCampaign();
        public Task<ResponseDTO> AddCampaign(CampaignDTO campaignDTO);
        public Task<ResponseDTO> DeleteCampaign(int Id);
        public Task<ResponseDTO> GetCampaignById(int Id);
        public Task<ResponseDTO> UpdateCampaign(CampaignDTO campaignDTO);
    }
}
