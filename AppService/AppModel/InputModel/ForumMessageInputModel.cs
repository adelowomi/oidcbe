using System;
namespace AppService.AppModel.InputModel
{
    public class ForumMessageInputModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }

        public int? ForumId { get; set; }

        public int ForumMessageTypeId { get; set; }
    }
}
