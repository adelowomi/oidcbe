using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppService.Helpers;
using AppService.Services.Abstractions;
using AppService.Services.Request;
using AppService.Services.Response;
using Microsoft.Extensions.Options;
using Refit;

namespace AppService.Services
{
    public class RestEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly IRestEmailService _restEmailService;
        private AppSettings _settings;

        public RestEmailService(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
            _httpClient = new HttpClient();
            _restEmailService = RestService.For<IRestEmailService>(_settings.PepipostBaseUrl);
        }

        public async Task<BaseResponse> SendEmail(EmailRequest email)
        {
            try
            {
                var result = await _restEmailService.SendEmail(email, _settings.PepipostApiKey);

            } catch (Exception e) {

                return null;
            }

            return null;
        }
    }
}
