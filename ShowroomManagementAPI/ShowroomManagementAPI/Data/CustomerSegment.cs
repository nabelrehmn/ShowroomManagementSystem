using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.Data
{
    public class CustomerSegment
    {
        [Key]
        public int SegmentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
