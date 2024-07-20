using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class AuthenticacionRequest
    {
        [Required]
        public string? UserName { get; set; }
        [Required] 
        public string? Password { get; set; }
        public UserType? UserType { get; set; }
    }
}
