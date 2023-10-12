using AutoMapper;
using Lab1.Models;
using Lab1.Repository.ProductRepository;

namespace Lab1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
