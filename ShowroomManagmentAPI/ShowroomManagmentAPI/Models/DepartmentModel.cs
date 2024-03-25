    using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositorys;

namespace ShowroomManagmentAPI.Models
{
    public class DepartmentModel : IDepartment
    {
        private readonly ApplicationDbContext context;
        public DepartmentModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDTO> GetDepartments()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> AddDepartment(DepartmentDTO departmentDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var department = new Department()
                {
                    Name = departmentDTO.Name,
                    Description = departmentDTO.Description,
                };
                await context.Departments.AddAsync(department);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Department Inserted Successfully";
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> DeleteDepartment(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.Departments.Where(x => x.PkId == Id).FirstOrDefaultAsync();
                if(data != null)
                {
                    context.Departments.Remove(data);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "Department Deleted";
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetDepartmentById(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var data = await context.Departments.Where(x => x.PkId == Id).FirstOrDefaultAsync();
                if(data != null)
                {
                    ResponseDTO.Response = data;
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage= ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> UpdateDepartment(DepartmentDTO departmentDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                //var data = await context.Departments.Where(x => x.PkId == departmentDTO.Id).FirstOrDefaultAsync();
                //if(data != null)
                //{
                //}
                //else
                //{
                //    ResponseDTO.StatusCode = 404;
                //}
                    var department = new Department()
                    {
                    PkId = departmentDTO.PkId,
                    Name = departmentDTO.Name,
                    Description = departmentDTO.Description,
                    };
                    context.Departments.Update(department);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "Department Updated";

            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}

