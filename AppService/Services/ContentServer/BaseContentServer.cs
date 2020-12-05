using AppService.Helpers;
using AppService.Services.ContentServer.Firebase;
namespace AppService.Services.ContentServer
{
    public class BaseContentServer
    {
        protected AppSettings _setting;

        private BaseContentServer (AppSettings setting)
        {
            _setting = setting;
        }

        public static IBaseContentServer Build (ContentServerTypeEnum type)
        {
            switch(type)
            {
                case ContentServerTypeEnum.FIREBASE:

                    return new FirebaseUpload();

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
