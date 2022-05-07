using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

/// <summary>
/// Here demo how to create a custom Filter
/// </summary>
public class HttpsOnlyAttribute:Attribute,IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
       // write authorization logic here
       if (!context.HttpContext.Request.IsHttps)
       {
           // Once this Result has been set, then the ASP.NET core will execute the Result other than Endpoint !!!
           context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
       }
    }
}