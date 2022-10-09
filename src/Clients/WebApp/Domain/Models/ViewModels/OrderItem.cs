namespace WebApp.Domain.Models.ViewModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }

    }
}
