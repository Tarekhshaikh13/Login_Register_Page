using Login_Register_Page.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Login_Register_Page.ViewModels
{
    public class Register
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        [PasswordValidation]
        [PasswordLength]
        public string Password { get; set; }
        [Required]
        
        [Compare(nameof(Password),ErrorMessage ="Passwords Did not match")]

        public string ConfirmPassword { get; set; } 

        [Required(ErrorMessage ="Agree To Terms")]
        public bool Tnc { get; set; }
    }
}
