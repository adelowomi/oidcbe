using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class VendorCreateInputModel
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyAddress { get; set; }

        [Required]
        public string CompanyWebsite { get; set; }

        [Required]
        public string CompanyEmail { get; set; }

        [Required]
        public string RepresentativeName { get; set; }

        [Required]
        public string RepresentativeEmail { get; set; }

        [Required]
        public string RepresentativePhoneNumber { get; set; }

        [Required]
        public string CompanyRCNumber { get; set; }

        public string Document { get; set; }

        public int DocumentType { get; set; }
    }
}
