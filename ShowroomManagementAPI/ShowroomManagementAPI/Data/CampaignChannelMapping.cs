using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowroomManagmentAPI.Data
{
    public class CampaignChannelMapping
    {
        [Key]
        public int MappingID { get; set; }
        [ForeignKey("Campaign")]
        public int FKCampaignID { get; set; }
        [ForeignKey("Channel")]
        public int FKChannelID { get; set; }

        public Campaign Campaign { get; set; }
        public Channel Channel { get; set; }

    }
}
