using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.DTOs
{
    public class PromotionDTO
    {
      
        public int PromotionID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int IsActive { get; set; }
    }
}
