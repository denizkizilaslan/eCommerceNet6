using ProductService.Application.Repositories.Abstraction;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Repository;

namespace ProductService.Application.Repositories.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _repository;

        public BrandService(IGenericRepository<Brand> repository)
        {
            _repository = repository;
        }
        public bool AddBrand(Brand item)
        {
            return _repository.Add(item);
        }

        public bool DeleteBrand(Brand item)
        {
            return _repository.Delete(item);
        }

        public Brand GetBrand(int id)
        {
            return _repository.FindBy(id);
        }

        public List<Brand> GetBrands()
        {
            return _repository.All().ToList<Brand>();
        }
    }
}
