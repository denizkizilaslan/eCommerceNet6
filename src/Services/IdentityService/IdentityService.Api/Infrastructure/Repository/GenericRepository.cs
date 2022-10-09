using NHibernate;
using System.Linq.Expressions;

namespace IdentityService.Api.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly NHibernate.ISession _session;

        public GenericRepository(NHibernate.ISession session)
        {
            _session = session;
        }

        public bool Add(T entity)
        {
            _session.Save(entity);
            _session.Flush();
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            _session.Flush();
            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            _session.Flush();

            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            _session.Flush();
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _session.Delete(entity);
            }
            _session.Flush();
            return true;
        }

        public T FindBy(int id)
        {
            _session.CacheMode = CacheMode.Normal;
            return _session.Get<T>(id);
        }

        public T FindBy<TV>(TV id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).FirstOrDefault();
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }

    }
}
