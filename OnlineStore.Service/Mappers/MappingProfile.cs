using AutoMapper;
using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Contacts;
using OnlineStore.Domain.Entities.Discounts;
using OnlineStore.Domain.Entities.Locations;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Domain.Entities.Products;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.DTOs.CategoryDTOs;
using OnlineStore.Service.DTOs.ContactDTOs;
using OnlineStore.Service.DTOs.DiscountDTOs;
using OnlineStore.Service.DTOs.LocationDTOs;
using OnlineStore.Service.DTOs.OrderDTOs;
using OnlineStore.Service.DTOs.ProductDTOs;
using OnlineStore.Service.DTOs.UserDTOs;

namespace OnlineStore.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserCreationDTO>().ReverseMap();
            CreateMap<Contact, ContactCreationDTO>().ReverseMap();
            CreateMap<Discount, DiscountCreationDTO>().ReverseMap();
            CreateMap<Order, OrderCreationDTO>().ReverseMap();
            CreateMap<Product, ProductCreationDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailCreationDTO>().ReverseMap();
            CreateMap<Location, LocationCreationDTO>().ReverseMap();
            CreateMap<Category, CategoryCreationDTO>().ReverseMap();
        }
    }
}
