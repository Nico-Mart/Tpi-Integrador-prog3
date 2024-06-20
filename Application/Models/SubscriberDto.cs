using Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class SubscriberDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? FavoriteGenre { get; set; }

    }
}
