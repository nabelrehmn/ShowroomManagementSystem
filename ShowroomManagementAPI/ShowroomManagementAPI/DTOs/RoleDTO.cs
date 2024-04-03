namespace ShowroomManagmentAPI.DTOs
{
    public class RoleDTO
    {
        public int PkId { get; set; }
        public string RoleName { get; set; }
        public string? Description { get; set; }
        public string Permissions { get; set; }
    }
}
