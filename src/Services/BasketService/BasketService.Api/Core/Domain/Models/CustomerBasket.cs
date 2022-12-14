namespace BasketService.Api.Core.Domain.Models
{
    public class CustomerBasket
    {
        public string CustomerId { get; set; }

        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public CustomerBasket()
        {

        }
        public CustomerBasket(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
