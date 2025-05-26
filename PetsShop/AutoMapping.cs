using AutoMapper;
using DTOs;
using Entities;
using static DTOs.CategoryDTO;
using static DTOs.OrderDTO;
using static DTOs.OrderItemDTO;
using static DTOs.ProductDTO;
using static DTOs.UserDTO;


namespace PetsShop
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            
            CreateMap<Category, CategoryDto>();
             
            CreateMap<Order, OrderDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserRegister, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<UserLoginDto, UserLogin>();
            CreateMap<Product, ProductDto>()
                    .ForMember("CategoryName",
                    opts => opts.MapFrom(src => src.Category.Name));
            CreateMap<OrderDto, Order>().ForMember(dest => dest.OrderItems,
                    opt => opt.MapFrom(src => src.Products));
        }
    }
}
