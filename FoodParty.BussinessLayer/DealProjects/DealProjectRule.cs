using FoodParty.DomainLayer.Entities;
using FoodParty.ApplicationServices.Shared;
using FoodParty.DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodParty.BussinessLayer.DealProjects
{
    public class DealProjectRule : IDealProjectRule
    {
        private readonly IRepository<DealProject> _dealProjectRepository;
        // private readonly IRepository<VendorSupertype> _vendorStore;
        public DealProjectRule(IRepository<DealProject> dealProjectStore)
        {
            _dealProjectRepository = dealProjectStore;
            // _vendorStore = vendorStore;
        }

        public async Task<ServiceResult<DealProject>> InsertAsync(DealProject entity, CancellationToken cancellationToken)
        {
            await _dealProjectRepository.CreateAsync(entity, cancellationToken);
            return new ServiceResult<DealProject>
            {
                IsSucceeded = true,
                Data = entity,
            };
        }
        public async Task<ServiceResult<DealProject>> UpdateAsync(DealProject entity, CancellationToken cancellationToken)
        {
            await _dealProjectRepository.UpdateAsync(entity, cancellationToken);
            return new ServiceResult<DealProject>
            {
                IsSucceeded = true,
                Data = entity,
            };
        }
        public async Task<ServiceResult<IReadOnlyList<DealProject>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _dealProjectRepository.Query.ToListAsync(cancellationToken);
            return new ServiceResult<IReadOnlyList<DealProject>>
            {
                Data = result.AsReadOnly(),
                IsSucceeded = true
            };
        }
        
        public async Task<ServiceResult<DealProject>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            // var q1 = _dealProjectRepository.Query;
            // var q2 = _vendorStore.Query;
            // var q = from d in q1
            //     join v in q2 on d.VendorSuperTypeId equals v.Id into g 
            //     select new DealProject
            //     {
            //         Title = d.Title,
            //         VendorSupertypes = g.ToList(),
            //     };
            // var dealVendors = await q.ToListAsync();

            var result = await _dealProjectRepository.FindByIdAsync(e => e.Id == id, cancellationToken);
            // var result = await _dealProjectRepository.IncludeAsync(
            //     e=>e.Id==id,
            //     e=>e.VendorSupertypes,
            //     cancellationToken
            // );
            
            return new ServiceResult<DealProject>
            {
                Data = result,
                IsSucceeded = true
            };
        }
        
        public async Task<ServiceResult<DealProject>> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var entity = new DealProject { Id = id };
            await _dealProjectRepository.DeleteAsync(entity, cancellationToken);
            return new ServiceResult<DealProject>
            {
                IsSucceeded = true,
            };
        }

    }
}
