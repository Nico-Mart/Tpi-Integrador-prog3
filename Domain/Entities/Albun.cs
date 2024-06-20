using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Albun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public List<string> Songs { get; set; }
        [Required]
        public float Duration { get; set; }
        [ForeignKey("MusicianId")]
        public Musician Musician { get; set; }
        public int MusicianId { get; set; }
        public string MusicianName { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
