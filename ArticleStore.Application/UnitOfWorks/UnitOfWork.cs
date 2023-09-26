using ArticleStore.Application.Context;
using ArticleStore.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace ArticleStore.Application.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ArticleStoreDbContext _articleStoreDbContext;
        public UnitOfWork(ArticleStoreDbContext articleStoreDbContext)
        {
            _articleStoreDbContext = articleStoreDbContext;
        }

        public void Commit()
        {
            var tracker = _articleStoreDbContext.ChangeTracker.Entries<BaseEntity>();
            foreach (var item in tracker)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedDate = DateTime.Now;
                    item.Entity.IsActive = true;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedDate = DateTime.Now;
                }
                else if (item.State == EntityState.Deleted)
                {
                    item.Entity.DeletedDate = DateTime.Now;
                }
            }
            _articleStoreDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            var tracker = _articleStoreDbContext.ChangeTracker.Entries<BaseEntity>();
            foreach (var item in tracker)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedDate = DateTime.Now;
                    item.Entity.IsActive = true;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedDate = DateTime.Now;
                }
                else if (item.State == EntityState.Deleted)
                {
                    item.Entity.DeletedDate = DateTime.Now;
                }
            }
            await _articleStoreDbContext.SaveChangesAsync();
        }
    }
}
