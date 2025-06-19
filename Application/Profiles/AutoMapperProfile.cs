using APPLICATION.Dtos.Products;
using AutoMapper;
using DOMAIN.Entities;

namespace APPLICATION.Profiles;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}