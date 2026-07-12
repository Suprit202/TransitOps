using AutoMapper;
using TransitOps.Models;
using TransitOpsService.DataTransferObject;

namespace TransitOps.MappingProfiles
{
    public class UiProfile : Profile
    {
        public UiProfile()
        {
            CreateMap<VehicleDto, VehicleViewModel>().ReverseMap();
            CreateMap<DriverDto, DriverViewModel>().ReverseMap();
        }
    }
}
