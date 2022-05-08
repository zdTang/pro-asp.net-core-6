using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class ChangeArgAttribute:Attribute,IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //After Model-Binding, Before Action Execution
        if (context.ActionArguments.ContainsKey("message1"))
        {
            context.ActionArguments["message1"] = "new message";
        }
        
        await next();
        
        //After Action Execution, Before Action-Result Execution
    }
}