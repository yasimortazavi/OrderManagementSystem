public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderDto, CreateOrderCommand>();
    }
}
