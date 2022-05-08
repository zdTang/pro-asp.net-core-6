using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class SimpleCacheAttribute:Attribute,IResourceFilter
{

    private Dictionary<PathString, IActionResult> CachedResponses = new Dictionary<PathString, IActionResult>();


    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // Once a Request come, if Cache has buffered this request path, then return it's value
        PathString path = context.HttpContext.Request.Path;
        if (CachedResponses.ContainsKey(path))
        {
            //Notice: This Result is ActionResult, will be invocated to generate a final Response
            context.Result = CachedResponses[path];
            CachedResponses.Remove(path);
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // Through out the MVC Action Invocation pipeline, the context.Result can be provided by Execution of the action 
        // or by another Filter !!
        // Be aware ! the Result is not the final response, it should be executed one more time.
        // Here, the Result could be the final result of this Request,
        // But the Filter is able to modify it at this point.
        if (context.Result != null)
        {
            CachedResponses.Add(context.HttpContext.Request.Path,context.Result);
        }
    }
}