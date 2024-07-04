using System.ComponentModel.DataAnnotations;

namespace EgyBestFilm.Application.Dtos
{
    public class LoginDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(dataType:DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
