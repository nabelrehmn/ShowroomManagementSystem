using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.DTOs
{
    public class CustomerSegmentDTO
    {

        public int SegmentID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
