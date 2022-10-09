namespace OrderService.Application.Model
{
    public class OrderModel
    {
        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();
        }
        public Guid ReferanceNumber { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }

    public class OrderItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
