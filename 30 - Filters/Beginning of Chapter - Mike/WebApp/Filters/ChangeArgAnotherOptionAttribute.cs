using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

/// <summary>
/// Different Approach: This approach will not inherit an Interface. But inherit ActionFilterAttribute base class
/// </summary>


public class ChangeArgAnotherOptionAttribute:ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
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