using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ReviewDto
    {
        public int SubscriberId { get; set; }
        public string SubcriberUserName { get; set; }
        public int Score { get; set; }
        public int AlbunId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
    }
}
