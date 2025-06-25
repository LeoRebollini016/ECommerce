using APPLICATION.Dtos.Products;
using AutoMapper;
using DOMAIN.Entities;
using Shared.Dtos.Clients;
using Shared.Dtos.Order;

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

        CreateMap<Order, OrderWithoutDetailsDto>();
        CreateMap<Order, OrderDto>();
        CreateMap<CreateOrderDto, Order>()
            .ForMember(x => x.Id, options => options.Ignore())
            .ForMember(x => x.Details, options => options.MapFrom(src => src.Details));

        CreateMap<DetailOrder, DetailOrderDto>();
        CreateMap<DetailOrderDto, DetailOrder>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.Order, opt => opt.Ignore())
            .ForMember(x => x.Product, opt => opt.Ignore());
    }
}