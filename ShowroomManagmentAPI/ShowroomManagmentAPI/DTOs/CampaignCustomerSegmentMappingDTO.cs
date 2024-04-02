namespace ShowroomManagmentAPI.DTOs
{
    public class CampaignCustomerSegmentMappingDTO
    {
        public int MappingCustomerSegmentID { get; set; }
        public int FKCampaignID { get; set; }
        public int FKSegmentID { get; set; }
    }
}
