using AutoMapper;
using Lab3.Models;
using Lab3.Repository.OrderRepository;
using Lab3.Repository.ProductRepository;

namespace Lab3
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
