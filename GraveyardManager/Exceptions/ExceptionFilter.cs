using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GraveyardManager.Exceptions
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = context.Exception switch
            {
                NotFoundException notFoundException => NotFoundResult(notFoundException),
                BadRequestException badRequestException => BadRequestResult(badRequestException),
                _ => UnknownExceptionResult(context.Exception)
            };
        }

        private static IActionResult NotFoundResult(NotFoundException exception)
        {
            return new JsonResult(new { Message = exception.Message })
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }
        private static IActionResult BadRequestResult(BadRequestException exception)
        {
            return new JsonResult(new { Message = exception.Message })
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
        private static IActionResult UnknownExceptionResult(Exception exception)
        {
            var payload = new
            {
                exception.Message,
                Exception = exception.ToString()
            };

            return new JsonResult(payload)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
