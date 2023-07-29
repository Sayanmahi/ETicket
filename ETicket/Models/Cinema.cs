using ETicket.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ETicket.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Cinema logo is required")]
        public string Logo { get; set; }
        [Required(ErrorMessage ="It is mandatory field")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
