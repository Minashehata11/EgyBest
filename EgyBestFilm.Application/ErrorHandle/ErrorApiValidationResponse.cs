using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.ErrorHandle
{
    public class ErrorApiValidationResponse:ErrorApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ErrorApiValidationResponse():base(400)
        {
            Errors = new List<string>();
        }
    }
}
