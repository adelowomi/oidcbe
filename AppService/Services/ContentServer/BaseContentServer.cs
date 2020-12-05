using AppService.Helpers;
using AppService.Services.ContentServer.Firebase;
namespace AppService.Services.ContentServer
{
    public class BaseContentServer
    {
        private BaseContentServer() { }

        public static IBaseContentServer Build (ContentServerTypeEnum type, AppSettings setting)
        {
            switch(type)
            {
                case ContentServerTypeEnum.FIREBASE:
                    return new FirebaseUpload(setting);

                default:
                    return new DropBoxUpload();
            }
        }
    }

    public enum ContentServerTypeEnum
    {
        FIREBASE = 1,
        DROPBOX
    }
}
