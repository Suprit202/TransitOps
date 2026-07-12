using System;
using System.Collections.Generic;
using System.Text;

namespace TransitOpsService.DataTransferObject
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string ModelName { get; set; }
        public string VehicleType { get; set; }
        public decimal CapacityKg { get; set; }
        public decimal Odometer { get; set; }
        public decimal AcquisitionCost { get; set; }
        public int StatusId { get; set; }
    }
}
