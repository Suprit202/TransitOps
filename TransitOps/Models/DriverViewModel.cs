using System.ComponentModel.DataAnnotations;
using TransitOps.Attributes;

namespace TransitOps.Models
{
    public class DriverViewModel
    {
        public int Id { get; set; }

        [Searchable]
        [Required(ErrorMessage = "Full Name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Searchable]
        [Required(ErrorMessage = "License Number is required.")]
        [Display(Name = "License Number")]
        public string LicenseNumber { get; set; }

        [Required(ErrorMessage = "License Category is required.")]
        [Display(Name = "License Category")]
        public string LicenseCategory { get; set; }

        [Required]
        [Display(Name = "Expiry Date")]
        public DateTime LicenseExpiryDate { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Safety Score")]
        public decimal SafetyScore { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public string? StatusName { get; set; }
    }
}

