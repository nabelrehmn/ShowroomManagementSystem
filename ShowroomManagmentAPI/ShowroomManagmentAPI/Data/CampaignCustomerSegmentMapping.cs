using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.Data
{
    public class CampaignCustomerSegmentMapping
    {
        [Key]
        public int MappingCustomerSegmentID { get; set; }
        [ForeignKey("Campaign")]
        public int FKCampaignID { get; set; }
        [ForeignKey("CustomerSegment")]
        public int FKSegmentID { get; set; }

        public Campaign Campaign { get; set; }
        public CustomerSegment CustomerSegment { get; set; }
    }
}
