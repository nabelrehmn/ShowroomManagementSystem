using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface ICustomer
    {
        public Task<ResponseDTO> GetCustomers();

        public Task<ResponseDTO> AddCustomer(CustomerDTO CustomerDTO);

        public Task<ResponseDTO> GetCustomerById(int Id);

        public Task<ResponseDTO> DeleteCustomer(int Id);

        public Task<ResponseDTO> UpdateCustomer(CustomerDTO CustomerDTO);
    }
}
