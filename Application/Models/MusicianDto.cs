using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class MusicianDto
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Alias { get; set; }
        public int Musiciansquant { get; set; }
        public string MusicianName { get; set; }
        public string Genre { get; set; }
    }
}
