namespace Platform;

public class QueryStringMiddleWare
{
    private readonly RequestDelegate _next;

    public QueryStringMiddleWare(RequestDelegate nextDelegate)
    {
        _next = nextDelegate;
    }

    public async Task Invoke(HttpContext context)
    {
       
        
        if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
        {
            //This will cause Error as the Header has been set, and the Header has been sent yet!!! 
            context.Response.ContentType = "text/plain";                    // assign Response Header
            await context.Response.WriteAsync("Custom MiddleWare _ Class Approach!\n");  // Write text to Response Body
        }
        await _next(context);
        await context.Response.WriteAsync("Custom MiddleWare _ Class Approach!_Return !\n");  // Write text to Response Body
        
    }

}
