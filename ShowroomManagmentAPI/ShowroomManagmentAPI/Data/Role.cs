using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.Data
{
    public class Role
    {
        [Key]
        public int PkId { get; set; }
        public string RollName { get; set; }
        public string? Description { get; set; }
        public string permissions { get; set; }
    }
}
