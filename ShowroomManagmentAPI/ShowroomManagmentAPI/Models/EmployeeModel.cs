using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositorys;

namespace ShowroomManagmentAPI.Models
{
    public class EmployeeModel : IEmployee
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EmployeeModel(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseDTO> GetEmployee()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
               ResponseDTO.Response = await context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
        
        public async Task<ResponseDTO> AddEmployee(EmployeeDTO employeeDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var path = "";
                if(employeeDTO.ProfileImagePath != null)
                {
                    var FileName = employeeDTO.ProfileImagePath.FileName;
                    path = Path.Combine("Upload", webHostEnvironment.WebRootPath + FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await employeeDTO.ProfileImagePath.CopyToAsync(stream);
                    }
                }

                var Employee = new Employee()
                {
                    Name = employeeDTO.Name,
                    Email = employeeDTO.Email,
                    Cnic = employeeDTO.Cnic,
                    Address = employeeDTO.Address,
                    ContactNumber = employeeDTO.ContactNumber,
                    ProfileImagePath = path,
                    FKDepartment = employeeDTO.FKDepartment,
                    FKRole = employeeDTO.FKRole,
                };

                await context.Employees.AddAsync(Employee);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Employee Inserted";
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetEmployeeById(int id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await context.Employees.Where(x => x.PkId == id).FirstOrDefaultAsync();
                if(Data != null)
                {
                    ResponseDTO.Response = Data;
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

        public async Task<ResponseDTO> DeleteEmployee(int id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await context.Employees.Where(x=>x.PkId == id).FirstOrDefaultAsync();
                var wwwpath = webHostEnvironment.WebRootPath;
                var filename = Data.ProfileImagePath;
                var path = Path.Combine(wwwpath+filename);
                if(File.Exists(path))
                {
                    File.Delete(path);
                    if(Data != null)
                    {
                        context.Employees.Remove(Data);
                        await context.SaveChangesAsync();
                        ResponseDTO.Response = "Employee Deleted";
                    }
                    else
                    {
                        ResponseDTO.StatusCode = 404;
                    }
                }
                else
                {
                    ResponseDTO.ErrorMessage = "Image Not Found";
                }
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var path = "";
                var pathc = "";
                var data = await context.Employees.Where(x=>x.PkId==employeeDTO.PkId).FirstOrDefaultAsync();
                if (data != null)
                {
                    if (employeeDTO.ProfileImagePath != null)
                    {
                        var FileName = employeeDTO.ProfileImagePath.FileName;
                        path = FileName  = data.ProfileImagePath;
                        pathc = Path.Combine("Upload",webHostEnvironment.WebRootPath + FileName);
                        using (Stream stream = new FileStream(path, FileMode.Create))
                        {
                            await employeeDTO.ProfileImagePath.CopyToAsync(stream);
                        }
                }
                    }


                var Employee = new Employee()
                {
                    PkId = employeeDTO.PkId,
                    Name = employeeDTO.Name,
                    Email = employeeDTO.Email,
                    Cnic = employeeDTO.Cnic,
                    Address = employeeDTO.Address,
                    ContactNumber = employeeDTO.ContactNumber,
                    FKDepartment = employeeDTO.FKDepartment,
                    FKRole = employeeDTO.FKRole,
                };
                context.Employees.Update(Employee);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Employee Updated";
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
