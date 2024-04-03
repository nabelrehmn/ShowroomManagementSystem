using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.DTOs
{
    public class ChannelDTO
    {

        public int ChannelID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
