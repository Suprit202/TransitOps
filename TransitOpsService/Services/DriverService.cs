using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TransitOpsRepository.Models;
using TransitOpsRepository.Repository.IRepository;
using TransitOpsService.DataTransferObject;
using TransitOpsService.Services.IServices;

namespace TransitOpsService.Services
{
    public class DriverService : IDriverService
    {
        private readonly IGenericRepository<Driver> _driverRepository;
        private readonly IGenericRepository<DriverStatus> _statusRepository;
        private readonly IMapper _mapper;

        public DriverService(IGenericRepository<Driver> driverRepository,
            IGenericRepository<DriverStatus> statusRepository,
            IMapper mapper
            )
        {
            _driverRepository = driverRepository;
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DriverStatusDto>> GetAllDriverStatusesAsync()
        {
            var statuses = await _statusRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DriverStatusDto>>(statuses);
        }

        public async Task<IEnumerable<DriverDto>> GetAllDriversAsync()
        {
            var drivers = await _driverRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DriverDto>>(drivers);
        }

        public async Task<DriverDto> GetDriverByIdAsync(int id)
        {
            var driver = await _driverRepository.GetByIdAsync(id);
            return _mapper.Map<DriverDto>(driver);
        }

        public async Task CreateDriverAsync(DriverDto driverDto, string createdBy)
        {
            var driver = _mapper.Map<Driver>(driverDto);
            driver.CreatedBy = createdBy;
            driver.CreatedAt = DateTime.UtcNow;

            await _driverRepository.AddAsync(driver);
            await _driverRepository.SaveChangesAsync();
        }

        public async Task UpdateDriverAsync(DriverDto driverDto, string updatedBy)
        {
            var existingDriver = await _driverRepository.GetByIdAsync(driverDto.Id);
            if (existingDriver != null)
            {
                _mapper.Map(driverDto, existingDriver);

                existingDriver.UpdatedBy = updatedBy;
                existingDriver.UpdatedAt = DateTime.UtcNow;

                _driverRepository.Update(existingDriver);
                await _driverRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteDriverAsync(int id)
        {
            var driver = await _driverRepository.GetByIdAsync(id);
            if (driver != null)
            {
                _driverRepository.Remove(driver);
                await _driverRepository.SaveChangesAsync();
            }
        }
    }
}
