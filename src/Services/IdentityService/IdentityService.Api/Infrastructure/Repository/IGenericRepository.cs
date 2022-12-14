using System.Linq.Expressions;

namespace IdentityService.Api.Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        bool Add(T entity);
        bool Add(IEnumerable<T> items);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(IEnumerable<T> entities);
        T FindBy(int id);
        T FindBy<TV>(TV id);
        IQueryable<T> All();
        T FindBy(Expression<Func<T, bool>> expression);
        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);
    }
}
