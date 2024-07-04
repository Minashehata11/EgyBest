using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.ErrorHandle
{
    public class ErrorApiResponse
    {
        public ErrorApiResponse(int statusCode,string? message=null)
        {
            StatusCode= statusCode;
            Message= message??GetDefaultErrorResponseMessage(statusCode) ;
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        private string? GetDefaultErrorResponseMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "You are Not Authorize",
                403 => "Forbidding",
                404 => "Not Found",
                500 => "server error",
                _ => null,

            };
        }
    }
}
