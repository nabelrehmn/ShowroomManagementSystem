using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.DTOs
{
    public class CustomerDTO
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNumber { get; set; }
    }
}
