namespace ShowroomManagmentAPI.DTOs
{
    public class CampaignChannelMappingDTO
    {
        public int MappingID { get; set; }
        public int FKCampaignID { get; set; }
        public int FKChannelID { get; set; }

    }
}
