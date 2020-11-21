using System;
using AppService.AppModel.InputModel;

namespace AppService.AppModel.ViewModel
{
    public class DocumentViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string DocumentName { get; set; }

        public int DocumentType { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
