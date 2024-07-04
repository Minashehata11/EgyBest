using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.Dtos
{
    public class RegisterDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(dataType: DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string Nathionality { get; set; }
        public DateTime DateOfBirh { get; set; }
    }
}
