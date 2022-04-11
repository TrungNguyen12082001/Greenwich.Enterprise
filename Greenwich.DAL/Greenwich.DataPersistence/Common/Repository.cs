using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Greenwich.DataPersistence.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Constructor

        protected DbContext _dbContext;
        internal DbSet<TEntity> _dbSet;
        private Policy _policy;
        private readonly ILogger _logger;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();

            _policy = Policy.Handle<SqlException>(e => e.Number == 1205) // Handling deadlock victim
              .WaitAndRetry(2, retryAttempt => TimeSpan.FromMilliseconds(200),
              (exception, timeSpan, context) => { _logger.LogError(exception, "SQL Error {0}"); });
        }

        #endregion

        #region Public Functions

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await (orderBy != null ? orderBy(query).ToListAsync() : query.ToListAsync());
        }

        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        #endregion

    }
}
