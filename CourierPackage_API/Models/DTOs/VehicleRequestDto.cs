using System.ComponentModel.DataAnnotations;

namespace CourierPackage_API.Models.DTOs
{
    public class VehicleRequestDto
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime VehicleInsuranceExpireDate { get; set; }
        public DateTime VehicleLicenceExpireDate { get; set; }
        public DateTime VehicleExpirationDate { get; set; }
        [MaxLength(50)]
        public string TrnUser { get; set; } = string.Empty;       
    }
}
