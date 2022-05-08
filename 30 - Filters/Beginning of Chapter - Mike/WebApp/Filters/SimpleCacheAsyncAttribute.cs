using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class SimpleCacheAsyncAttribute:Attribute,IAsyncResourceFilter
{
    private Dictionary<PathString, IActionResult> CachedResponses = new Dictionary<PathString, IActionResult>();
    
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        PathString path = context.HttpContext.Request.Path;
        if (CachedResponses.ContainsKey(path))
        {
            //Notice: This Result is ActionResult, will be invocated to generate a final Response
            context.Result = CachedResponses[path];
            CachedResponses.Remove(path);
        }
        else
        {
            //Be aware ! Once the Execution come back, it will bring a new Context
            //We can short circuit the Pipeline by Providing a Result for the new Context
            ResourceExecutedContext executedContext = await next();
            
            if (executedContext.Result != null)
            {
                CachedResponses.Add(executedContext.HttpContext.Request.Path,executedContext.Result);
            }
        }
    }
}