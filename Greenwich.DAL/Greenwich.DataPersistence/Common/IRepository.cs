using System.Linq.Expressions;

namespace Greenwich.DataPersistence.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // Task để tận dùng memory đang trống để chạy các tác vụ, tăng performace
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                 string includeProperties = "");

        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetByIdAsync(object id);
        Task InsertAsync(TEntity entity);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
    }
}
