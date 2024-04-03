using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface ICampaignChannelMapping
    {
        public Task<ResponseDTO> GetCampaignChannel();
        public Task<ResponseDTO> AddCampaignChannel(CampaignChannelMappingDTO campaignChannelMappingDTO);
        public Task<ResponseDTO> GetCampaignChannelById(int Id);
        public Task<ResponseDTO> UpdateCampaignChannel(CampaignChannelMappingDTO campaignChannelMappingDTO);
        public Task<ResponseDTO> DeleteCampaignChannel(int Id);
    }
}
