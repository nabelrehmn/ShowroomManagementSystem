using Microsoft.EntityFrameworkCore;
using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;
using System.IO;

namespace ShowroomManagmentAPI.Models
{
    public class VehicleModel : IVehicle
    {

        public readonly ApplicationDbContext Context;
        public readonly IWebHostEnvironment WebHostEnvironment;
        public VehicleModel(ApplicationDbContext _Context, IWebHostEnvironment _WebHostEnvironment)
        {
            this.Context = _Context;
            this.WebHostEnvironment = _WebHostEnvironment;
        }

        public async Task<ResponseDTO> GetVehicles()
        {
            var Response = new ResponseDTO();

            try
            {
                Response.Response = await Context.Vehicles.ToListAsync();
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> AddVehicle(VehicleDTO VehicleDTO)
        {
            var Response = new ResponseDTO();

            try
            {
                var path = "";
                if (VehicleDTO.ProfileImagePath != null)
                {
                    var FileName = VehicleDTO.ProfileImagePath.FileName;
                    path = Path.Combine("Uploads",WebHostEnvironment.WebRootPath+FileName);
                    using (Stream stream = new FileStream(path,FileMode.Create))
                    {
                        await VehicleDTO.ProfileImagePath.CopyToAsync(stream);
                    }
                }

                var Vehicle = new Vehicle()
                {
                    Model = VehicleDTO.Model,
                    Manufacturer = VehicleDTO.Manufacturer,
                    Year = VehicleDTO.Year,
                    Color = VehicleDTO.Color,
                    Mileage = VehicleDTO.Mileage,
                    VIN = VehicleDTO.VIN,
                    Price = VehicleDTO.Price,
                    Quantity = VehicleDTO.Quantity,
                    ProfileImagePath = path
                };

                await Context.Vehicles.AddAsync(Vehicle);
                await Context.SaveChangesAsync();
                Response.Response = "Vehicle has been Inserted";
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> GetVehicleById(int Id)
        {
            var Response = new ResponseDTO();

            try
            {
                var Data = await Context.Vehicles.Where(x=>x.VehicleId == Id).FirstOrDefaultAsync();
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

        public async Task<ResponseDTO> DeleteVehicle(int Id)
        {
            var Response = new ResponseDTO();

            try
            {
                var Data = await Context.Vehicles.Where(x=>x.VehicleId == Id).FirstOrDefaultAsync();
                var FileName = Data.ProfileImagePath;
                var path = Path.Combine(WebHostEnvironment.WebRootPath,FileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    if (Data != null)
                    {
                        Context.Vehicles.Remove(Data);
                        await Context.SaveChangesAsync();
                        Response.Response = "Vehicle has been Deleted";
                    }
                    else
                    {
                        Response.StatusCode = 404;
                    }
                }
                else
                {
                    Response.ErrorMessage = "Image Not Found";
                }
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> UpdateVehicle(VehicleDTO VehicleDTO)
        {
            var Response = new ResponseDTO();

            try
            {
                var Data = await Context.Vehicles.Where(x => x.VehicleId == VehicleDTO.VehicleId).FirstOrDefaultAsync();
                if (Data != null)
                {
                    if (VehicleDTO.ProfileImagePath != null)
                    {
                        var FileName = VehicleDTO.ProfileImagePath.FileName;
                        var path = FileName = Data.ProfileImagePath;
                        var pathc = Path.Combine("Uploads",WebHostEnvironment.WebRootPath,FileName);
                        using (Stream stream = new FileStream(path,FileMode.Create))
                        {
                            await VehicleDTO.ProfileImagePath.CopyToAsync(stream);
                        }
                    }
                }

                var Vehicle = new Vehicle()
                {
                    Model = VehicleDTO.Model,
                    Manufacturer = VehicleDTO.Manufacturer,
                    Year = VehicleDTO.Year,
                    Color = VehicleDTO.Color,
                    Mileage = VehicleDTO.Mileage,
                    VIN = VehicleDTO.VIN,
                    Price = VehicleDTO.Price,
                    Quantity = VehicleDTO.Quantity
                };

                Context.Vehicles.Update(Vehicle);
                await Context.SaveChangesAsync();
                Response.Response = "Vehicle has been updated";
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }
    }
}
