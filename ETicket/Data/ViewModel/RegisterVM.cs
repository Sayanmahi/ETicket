using System.ComponentModel.DataAnnotations;

namespace ETicket.Data.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Email Address is required")]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="This is a required field")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords donot match")]
        public string ConfirmPassword { get; set; }
    }
}
