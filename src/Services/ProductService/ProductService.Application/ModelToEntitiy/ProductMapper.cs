using ProductService.Application.Model;
using ProductService.Domain.Entities;

namespace ProductService.Application.ModelToEntitiy
{
    public static class ProductMapper
    {
        public static Product ToEntity(this ProductModel request)
        {
            var product = new Product();

            product.Name = request.Name;
            product.Description = request.Description;
            product.Quantity = request.Quantity;
            product.Price = request.Price;
            return product;
        }
    }
}
