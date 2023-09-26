using ArticleStore.Domain.Models.Base;
using System.Linq.Expressions;

namespace ArticleStore.Application.Repositories.Abstractions
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByTextAsync(string text);
        IQueryable<TEntity> GetAll();
       // Task<IEnumerable<TEntity>> GetAllAsync();
       // IQueryable<TEntity> GetActiveEntities();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
