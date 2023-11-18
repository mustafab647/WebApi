using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WebApi.Models;

namespace WebApi.Attribute
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Result result = new Result();
            result.Success = false;
            result.Error = context.Exception.Message;
            JsonResult jsonResult = new JsonResult(result);
            jsonResult.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = jsonResult;
            
            base.OnException(context);
        }
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            return base.OnExceptionAsync(context);
        }
    }
}
