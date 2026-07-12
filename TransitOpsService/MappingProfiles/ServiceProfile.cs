using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TransitOpsRepository.Models;
using TransitOpsService.DataTransferObject;

namespace TransitOpsService.MappingProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
        }
    }
}
