using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class AdminInputModel : RegisterInputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
