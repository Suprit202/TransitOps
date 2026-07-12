using System.ComponentModel.DataAnnotations;
using TransitOps.Attributes;

namespace TransitOps.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Searchable]
        [Required(ErrorMessage = "Registration Number is mandatory.")]
        [Display(Name = "Reg. No. (Unique)")]
        public string RegistrationNumber { get; set; }

        [Searchable]
        [Required(ErrorMessage = "Model Name is required.")]
        [Display(Name = "Name/Model")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Please select a vehicle type.")]
        [Display(Name = "Vehicle Type")]
        public int VehicleTypeId { get; set; }

        [Required]
        [Range(1, 50000, ErrorMessage = "Capacity must be greater than 0.")]
        [Display(Name = "Capacity (kg)")]
        public decimal CapacityKg { get; set; }

        [Display(Name = "Odometer")]
        [Required(ErrorMessage = "Please select a Odometer value.")]
        public decimal Odometer { get; set; }

        [Required]
        [Display(Name = "Acquisition Cost")]
        public decimal AcquisitionCost { get; set; }

        public int StatusId { get; set; }
    }
}
