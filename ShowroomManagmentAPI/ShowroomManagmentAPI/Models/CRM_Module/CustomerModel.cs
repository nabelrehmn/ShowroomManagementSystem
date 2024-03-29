using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models
{
    public class CustomerModel : ICustomer
    {
        public readonly ApplicationDbContext Context;
        
        public CustomerModel(ApplicationDbContext _Context)
        {
            this.Context = _Context;
        }

        public async Task<ResponseDTO> GetCustomers()
        {
            var Response = new ResponseDTO();

            try
            {
                Response.Response = await Context.Customers.ToListAsync();
            }
            catch(Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }
    }
}
