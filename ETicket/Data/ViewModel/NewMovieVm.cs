using ETicket.Data.Base;
using ETicket.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicket.Models
{
    public class NewMovieVm
    {
        [Required(ErrorMessage ="Name is Required")]
        [Display(Name ="Movie Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        [Display(Name = "Description Name")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        [Display(Name = "Price in Rs.")]
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        [Required(ErrorMessage = "Actor is required")]
        [Display(Name = "Select Actor(s)")]
        public List<int> ActorIds { get; set; }
        public int CinemaId { get; set; }

        public int ProducerId { get; set; }
    }
}
