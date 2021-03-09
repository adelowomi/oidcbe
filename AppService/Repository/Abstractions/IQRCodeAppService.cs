using System;
using System.Threading.Tasks;

namespace AppService.Repository.Abstractions
{
    public interface IQRCodeAppService
    {
        public Task<string> GenerateCodeAsync();
    }
}
