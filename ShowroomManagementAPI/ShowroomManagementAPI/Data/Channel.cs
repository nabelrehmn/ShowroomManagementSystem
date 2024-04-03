using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.Data
{
    public class Channel
    {
        [Key]
        public int ChannelID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
