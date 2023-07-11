using FoodParty.DomainLayer.Contracts;
using System.Linq.Expressions;

namespace FoodParty.DomainLayer.Contract
{
    public interface IAppStore<TEntity> where TEntity : class, IEntity
    {
        bool DisposeContext { get; set; }
        IQueryable<TEntity> Query { get; }

        Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task BulkCreateAsync(List<TEntity> entities, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task BulkDeleteAsync(List<TEntity> entities, CancellationToken cancellationToken);
        void Dispose();
        ValueTask<TEntity> FindByIdAsync(Expression<Func<TEntity, bool>> predecate, CancellationToken cancellationToken);
        Task<List<ProjectionType>> GetAllAsync<ProjectionType>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, ProjectionType>> selector, CancellationToken cancellationToken);
        Task<List<ProjectionType>> GetPagedAsync<ProjectionType, orderTkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, ProjectionType>> selector, Expression<Func<TEntity, orderTkey>> orderBySelector, int pageSize, int takeItem, int currentIndex, CancellationToken cancellationToken) where ProjectionType : class;
        Task<List<TEntity>> IncludeAsync<TProperty>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> navigationPropertyPath, CancellationToken cancellationToken) where TProperty : class;
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}