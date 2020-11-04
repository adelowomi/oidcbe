using System;
using System.Threading.Tasks;
using AppService.Services.Request;
using AppService.Services.Response;
using Refit;

namespace AppService.Services.Abstractions
{
    public interface IRestEmailService
    {
        [Post("/mail/send")]
        [Headers("Content-Type : application/json", "api_key: 4f0a5625681f50b43f3488864d86222b")]
        Task<BaseResponse> SendEmail([Body] EmailRequest request, [Header("api-key")] string apiKey);
    }
}
