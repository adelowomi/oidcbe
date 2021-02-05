using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppService.AppModel.InputModel
{
    public class RegisterInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "Invalid User Type")]
        public UserTypeEnum UserType { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "Invalid Organization Type")]
        public OrganizationEnumType OrganizationType { get; set; }

        public string Platform { get; set; }

        [JsonIgnore]
        public bool IsAdmin { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }

    public enum UserTypeEnum
    {
        VENDOR = 1,
        SUBSCRIBER
    }

    public enum OrganizationEnumType
    {
        INDIVIDUAL = 1,
        CORPORATE
    }
}