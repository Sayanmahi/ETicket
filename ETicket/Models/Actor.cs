using ETicket.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ETicket.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set;}
        public string Bio { get; set; }

        public List<Actor_Movie> Actors_Movies { get; set;}
    }
}
