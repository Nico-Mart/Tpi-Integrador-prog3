using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Subscriber : User
    {
        public Subscriber()
        {
            UserType = Enum.UserType.Subscriber;
        }
        public int Phone { get; set; }
        public string? FavoriteGenre { get; set; } 
        public ICollection<Review> Reviews { get; set; } 
    }
}
