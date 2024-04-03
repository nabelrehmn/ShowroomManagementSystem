using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models.Marketing_Promotion_Module
{
    public class ChannelModel : IChannel
    {
        private readonly ApplicationDbContext context;

        public ChannelModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ResponseDTO> AddChannel(ChannelDTO channelDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Channel = new Channel()
                {
                    Name = channelDTO.Name,
                    Description = channelDTO.Description,


                };
                await context.Channels.AddAsync(Channel);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Channel Inserted Successfully";
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> DeleteChannel(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.Channels.Where(x => x.ChannelID == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    context.Channels.Remove(data);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "Channel Deleted";
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

        public async Task<ResponseDTO> GetChannel()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await context.Channels.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetChannelById(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.Channels.Where(x => x.ChannelID == Id).FirstOrDefaultAsync();
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

        public async Task<ResponseDTO> UpdateChannel(ChannelDTO channelDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {

                var Channel = new Channel()
                {
                    ChannelID = channelDTO.ChannelID,
                    Name = channelDTO.Name,
                    Description = channelDTO.Description,
                 
                };
                context.Channels.Update(Channel);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Channel Updated";

            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
