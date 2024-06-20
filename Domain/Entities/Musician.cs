using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Musician : User
    {
        public Musician()
        {
            UserType = Enum.UserType.Musician;
        }
        
        public string Alias { get; set; }
        public int Musiciansquant { get; set; }
        public string MusicianName { get; set;}
        public string Genre { get;  set; }
        [ForeignKey("AlbunId")]
        public Albun Albun { get; set; }
        public int? AlbunId { get; set; }
        public ICollection<Albun> Albuns { get; set; } 
    }
}
