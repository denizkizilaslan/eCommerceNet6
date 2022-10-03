namespace ProductService.Domain.Entities
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ISet<Product> Products { get; set; }

    }
}
