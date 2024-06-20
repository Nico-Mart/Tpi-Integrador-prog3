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
    public class AlbunDto
    {
        public string Title { get; set; }
        public List<string> Songs { get; set; }
        public float Duration { get; set; }
        public int MusicianId { get; set; }
        public string MusicianName {  get; set; }
    }
}
