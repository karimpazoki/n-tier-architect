using FoodParty.DomainLayer.Entities;
using FoodParty.ApplicationServices.Shared;

namespace FoodParty.BussinessLayer.DealProjects
{
    public interface IDealProjectRule
    {
        Task<ServiceResult<DealProject>> DeleteAsync(long id, CancellationToken cancellationToken);
        Task<ServiceResult<IReadOnlyList<DealProject>>> GetAllAsync(CancellationToken cancellationToken);
        Task<ServiceResult<DealProject>> InsertAsync(DealProject entity, CancellationToken cancellationToken);
        Task<ServiceResult<DealProject>> UpdateAsync(DealProject entity, CancellationToken cancellationToken);
        Task<ServiceResult<DealProject>> GetByIdAsync(long id, CancellationToken cancellationToken);
    }
}
