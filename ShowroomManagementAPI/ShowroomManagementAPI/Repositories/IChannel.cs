using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface IChannel
    {
        public Task<ResponseDTO> GetChannel();
        public Task<ResponseDTO> AddChannel(ChannelDTO channelDTO);
        public Task<ResponseDTO> DeleteChannel(int Id);
        public Task<ResponseDTO> GetChannelById(int Id);
        public Task<ResponseDTO> UpdateChannel(ChannelDTO channelDTO);
    }
}
