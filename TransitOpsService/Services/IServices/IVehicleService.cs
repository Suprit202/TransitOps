using System;
using System.Collections.Generic;
using System.Text;
using TransitOpsService.DataTransferObject;

namespace TransitOpsService.Services.IServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync();
        Task<VehicleDto?> GetVehicleByIdAsync(int id);
        Task CreateVehicleAsync(VehicleDto vehicleDto, string currentUserId);
        Task UpdateVehicleAsync(VehicleDto vehicleDto, string currentUserId);
        Task DeleteVehicleAsync(int id);
    }
}
