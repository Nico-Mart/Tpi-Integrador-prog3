using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string SubcriberUserName { get; set; }
        public string Description { get; set; }
        public int  Score { get; set; }
        [ForeignKey("SubscriberId")]
        public Subscriber Subscriber { get; set; }
        public int? SubscriberId { get; set; }
        [ForeignKey("AlbunId")]
        public Albun Albun { get; set; }
        public int AlbunId { get; set; }
        public ICollection<Albun> albuns { get; set; } 
    }
}
