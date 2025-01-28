using Microsoft.AspNetCore.Mvc.Filters;

namespace QueryableAPI.Filters
{
    public class CrazyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult("WTF???");
        }

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    // Do something after the action executes.
        //}
    }
}
