using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.Dtos
{
    public class PasswordChangeDto
    {
        [DataType(DataType.Password)]
        [Required]
        public string OldPassword { get; set; }
        [DataType(DataType.Password)]
        public string NewPassord { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassord", ErrorMessage ="Password Dont Match")]
        
        public string ConfirmPassworrd { get; set; }
    }
}
