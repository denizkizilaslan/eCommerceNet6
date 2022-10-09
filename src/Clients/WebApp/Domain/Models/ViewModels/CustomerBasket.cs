namespace WebApp.Domain.Models.ViewModels
{
    public class CustomerBasket
    {
        public List<BasketItem> Items { get; init; } = new List<BasketItem>();
        public string CustomerId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.Price * x.Quantity), 2);
        }
    }
}
