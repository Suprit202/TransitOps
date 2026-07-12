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
    public class VehicleService : IVehicleService
    {
        private readonly IGenericRepository<Vehicle> _vehicleRepository;
        private readonly IGenericRepository<VehicleType> _typeRepository;
        private readonly IGenericRepository<VehicleStatus> _statusRepository;
        private readonly IMapper _mapper;

        public VehicleService(IGenericRepository<Vehicle> vehicleRepository,
            IGenericRepository<VehicleStatus> statusRepository,
            IMapper mapper,
            IGenericRepository<VehicleType> typeRepository)
        {
            _vehicleRepository = vehicleRepository;
            _statusRepository = statusRepository;
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }

        public async Task<IEnumerable<VehicleStatusDto>> GetVehicleStatusesAsync()
        {
            var statuses = await _statusRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VehicleStatusDto>>(statuses);
        }

        public async Task<IEnumerable<VehicleTypeDto>> GetVehicleTypesAsync()
        {
            var types = await _typeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VehicleTypeDto>>(types);
        }

        public async Task<VehicleDto?> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null) return null;

            return _mapper.Map<VehicleDto>(vehicle);
        }

        public async Task CreateVehicleAsync(VehicleDto vehicleDto, string currentUserId)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(vehicleDto);

            vehicleEntity.CreatedBy = currentUserId;
            vehicleEntity.CreatedAt = DateTime.UtcNow;

            await _vehicleRepository.AddAsync(vehicleEntity);
            await _vehicleRepository.SaveChangesAsync();
        }

        public async Task UpdateVehicleAsync(VehicleDto vehicleDto, string currentUserId)
        {
            var existingVehicle = await _vehicleRepository.GetByIdAsync(vehicleDto.Id);
            if (existingVehicle != null)
            {
                _mapper.Map(vehicleDto, existingVehicle);

                existingVehicle.UpdatedBy = currentUserId;
                existingVehicle.UpdatedAt = DateTime.UtcNow;

                _vehicleRepository.Update(existingVehicle);
                await _vehicleRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle != null)
            {
                _vehicleRepository.Remove(vehicle);
                await _vehicleRepository.SaveChangesAsync();
            }
        }
    }
}
