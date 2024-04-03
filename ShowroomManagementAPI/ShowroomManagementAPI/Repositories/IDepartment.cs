using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface IDepartment
    {
        public Task<ResponseDTO> GetDepartments();
        public Task<ResponseDTO> AddDepartment(DepartmentDTO departmentDTO);
        public Task<ResponseDTO> DeleteDepartment(int Id);
        public Task<ResponseDTO> GetDepartmentById(int Id);
        public Task<ResponseDTO> UpdateDepartment(DepartmentDTO departmentDTO);
    }
}
