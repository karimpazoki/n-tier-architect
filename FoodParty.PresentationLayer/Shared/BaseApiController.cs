using AutoWrapper.Wrappers;
using FoodParty.DomainLayer.Exceptions;
using FoodParty.ApplicationServices.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FoodParty.PresentationLayer.Shared
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ApiResponse> ApiResponseAsync<TResult>(Func<Task<ServiceResult<TResult>>> serviceMethod)
        {
            try
            {
                var response = await serviceMethod();
                return new ApiResponse(response.Data);
            }
            catch (NotFoundException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return new ApiResponse
                {
                    IsError = true,
                    Message = ex.Message,
                    ResponseException = ex,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Result = ex.Data,
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsError = true,
                    Message = ex.Message,
                    ResponseException = ex,
                    StatusCode = ex.HResult,
                    Result = ex.Data,
                };
            }

        }
        private ApiResponse BadRequest(string message)
        {
            return new ApiResponse((int)HttpStatusCode.BadRequest, message);
        }
    }
}
