using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models.AuthVM
{
    public class SignInVM
    {
        [Required]
        public string Email {  get; set; }

        [Required]
        public string Password { get; set; }

    }
}
