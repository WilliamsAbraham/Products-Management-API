using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Product_Management_API
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductCreationDto>().ReverseMap();
            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<AppAdmin, UserForRegistrationDto>().ReverseMap();
            CreateMap<AppAdmin, UserForAuthenticationDto>().ReverseMap();

        }
    }
}
