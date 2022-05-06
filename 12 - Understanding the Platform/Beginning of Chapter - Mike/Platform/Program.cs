var builder = WebApplication.CreateBuilder(args);
//Builder is used for configuration 

var app = builder.Build();  // here will generate a WebApplication instance
//WebApplication can be linked with a bunch of Middleware to make a request PipeLine



//MapGet is extension of certain Interface(IEndpointRouteBuilder) by which WebApplication inherit
app.MapGet("/", () => "Hello World!");

app.Run();
