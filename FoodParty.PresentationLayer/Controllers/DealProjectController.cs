using AutoWrapper.Wrappers;
using FoodParty.BussinessLayer.DealProjects;
using FoodParty.DomainLayer.Entities;
using FoodParty.PresentationLayer.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Application.EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealProjectController : BaseApiController
    {
        private readonly IDealProjectRule _dealProjectRule;

        public DealProjectController(IDealProjectRule dealProjectRule)
        {
            this._dealProjectRule = dealProjectRule;
        }

        [HttpPost]
        public async Task<ApiResponse> Post([FromBody] DealProject entity, CancellationToken cancellationToken) =>
            await ApiResponseAsync(() => _dealProjectRule.InsertAsync(entity, cancellationToken));

        [HttpGet]
        public async Task<ApiResponse> Get(CancellationToken cancellationToken) =>
            await ApiResponseAsync(() => _dealProjectRule.GetAllAsync(cancellationToken));
        
        [HttpGet]
        [Route("{id:long}")]
        public async Task<ApiResponse> Show([FromRoute] long id, CancellationToken cancellationToken) =>
            await ApiResponseAsync(() => _dealProjectRule.GetByIdAsync(id,cancellationToken));
        [HttpPut]
        public async Task<ApiResponse> Put([FromBody] DealProject entity, CancellationToken cancellationToken) =>
            await ApiResponseAsync(() => _dealProjectRule.UpdateAsync(entity, cancellationToken));

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<ApiResponse> Delete([FromRoute] long id, CancellationToken cancellationToken) =>
          await ApiResponseAsync(() => _dealProjectRule.DeleteAsync(id, cancellationToken));
    }
}
