using FoodParty.DomainLayer.Contracts;
using FoodParty.DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodParty.DataAccessLayer
{
    public class EfCoreRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class, IAggrigateRoot
    {
        private bool _disposed;

        public EfCoreRepository(AppDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(Context));
        }

        public IQueryable<TEntity> Query
        {
            get
            {
                return this.Context.Set<TEntity>()
                                    .AsNoTracking()
                                    .AsQueryable();
            }
        }

        public AppDbContext Context
        {
            get;
            private set;
        }

        public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(TEntity));
            }
            this.Context.Set<TEntity>().Add(entity);
            await this.Context.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task BulkCreateAsync(List<TEntity> entities, CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(TEntity));
            }
            
            this.Context.AddRange(entities);
            await this.Context.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(TEntity));
            }
            this.Context.Remove(entity);
            await this.Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task BulkDeleteAsync(List<TEntity> entities, CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(TEntity));
            }
            this.Context.RemoveRange(entities);
            await this.Context.SaveChangesAsync(cancellationToken);
        }

        public ValueTask<TEntity?> FindByIdAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            return this.Context.Set<TEntity>().FindAsync(predecate, cancellationToken);
        }

        public Task<List<TEntity>> IncludeAsync<TProperty>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> navigationPropertyPath, CancellationToken cancellationToken) where TProperty : class
        {
            this.ThrowIfDisposed();
            return this.Context.Set<TEntity>().Where(predicate).Include(navigationPropertyPath).AsNoTracking().ToListAsync(cancellationToken);
        }

        public Task<List<TProjectionType>> GetAllAsync<TProjectionType>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjectionType>> selector, CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            return this.Context.Set<TEntity>().Where(predicate).Distinct().Select(selector).ToListAsync(cancellationToken);
        }

        public Task<List<TProjectionType>> GetPagedAsync<TProjectionType, TOrderTkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjectionType>> selector, Expression<Func<TEntity, TOrderTkey>> orderBySelector, int pageSize, int takeItem, int currentIndex, CancellationToken cancellationToken) where TProjectionType : class
        {
            this.ThrowIfDisposed();
            int resultSkip = (currentIndex - 1) * takeItem;
            return this.Context.Set<TEntity>().Where(predicate)
                                        .OrderBy(orderBySelector)
                                        .Skip(resultSkip)
                                        .Take(takeItem)
                                        .Select(selector)
                                        .AsNoTracking()
                                .ToListAsync(cancellationToken);
        }

        public Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            return this.Context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(TEntity));
            }
            this.Context.Set<TEntity>().Update(entity);
            await this.Context.SaveChangesAsync(cancellationToken);
        }

        // DISPOSE STUFF: ===============================================
        private void ThrowIfDisposed()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }
        public bool DisposeContext
        {
            get;
            set;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.DisposeContext && disposing && this.Context != null)
            {
                this.Context.Dispose();
            }
            this._disposed = true;
            this.Context = null;
        }
    }
}
