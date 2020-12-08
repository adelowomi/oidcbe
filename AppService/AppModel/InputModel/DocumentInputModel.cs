using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using AppService.Helpers;

namespace AppService.AppModel.InputModel
{
    public class DocumentInputModel
    {
        [Required]
        public int PlotId { get; set; }

        [Required]
        public int DocumentType { get; set; }

        [Required]
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
