using System.Net;
using System.Web.Http.Filters;

namespace Business.NotImplExceptionFilterAttribute
{
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            string exceptionMessage = string.Empty;
            if (context.Exception.InnerException == null)
            {
                exceptionMessage = context.Exception.Message;
            }
            else
            {
                exceptionMessage = context.Exception.InnerException.Message;
            }
            var path = context.Request.RequestUri.AbsolutePath;
            var exceptionStack = context.Exception.StackTrace;
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent($"An exception has occurred in the method ({path}): \n {exceptionMessage} \n {exceptionStack}")
            };


        }
    }
}
