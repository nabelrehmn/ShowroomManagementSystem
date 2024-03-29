using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface ICustomer
    {
        public Task<ResponseDTO> GetCustomers();
    }
}
