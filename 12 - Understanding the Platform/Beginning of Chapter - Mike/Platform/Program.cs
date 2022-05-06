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
    await context.Response.WriteAsync("Mike make fun \n");  //  this line will behind "Hello World"

});



app.Use(async (context, next) =>
{
    if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        //This will cause Error as the Header has been set, and the Header has been sent yet!!! 
        context.Response.ContentType = "text/plain";                    // assign Response Header
        await context.Response.WriteAsync("Custom MiddleWare Two!\n");  // Write text to Response Body
    }
    await next();
    await context.Response.WriteAsync("Mike make fun Two!\n");  //  this line will behind "Hello World"

});

//MapGet is extension of certain Interface(IEndpointRouteBuilder) by which WebApplication inherit
app.MapGet("/", () => "Hello World! \n");

app.Run();
