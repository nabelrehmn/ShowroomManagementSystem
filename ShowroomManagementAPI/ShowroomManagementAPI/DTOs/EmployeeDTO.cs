using ShowroomManagmentAPI.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowroomManagmentAPI.DTOs
{
    public class EmployeeDTO
    {
        public int PkId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cnic { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public IFormFile ProfileImagePath { get; set; }
        public int FKDepartment { get; set; }
        public int FKRole { get; set; }
    }
}
