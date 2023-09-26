using ArticleStore.Application.Context;
using ArticleStore.Application.Repositories.Abstractions;
using ArticleStore.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArticleStore.Application.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        readonly ArticleStoreDbContext _articleStoreDbContext;
        readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ArticleStoreDbContext articleStoreDbContext)
        {
            _dbSet = articleStoreDbContext.Set<TEntity>();
            _articleStoreDbContext = articleStoreDbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        //public async Task<IEnumerable<TEntity>> GetRange(IEnumerable<int> ids)
        //{

        //    return await _dbSet.First(x-);
        //}
        //public IQueryable<TEntity> GetActiveEntities()
        //{
        //    return _dbSet.Where(x => x.IsActive == true);
        //}

        public IQueryable<TEntity> GetAll()
        {
            return  _dbSet;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByTextAsync(string text)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
