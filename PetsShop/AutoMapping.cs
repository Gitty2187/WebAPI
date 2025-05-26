using AutoMapper;
using DTOs;
using Entities;
using static DTOs.UserDTO;


namespace PetsShop
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<User, UserDto>();
            CreateMap<UserRegister, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<Product, ProductDTO>()
                    .ForMember("CategoryName",
                    opts => opts.MapFrom(src => src.Category.Name));
            CreateMap<OrderDTO, Order>().ForMember(dest => dest.OrderItems,
                    opt => opt.MapFrom(src => src.Products));
        }
    }
}
