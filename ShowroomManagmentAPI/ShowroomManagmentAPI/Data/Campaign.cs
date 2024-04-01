using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.Data
{
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

       
        public DateTime StartDate { get; set; }

       
        public DateTime EndDate { get; set; }
    }
}
