using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Product_Management_API
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductCreationDto>();
            CreateMap<Product, ProductResponseDto>();
            CreateMap<Product, ProductUpdateDto>();
            CreateMap<AppAdmin, UserForRegistrationDto>();
            CreateMap<AppAdmin, UserForAuthenticationDto>();

        }
    }
}
