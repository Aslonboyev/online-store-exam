namespace OnlineStore.Service.DTOs.OrderDTOs
{
    public class OrderDetailCreationDTO
    {
        public long ProductId { get; set; }

        public int ProductCount { get; set; }

        public long OrderId { get; set; }
    }
}
