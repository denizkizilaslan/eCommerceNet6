namespace OrderService.Domain.Models
{
    public class Order
    {
        public virtual Guid ReferanceNumber { get; set; }
        public virtual int Id { get; set; }
        public virtual DateTime OrderDate { get;  set; }
        public virtual int OrderStatus { get; set; }
        public virtual string Description { get;  set; }
        public virtual decimal Total { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }= new List<OrderItem>();
    }
}
