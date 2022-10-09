namespace OrderService.Domain.Models
{
    public class OrderItem
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }

        public virtual string ProductName { get; set; }

        public virtual string PictureUrl { get; set; }

        public virtual decimal Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual Order Order { get; set; }

    }
}
