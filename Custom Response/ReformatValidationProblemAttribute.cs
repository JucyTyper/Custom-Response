using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Custom_Response
{
    public class ReformatValidationProblemAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                if (badRequestObjectResult.Value is ValidationProblemDetails validationProblem)
                {
                    var response = new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,    //namespace Microsoft.AspNetCore.Http
                        IsSuccess = false,
                        Result = validationProblem.Errors
                    };
                    context.Result = new BadRequestObjectResult(response); 
                }
            }

            base.OnResultExecuting(context);
        }
    }
}
