using System;
using System.Drawing;
using System.Security.Policy;
using System.Threading.Tasks;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AppService.Services.ContentServer;
using AppService.Services.ContentServer.Model;
using Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using QRCoder;

namespace AppService.Repository
{
    public class QRCodeAppService : IQRCodeAppService
    {
        private AppSettings _settings;

        public QRCodeAppService(IOptions<AppSettings> option)
        {
            _settings = option.Value;
        }

        public async Task<string> GenerateCodeAsync()
        {
            Url generator = new Url("https://www.oidc.com");
            string payload = generator.ToString();
            string link = string.Empty;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20);

            FileDocument uploadResult = FileDocument.Create();

            try
            {
                uploadResult = await
                   BaseContentServer
                   .Build(ContentServerTypeEnum.FIREBASE, _settings)
                   .UploadDocumentAsync(FileDocument.Create(qrCodeImageAsBase64, $"{Helper.RandomNumber(10)}", $"{Helper.RandomNumber(10)}", FileDocumentType.GetDocumentType(MIMETYPE.IMAGE)));

                link = uploadResult.Path;
            }
            catch (Exception e)
            {
                link = string.Empty;
            }

            return link;
        }
    }
}
