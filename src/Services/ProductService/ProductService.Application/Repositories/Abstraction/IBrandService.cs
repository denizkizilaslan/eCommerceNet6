using ProductService.Domain.Entities;

namespace ProductService.Application.Repositories.Abstraction
{
    public interface IBrandService
    {
        bool AddBrand(Brand item);
        bool DeleteBrand(Brand item);
        Brand GetBrand(int id);
        List<Brand> GetBrands();
    }
}
