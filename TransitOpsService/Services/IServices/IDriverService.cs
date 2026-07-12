using System;
using System.Collections.Generic;
using System.Text;
using TransitOpsService.DataTransferObject;

namespace TransitOpsService.Services.IServices
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDto>> GetAllDriversAsync();
        Task<IEnumerable<DriverStatusDto>> GetAllDriverStatusesAsync();
        Task<DriverDto> GetDriverByIdAsync(int id);
        Task CreateDriverAsync(DriverDto driverDto, string createdBy);
        Task UpdateDriverAsync(DriverDto driverDto, string updatedBy);
        Task DeleteDriverAsync(int id);
    }
}
