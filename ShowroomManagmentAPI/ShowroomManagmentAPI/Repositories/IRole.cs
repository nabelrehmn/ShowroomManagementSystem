using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface IRole
    {
        public Task<ResponseDTO> GetRoles();
        public Task<ResponseDTO> AddRole(RoleDTO roleDTO);
        public Task<ResponseDTO> GetRoleById(int id);
        public Task<ResponseDTO> DeleteRole(int id);
        public Task<ResponseDTO> UpdateRole(RoleDTO roleDTO);
    }
}
