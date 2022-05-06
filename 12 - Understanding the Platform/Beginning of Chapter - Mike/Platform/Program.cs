var builder = WebApplication.CreateBuilder(args);
//Builder is used for configuration 

var app = builder.Build();  // here will generate a WebApplication instance
//WebApplication can be linked with a bunch of Middleware to make a request PipeLine


// By aware, here the platform will pass a async function into the Use(), Similar with the Promise in JS
app.Use(async (context, next) =>
{
    if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";                    // assign Response Header
        await context.Response.WriteAsync("Custom MiddleWare \n");  // Write text to Response Body
    }
    await next();
});

//MapGet is extension of certain Interface(IEndpointRouteBuilder) by which WebApplication inherit
app.MapGet("/", () => "Hello World!");

app.Run();
