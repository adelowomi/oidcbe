using System;
using System.IO;
using AppService.Helpers;

namespace AppService.AppModel.InputModel
{
    public class DocumentInputModel
    {
        public int PlotId { get; set; }

        public int DocumentType { get; set; }

        public string Document { get; set; }

        public string GetDocumentType() => DocumentType == (int)DOCUMENTTYPE.SURVEY ? "Survey" : DocumentType == (int)DOCUMENTTYPE.CONTRACT ? "Contract" : "Deed";
    }

    enum DOCUMENTTYPE
    {
        SURVEY = 1,
        CONTRACT,
        DEED
    }
}
