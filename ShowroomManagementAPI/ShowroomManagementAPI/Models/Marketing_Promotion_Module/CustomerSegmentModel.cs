using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models.Marketing_Promotion_Module
{
    public class CustomerSegmentModel : ICustomer_segment
    {
        private readonly ApplicationDbContext context;

        public CustomerSegmentModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ResponseDTO> AddSegment(CustomerSegmentDTO customerSegmentDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var CustomerSegment = new CustomerSegment()
                {
                    Name = customerSegmentDTO.Name,
                    Description = customerSegmentDTO.Description,


                };
                await context.CustomerSegments.AddAsync(CustomerSegment);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Customer Segment Inserted Successfully";
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> DeleteSegment(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.CustomerSegments.Where(x => x.SegmentID == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    context.CustomerSegments.Remove(data);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "Customer Segment Deleted";
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetSegment()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await context.CustomerSegments.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetSegmentById(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.CustomerSegments.Where(x => x.SegmentID == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    ResponseDTO.Response = data;
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> UpdateSegment(CustomerSegmentDTO customerSegmentDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var customerSegment = new CustomerSegment()
                {
                    SegmentID = customerSegmentDTO.SegmentID,
                    Name = customerSegmentDTO.Name,
                    Description = customerSegmentDTO.Description,

                };
                context.CustomerSegments.Update(customerSegment);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "CUstomer Segment Updated";

            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
