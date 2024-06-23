using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models.AuthVM
{
    public class SignUpVM
    {
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; } 

    }
}
