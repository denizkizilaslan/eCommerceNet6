namespace WebApp.Domain.Models.ViewModels
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public Guid ReferanceNumber { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public string Description { get;  set; }
        public decimal Total { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
