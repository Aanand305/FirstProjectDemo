using System.ComponentModel.DataAnnotations;

namespace FirstProjectDemo.ViewModel
{
    public class SignUpModel
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Password Mismatch")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
    }
}
