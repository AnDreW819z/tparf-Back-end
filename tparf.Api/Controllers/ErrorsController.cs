using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using tparf.Application.Services.Common.Errors;

namespace tparf.Api.Controllers
{
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        
        [Route("/error")]
        [HttpPost]
        public IActionResult ErrorEx()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage), 
                _ => (StatusCodes.Status500InternalServerError, "Ошибка на сервере"),
            };

            return Problem(statusCode: statusCode, title: message);
        }
    }
}
