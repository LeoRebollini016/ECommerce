using APPLICATION.Dtos.Products;
using AutoMapper;
using DOMAIN.Entities;
using Shared.Dtos.Clients;

namespace APPLICATION.Profiles;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateProductDto, Product>();

        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<CreateClientDto, Client>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}