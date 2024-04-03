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

        public async Task<ResponseDTO> AddCustomer(CustomerDTO CustomerDTO)
        {
            var Response = new ResponseDTO();

            try
            {
                var Customer = new Customer()
                {
                    Name = CustomerDTO.Name,
                    IdentificationNumber = CustomerDTO.IdentificationNumber,
                    Email = CustomerDTO.Email,
                    Address = CustomerDTO.Address,
                    ContactNumber = CustomerDTO.ContactNumber
                };

                Context.Customers.Add(Customer);
                await Context.SaveChangesAsync();
                Response.Response = "Customer has been Inserted";
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> GetCustomerById(int Id)
        {
            var Response = new ResponseDTO();

            try
            {
                var Data = await Context.Customers.Where(x=>x.CustomerId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    Response.Response = Data;
                }
                else
                {
                    Response.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> DeleteCustomer(int Id)
        {
            var Response = new ResponseDTO();

            try
            {
                var Data = await Context.Customers.Where(x=>x.CustomerId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    Context.Customers.Remove(Data);
                    await Context.SaveChangesAsync();
                    Response.Response = "Customer has been Deleted";
                }
                else
                {
                    Response.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> UpdateCustomer(CustomerDTO CustomerDTO)
        {
            var Response = new ResponseDTO();

            try
            {
                var Customer = new Customer()
                {
                    Name = CustomerDTO.Name,
                    IdentificationNumber = CustomerDTO.IdentificationNumber,
                    Email = CustomerDTO.Email,
                    Address = CustomerDTO.Address,
                    ContactNumber = CustomerDTO.ContactNumber
                };

                Context.Customers.Update(Customer);
                await Context.SaveChangesAsync();
                Response.Response = "Customer has been Updated";
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }
    }
}
