using EgyBestFilm.Application.ErrorHandle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyBest.Presentaion.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : ControllerBase
    {
        public ActionResult errors(int code)
        {
            return NotFound(new ErrorApiResponse(code));
        }
    }
}
