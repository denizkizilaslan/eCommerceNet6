using ProductService.Application.Repositories.Abstraction;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Repositories.Concrete
{
    public class ProducttService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;

        public ProducttService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }
        public bool AddProduct(Product item)
        {
            return _repository.Add(item);
        }

        public bool DeleteProduct(Product item)
        {
            return _repository.Delete(item);
        }

        public Product GetProduct(int id)
        {
            return _repository.FindBy(id);
        }

        public List<Product> GetProducts()
        {
            return _repository.All().ToList<Product>();
        }

        public List<Product> GetProductsByBrandId(int brandId)
        {
            return _repository.FilterBy(x => x.Brand.Id == brandId).ToList<Product>();
        }
    }
}
