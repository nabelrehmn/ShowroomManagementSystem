using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowroomManagmentAPI.DTOs
{
    public class VehicleDTO
    {
        [Key]
        public string ModelId { get; set; }
        public string Manufacturer { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }
        [MaxLength(17)]
        public string VIN { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Features { get; set; }
        public string WheelCount { get; set; }
        public string EngineType { get; set; }
        public IFormFile ProfileImagePath { get; set; }
        public int FKVehicleCategoryId { get; set; }
    }
}
