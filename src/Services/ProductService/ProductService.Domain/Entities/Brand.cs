namespace ProductService.Domain.Entities
{
    public class Brand
    {
        public Brand()
        {
            Products = new List<Product>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Product> Products { get; set; }

    }
}
