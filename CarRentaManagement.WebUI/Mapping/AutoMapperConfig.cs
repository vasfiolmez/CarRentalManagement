using AutoMapper;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Dto.LoginDtos;
using CarRentalManagement.Dto.RegisterDtos;

namespace CarRentaManagement.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateRegisterDto,AppUser>().ReverseMap();
            CreateMap<CreateLoginDto,AppUser>().ReverseMap();
        }
    }
}
