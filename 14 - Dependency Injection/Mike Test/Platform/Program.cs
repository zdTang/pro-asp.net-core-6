using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

//IResponseFormatter formatter = new TextResponseFormatter();
app.MapGet("middleware/function", async (context) => {
    // The formatter Instance is just a Carrier here.
    // It's Format Method relies on dependencies "context" which will be passed by the Context it is applied
    // But the Method will update its State. 
    // That is to say, it relies on outside dependency to change its State                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
    await TextResponseFormatter.Singleton.Format(context, "Middleware Function: It is snowing in Chicago");
});

app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

app.MapGet("endpoint/function", async context => {
    //await context.Response.WriteAsync("Endpoint Function: It is sunny in LA");
    await TextResponseFormatter.Singleton.Format(context, "Endpoint Function: It is sunny in LA");
});

app.Run();
