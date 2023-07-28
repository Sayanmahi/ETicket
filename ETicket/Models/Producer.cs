using ETicket.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ETicket.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Profile picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full NAme should be between 3 to 50 chars")]

        public string FullName { get; set; }
        public string Bio { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
