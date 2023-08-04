using System.ComponentModel.DataAnnotations;

namespace ETicket.Data.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email Address is required")]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
