using FoodParty.DomainLayer.Contracts;
using System.Linq.Expressions;

namespace FoodParty.DomainLayer.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        bool DisposeContext { get; set; }
        IQueryable<TEntity> Query { get; }

        Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task BulkCreateAsync(List<TEntity> entities, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task BulkDeleteAsync(List<TEntity> entities, CancellationToken cancellationToken);
        void Dispose();
        ValueTask<TEntity> FindByIdAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken);
        Task<List<TProjectionType>> GetAllAsync<TProjectionType>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjectionType>> selector, CancellationToken cancellationToken);
        Task<List<TProjectionType>> GetPagedAsync<TProjectionType, TOrderTkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjectionType>> selector, Expression<Func<TEntity, TOrderTkey>> orderBySelector, int pageSize, int takeItem, int currentIndex, CancellationToken cancellationToken) where TProjectionType : class;
        Task<List<TEntity>> IncludeAsync<TProperty>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> navigationPropertyPath, CancellationToken cancellationToken) where TProperty : class;
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}