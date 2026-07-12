using System;
using System.Collections.Generic;
using System.Text;

namespace TransitOpsService.DataTransferObject
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseCategory { get; set; }
        public DateOnly LicenseExpiryDate { get; set; }
        public string ContactNumber { get; set; }
        public decimal SafetyScore { get; set; }

        public int StatusId { get; set; }
    }
}
