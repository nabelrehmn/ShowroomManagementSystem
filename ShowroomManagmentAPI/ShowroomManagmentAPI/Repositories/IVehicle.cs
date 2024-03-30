using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface IVehicle
    {
        public Task<ResponseDTO> GetVehicles();

        public Task<ResponseDTO> AddVehicle(VehicleDTO VehicleDTO);

        public Task<ResponseDTO> GetVehicleById(int ID);

        public Task<ResponseDTO> DeleteVehicle(int Id);

        public Task<ResponseDTO> UpdateVehicle(VehicleDTO VehicleDTO);
    }
}
