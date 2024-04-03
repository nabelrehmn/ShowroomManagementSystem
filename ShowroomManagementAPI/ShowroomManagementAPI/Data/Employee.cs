using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowroomManagmentAPI.Data
{
    public class Employee
    {
        [Key]
        public int PkId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cnic { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string ProfileImagePath { get; set; }
        [ForeignKey("Department")]
        public int FKDepartment { get; set; }
        [ForeignKey("Role")]
        public int FKRole { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }

    }
}
