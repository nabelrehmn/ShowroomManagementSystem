using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositorys
{
    public interface IEmployee
    {
        public Task<ResponseDTO> GetEmployee();
        public Task<ResponseDTO> AddEmployee(EmployeeDTO employeeDTO);
        public Task<ResponseDTO> GetEmployeeById(int id);
        public Task<ResponseDTO> DeleteEmployee(int id);
        public Task<ResponseDTO> UpdateEmployee(EmployeeDTO employeeDTO);
    }
}
