using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.Data
{
    public class Department
    {
        [Key]
        public int PkId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
