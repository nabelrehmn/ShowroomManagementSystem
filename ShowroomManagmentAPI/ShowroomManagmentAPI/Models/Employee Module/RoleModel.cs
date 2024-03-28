using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models
{
    public class RoleModel : IRole
    {
        private readonly ApplicationDbContext context;
        public RoleModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDTO> GetRoles()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
             ResponseDTO.Response =  await context.Roles.ToListAsync();
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> AddRole(RoleDTO roleDTO)
        {
            var ResponseDTO = new ResponseDTO();

            try
            {
                var Role = new Role()
                {
                    RollName = roleDTO.RoleName,
                    Description = roleDTO.Description,
                    permissions = roleDTO.Permissions
                };

                await context.Roles.AddAsync(Role);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Role Inserted";

            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> GetRoleById(int id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await context.Roles.Where(x => x.PkId == id).FirstOrDefaultAsync();
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

        public async Task<ResponseDTO> DeleteRole(int id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await context.Roles.Where(x=>x.PkId == id).FirstOrDefaultAsync();
                if(Data != null)
                {
                    context.Roles.Remove(Data);
                    await context.SaveChangesAsync();
                    ResponseDTO.Response = "Role Deleted";
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

        public async Task<ResponseDTO> UpdateRole(RoleDTO roleDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var role = new Role()
                {
                    PkId = roleDTO.PkId,
                    RollName = roleDTO.RoleName,
                    Description = roleDTO.Description,
                    permissions = roleDTO.Permissions,
                };

                context.Roles.Update(role);
                await context.SaveChangesAsync();
                ResponseDTO.Response = "Role Updated";

            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
